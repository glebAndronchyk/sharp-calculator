using calculator.interfaces;

namespace calculator.commands;


public class WriteNumber : ICalculatorCommand
{
    public string name { get; }

    private CalculatorCommandProcessor _receiver;

    public WriteNumber(CalculatorCommandProcessor receiver, string registerName)
    {
        _receiver = receiver;
        name = registerName;
    }

    public void Execute()
    {
        _receiver.Add(() => _receiver.AddNumber(name));
    }
}