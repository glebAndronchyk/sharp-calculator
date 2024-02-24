using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using calculator.commands;

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
            
            _invoker.RegisterCommand(new Multiply(_processor));
            _invoker.RegisterCommand(new Add(_processor));
            _invoker.RegisterCommand(new Clear(_processor));
            _invoker.RegisterCommand(new ClearEntry(_processor));
            _invoker.RegisterCommand(new Divide(_processor));
            _invoker.RegisterCommand(new Equal(_processor));
            _invoker.RegisterCommand(new RemoveLast(_processor));
            _invoker.RegisterCommand(new Subtract(_processor));

            // for (int i = 0; i < 10; i++)
            // {
            //     _invoker.RegisterCommand(new WriteNumber(_processor, i.ToString()));
            // }
            
            InitializeComponent();
        }
    }
}