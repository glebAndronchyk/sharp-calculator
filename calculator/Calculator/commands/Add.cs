using calculator.interfaces;

namespace calculator.commands;

public class Add : ICalculatorCommand
{
    public string name => "+";

    private CalculatorCommandProcessor _receiver;

    public Add(CalculatorCommandProcessor receiver)
    {
        _receiver = receiver;
    }

    public void Execute()
    {
        _receiver.Add(() =>_receiver.AddOperation(name));
    }
}