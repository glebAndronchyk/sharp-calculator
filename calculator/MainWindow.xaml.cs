using System.Windows;

namespace calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CalculatorCommandInvoker _invoker = new ();
        private CalculatorCommandProcessor _processor = new();
        
        public MainWindow()
        {
            ConfirmMxParserLicense();
            RegisterCommands();
            InitializeComponent();
            AppendCallbacksOnButtons();
            ConfigureTextInput();
        }
    }
}