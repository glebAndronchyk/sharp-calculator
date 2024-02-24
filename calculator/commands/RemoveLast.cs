using calculator.interfaces;

namespace calculator.commands;

public class RemoveLast : ICalculatorCommand
{
    public string name => "<=";

    private CalculatorCommandProcessor _receiver;

    public RemoveLast(CalculatorCommandProcessor receiver)
    {
        _receiver = receiver;
    }

    public void Execute()
    {
        // _receiver.AddOperation("*");
    }
}