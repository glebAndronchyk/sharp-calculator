using calculator.commands;
using calculator.interfaces;

namespace calculator;

public partial class Form1 : Form
{
    private CalculatorCommandInvoker _invoker = new ();
    private CalculatorCommandProcessor _processor = new();
    
    public Form1()
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
        BuildGrid();
    }
}