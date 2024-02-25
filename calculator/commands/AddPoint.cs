using calculator.interfaces;

namespace calculator.commands;


public class AddPoint : ICalculatorCommand
{
    public string name => ".";

    private CalculatorCommandProcessor _receiver;

    public AddPoint(CalculatorCommandProcessor receiver)
    {
        _receiver = receiver;
    }

    public void Execute()
    {
        _receiver.Add(() =>_receiver.AddNumber(name));
    }
}