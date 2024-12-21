using DefendersDeck.Domain.Constants;

namespace DefendersDeck.App
{
    public partial class App : Application
    {
        public App(IServiceProvider serviceProvider)
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }

        protected override async void OnStart()
        {
            base.OnStart();
            await Navigate();
        }

        private async Task Navigate()
        {
            var storedToken = await SecureStorage.GetAsync(BaseConstants.JwtKey);

            if (string.IsNullOrEmpty(storedToken))
            {
                await AppShell.Current.GoToAsync("//LoginPage");
            }
            else
            {
                await AppShell.Current.GoToAsync("//HomePage");
            }
        }
    }
}