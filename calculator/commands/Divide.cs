using calculator.interfaces;

namespace calculator.commands;

public class Divide : ICalculatorCommand
{
    public string name => "/";

    private CalculatorCommandProcessor _receiver;

    public Divide(CalculatorCommandProcessor receiver)
    {
        _receiver = receiver;
    }

    public void Execute()
    {
        _receiver.AddOperation(name);
    }
}