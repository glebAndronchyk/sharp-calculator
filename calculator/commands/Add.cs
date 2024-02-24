using calculator.interfaces;

namespace calculator.commands;

public class Add : ICalculatorCommand
{
    public string name => "add";

    private CalculatorCommandProcessor _receiver;

    public Add(CalculatorCommandProcessor receiver)
    {
        _receiver = receiver;
    }

    public void Execute()
    {
        _receiver.AddOperation("+");
    }
}