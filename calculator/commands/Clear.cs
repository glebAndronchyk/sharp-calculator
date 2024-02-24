using calculator.interfaces;

namespace calculator.commands;

public class Clear : ICalculatorCommand
{
    public string name => "clear";

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