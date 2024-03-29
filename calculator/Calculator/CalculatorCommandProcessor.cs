﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using org.mariuszgromada.math.mxparser;

namespace calculator;

public class CalculatorCommandProcessor
{
    private List<string> _executionResult = new() {"0"};
    public string displayValue = "0";

    public string GetStringExecution()
    {
        return string.Join("", _executionResult);
    }

    public void ModifyDisplayValue()
    {
        // это надо вынести выше
        char[] operators = { '+', '-', '*', '/', '=' };
        displayValue = GetStringExecution();
        
        // воообще тут надо просто половину написаного вырезать и в помойку
        foreach (var op in operators)
        {
            displayValue = displayValue.Replace(op.ToString(), $"{op}\n");
        }
    }

    public void Add(Action callback)
    {
        if (_executionResult.Count - 2 >= 0 && _executionResult[^2] == "=")
        {
            Clear(_executionResult[^1]);
        }

        callback();
        ModifyDisplayValue();
    }

    public void AddOperation(string operation)
    {
        if (_executionResult[^1][^1] == '.')
        {
            _executionResult[^1] += "0";
        }
        
        _executionResult.Add(operation);
        _executionResult.Add("0");
    }

    public void AddNumber(string number)
    {
        bool isLastDouble = double.TryParse(_executionResult[^1],  NumberStyles.Number, CultureInfo.InvariantCulture, out double val);
        bool hasPoint = _executionResult[^1].Contains(".");
        bool isInputPoint = number == ".";
        
        if (isLastDouble)
        {
            if (_executionResult[^1].StartsWith("0") && !isInputPoint && !hasPoint)
            {
                _executionResult[^1] = number;
                return;
            }

            if (isInputPoint && hasPoint)
            {
                return;
            }
            
            _executionResult[^1] += number;
        } 
        else if (!isInputPoint)
        {
            _executionResult.Add(number);
        }
    }
    
    public void RemoveLast()
    {
        bool isLastCharZero = _executionResult[^1] == "0";
        bool isOneItemAvailable = _executionResult.Count == 1;

        string lastString = _executionResult[^1];
        int lastStringLength = lastString.Length;

        if (_executionResult.Contains("=") || (isLastCharZero && !isOneItemAvailable))
        {
            RemoveLastOperation();
        } else
        {
            // Define last string char
            _executionResult[^1] = lastStringLength > 1 ? lastString.Remove(lastStringLength - 1) : "0";
        }
        
        ModifyDisplayValue();
    }

    public void ClearEntry()
    {
        if (_executionResult.Contains("="))
        {
            RemoveLastOperation();
        }
        else if (_executionResult[^1] != "0")
        {
            _executionResult[^1] = "0";
        }
        
        ModifyDisplayValue();
    }

    public void Clear(string defaultValue = "0")
    {
        _executionResult = new() { defaultValue };
        ModifyDisplayValue();
    }

    public void Calculate()
    {
        if (_executionResult.Count > 1 && _executionResult[^2] != "=")
        {
            double result = new Expression(GetStringExecution()).calculate();
            AddOperation("=");
            AddNumber(result.ToString().Replace(',', '.'));
            ModifyDisplayValue();
        }
    }
    
    private void RemoveLastOperation()
    {
        _executionResult.RemoveRange(_executionResult.Count - 2, 2);
    }
}