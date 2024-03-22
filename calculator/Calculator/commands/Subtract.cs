using calculator.interfaces;

namespace calculator.commands;

public class Subtract : ICalculatorCommand
{
    public string name => "-";

    private CalculatorCommandProcessor _receiver;

    public Subtract(CalculatorCommandProcessor receiver)
    {
        _receiver = receiver;
    }

    public void Execute()
    {
        _receiver.Add(() =>_receiver.AddOperation(name));
    }
}