namespace TonProjet;
public partial class AppShell : Shell{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(
            nameof(Pages.DetailSallePage),
            typeof(Pages.DetailSallePage));
    }
}
