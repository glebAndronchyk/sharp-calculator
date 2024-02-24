using System.Text;
using org.mariuszgromada.math.mxparser;

namespace calculator;

public class CalculatorCommandProcessor
{
    private List<string> _executionResult = new() {"0"};

    public string GetStringExecution()
    {
        return string.Join("", _executionResult);
    }

    public void AddOperation(string operation)
    {
        if (!double.TryParse(_executionResult[^1], out double val))
        {
            if (_executionResult[^1] != operation)
            {
                _executionResult[^1] = operation;
            }

            return;
        }

        if (_executionResult[^1][^1] == '.')
        {
            _executionResult[^1] += "0";
        }

        _executionResult.Add(operation);
    }

    public void AddNumber(string number)
    {
        bool isLastDouble = double.TryParse(_executionResult[^1], out double val);

        if (isLastDouble)
        {
            if (number == "." && _executionResult[^1].Contains("."))
            {
                return;
            }
            
            _executionResult[^1] += number;
        } 
        else if (number != ".")
        {
            _executionResult.Add(number);
        }
    }

    public double Calculate()
    {
        return new Expression(GetStringExecution()).calculate();
    }
}