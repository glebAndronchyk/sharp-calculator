namespace calculator.interfaces;

public interface ICalculatorCommand
{
    string name { get; }

    public void Execute();
}