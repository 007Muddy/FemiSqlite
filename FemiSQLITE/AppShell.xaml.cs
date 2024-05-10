using FemiSQLITE.View;

namespace FemiSQLITE
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(AddUpdateItemDetail), typeof(AddUpdateItemDetail));
        }
    }
}
