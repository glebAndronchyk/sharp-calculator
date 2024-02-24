using System;
using System.Collections.Generic;
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
        if (_executionResult[^1][^1] == '.')
        {
            _executionResult[^1] += "0";
        }

        Console.WriteLine(GetStringExecution());

        _executionResult.Add(operation);
        _executionResult.Add("0");
    }

    public void AddNumber(string number)
    {
        bool isLastDouble = double.TryParse(_executionResult[^1], out double val);

        if (isLastDouble)
        {
            if (_executionResult[^1] == "0")
            {
                _executionResult[^1] = number;

                return;
            }

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

    public void RemoveLast()
    {
        if (_executionResult.Count > 0 && _executionResult[^1].Length == 0)
        {
            _executionResult.RemoveRange(_executionResult.Count - 2, 2);
            return;
        }

        _executionResult[^1].Remove(_executionResult[^1].Length - 1);
    }

    public void ClearEntry()
    {
        if (_executionResult[^1] != "0")
        {
            _executionResult[^1] = "0";
        }
    }
    
    public void Clear()
    {
        _executionResult = new() { "0" };
    }

    public double Calculate()
    {
        string exp = GetStringExecution();
        double result = new Expression(exp).calculate();
        Console.WriteLine($"{exp} = {result}");
        return result;
    }
}