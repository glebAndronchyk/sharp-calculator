﻿using calculator.interfaces;

namespace calculator;

public class CalculatorCommandInvoker
{
    private Dictionary<string, ICalculatorCommand> _commands = new ();

    public void RegisterCommand(ICalculatorCommand cmd)
    {
        _commands.Add(cmd.name, cmd);
    }

    public void ExecuteCommand(string name)
    {
        _commands[name].Execute();
    }

    public Dictionary<string, ICalculatorCommand> GetCommands()
    {
        return _commands;
    }
}