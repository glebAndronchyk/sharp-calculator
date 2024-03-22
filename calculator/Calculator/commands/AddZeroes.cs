using calculator.interfaces;

namespace calculator.commands;

public class AddZeroes: ICalculatorCommand
{
    public string name => "00";

    private CalculatorCommandProcessor _receiver;

    public AddZeroes(CalculatorCommandProcessor receiver)
    {
        _receiver = receiver;
    }

    public void Execute()
    {
        _receiver.Add(() => _receiver.AddNumber(name));
    }
}