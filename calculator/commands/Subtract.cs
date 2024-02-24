using calculator.interfaces;

namespace calculator.commands;

public class Subtract : ICalculatorCommand
{
    public string name => "subtract";

    private CalculatorCommandProcessor _receiver;

    public Subtract(CalculatorCommandProcessor receiver)
    {
        _receiver = receiver;
    }

    public void Execute()
    {
        _receiver.AddOperation("-");
    }
}