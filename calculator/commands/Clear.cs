using calculator.interfaces;

namespace calculator.commands;

public class Clear : ICalculatorCommand
{
    public string name => "С";

    private CalculatorCommandProcessor _receiver;

    public Clear(CalculatorCommandProcessor receiver)
    {
        _receiver = receiver;
    }

    public void Execute()
    {
        // _receiver.AddOperation("+");
    }
}