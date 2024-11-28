namespace BillSplitter.Maui
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            const int windowWidth = 400;
            const int windowHeight = 700;

            var window = new Window(new MainPage())
            {
                Width = windowWidth,
                MaximumWidth = windowWidth,
                MinimumWidth = windowWidth,
                Height = windowHeight,
                MaximumHeight = windowHeight,
                MinimumHeight = windowHeight
            };
            return window;
        }
    }
}