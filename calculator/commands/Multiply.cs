using calculator.interfaces;

namespace calculator.commands;

public class Multiply : ICalculatorCommand
{
    public string name => "*";

    private CalculatorCommandProcessor _receiver;

    public Multiply(CalculatorCommandProcessor receiver)
    {
        _receiver = receiver;
    }

    public void Execute()
    {
        _receiver.AddOperation(name);
    }
}