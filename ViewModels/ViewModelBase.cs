using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ReservationSalles.ViewModels;

/// <summary>
/// Classe de base pour tous les ViewModels
/// Implémente INotifyPropertyChanged pour supporter le binding XAML
/// </summary>
public abstract class ViewModelBase : INotifyPropertyChanged
{
    /// <summary>
    /// Événement déclenché lors de la modification d'une propriété
    /// </summary>
    public event PropertyChangedEventHandler? PropertyChanged;

    /// <summary>
    /// Notifie les abonnés qu'une propriété a changé
    /// </summary>
    /// <param name="propertyName">Nom de la propriété (rempli automatiquement)</param>
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    /// <summary>
    /// Définit la valeur d'une propriété et notifie les changements
    /// Évite la répétition du code boilerplate
    /// </summary>
    /// <typeparam name="T">Type de la propriété</typeparam>
    /// <param name="backingField">Champ de sauvegarde</param>
    /// <param name="value">Nouvelle valeur</param>
    /// <param name="propertyName">Nom de la propriété (rempli automatiquement)</param>
    /// <returns>true si la valeur a changé, false sinon</returns>
    protected bool SetProperty<T>(ref T backingField, T value, [CallerMemberName] string propertyName = "")
    {
        if (EqualityComparer<T>.Default.Equals(backingField, value))
            return false;

        backingField = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}
