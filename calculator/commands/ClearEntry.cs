using calculator.interfaces;

namespace calculator.commands;

public class ClearEntry : ICalculatorCommand
{
    public string name => "СE";

    private CalculatorCommandProcessor _receiver;

    public ClearEntry(CalculatorCommandProcessor receiver)
    {
        _receiver = receiver;
    }

    public void Execute()
    {
        // _receiver.AddOperation("+");
    }
}