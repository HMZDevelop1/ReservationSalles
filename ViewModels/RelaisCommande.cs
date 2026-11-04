using System.Windows.Input;

namespace ReservationSalles.ViewModels;

/// <summary>
/// Implémentation d'une commande réutilisable pour les binding XAML
/// Supporte les actions synchrones et asynchrones
/// </summary>
public class RelaisCommande : ICommand
{
    private readonly Action<object?> _execute;
    private readonly Func<object?, bool>? _canExecute;

    /// <summary>
    /// Événement déclenché quand l'état CanExecute peut avoir changé
    /// </summary>
    public event EventHandler? CanExecuteChanged;

    /// <summary>
    /// Constructeur pour une commande avec validation
    /// </summary>
    /// <param name="execute">Action à exécuter quand la commande est invoquée</param>
    /// <param name="canExecute">Fonction de validation optionnelle</param>
    public RelaisCommande(Action<object?> execute, Func<object?, bool>? canExecute = null)
    {
        _execute = execute ?? throw new ArgumentNullException(nameof(execute));
        _canExecute = canExecute;
    }

    /// <summary>
    /// Constructeur pour une commande sans paramètre
    /// </summary>
    public RelaisCommande(Action execute, Func<bool>? canExecute = null)
        : this(_ => execute(), canExecute == null ? null : _ => canExecute())
    {
    }

    /// <summary>
    /// Détermine si la commande peut être exécutée
    /// </summary>
    public bool CanExecute(object? parameter)
    {
        return _canExecute == null || _canExecute(parameter);
    }

    /// <summary>
    /// Exécute la commande
    /// </summary>
    public void Execute(object? parameter)
    {
        if (CanExecute(parameter))
        {
            _execute(parameter);
        }
    }

    /// <summary>
    /// Force la levée de l'événement CanExecuteChanged
    /// À appeler quand l'état de CanExecute peut avoir changé
    /// </summary>
    public void RaiseCanExecuteChanged()
    {
        CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}

/// <summary>
/// Implémentation d'une commande asynchrone pour les binding XAML
/// </summary>
public class RelaisCommandeAsync : ICommand
{
    private readonly Func<object?, Task> _executeAsync;
    private readonly Func<object?, bool>? _canExecute;
    private bool _isExecuting;

    /// <summary>
    /// Événement déclenché quand l'état CanExecute peut avoir changé
    /// </summary>
    public event EventHandler? CanExecuteChanged;

    /// <summary>
    /// Constructeur pour une commande asynchrone avec validation
    /// </summary>
    /// <param name="executeAsync">Action asynchrone à exécuter</param>
    /// <param name="canExecute">Fonction de validation optionnelle</param>
    public RelaisCommandeAsync(Func<object?, Task> executeAsync, Func<object?, bool>? canExecute = null)
    {
        _executeAsync = executeAsync ?? throw new ArgumentNullException(nameof(executeAsync));
        _canExecute = canExecute;
    }

    /// <summary>
    /// Constructeur pour une commande asynchrone sans paramètre
    /// </summary>
    public RelaisCommandeAsync(Func<Task> executeAsync, Func<bool>? canExecute = null)
        : this(_ => executeAsync(), canExecute == null ? null : _ => canExecute())
    {
    }

    /// <summary>
    /// Détermine si la commande peut être exécutée
    /// Retourne false si une exécution est déjà en cours
    /// </summary>
    public bool CanExecute(object? parameter)
    {
        if (_isExecuting)
            return false;

        return _canExecute == null || _canExecute(parameter);
    }

    /// <summary>
    /// Exécute la commande de manière asynchrone
    /// </summary>
    public async void Execute(object? parameter)
    {
        if (!CanExecute(parameter))
            return;

        _isExecuting = true;
        RaiseCanExecuteChanged();

        try
        {
            await _executeAsync(parameter);
        }
        finally
        {
            _isExecuting = false;
            RaiseCanExecuteChanged();
        }
    }

    /// <summary>
    /// Force la levée de l'événement CanExecuteChanged
    /// </summary>
    public void RaiseCanExecuteChanged()
    {
        CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}
