using calculator.interfaces;

namespace calculator.commands;

public class Equal : ICalculatorCommand
{
    public string name => "=";

    private CalculatorCommandProcessor _receiver;

    public Equal(CalculatorCommandProcessor receiver)
    {
        _receiver = receiver;
    }

    public void Execute()
    {
        _receiver.Calculate();
    }
}