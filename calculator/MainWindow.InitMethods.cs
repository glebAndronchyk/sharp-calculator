using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using calculator.commands;
using org.mariuszgromada.math.mxparser;

namespace calculator;

public partial class MainWindow
{
    private void RegisterCommands()
    {
        _invoker.RegisterCommand(new Multiply(_processor));
        _invoker.RegisterCommand(new Add(_processor));
        _invoker.RegisterCommand(new Clear(_processor));
        _invoker.RegisterCommand(new ClearEntry(_processor));
        _invoker.RegisterCommand(new Divide(_processor));
        _invoker.RegisterCommand(new Equal(_processor));
        _invoker.RegisterCommand(new RemoveLast(_processor));
        _invoker.RegisterCommand(new Subtract(_processor));
        _invoker.RegisterCommand(new AddZeroes(_processor));
        _invoker.RegisterCommand(new AddPoint(_processor));

        for (int i = 0; i < 10; i++)
        {
            _invoker.RegisterCommand(new WriteNumber(_processor, $"{i}"));
        }
    }

    private void AppendCallbacksOnButtons()
    {
        foreach (var child in CalculatorGrid.Children)
        {
            if (child is Button castedChild)
            {
                castedChild.Click += (sender, e) =>
                {
                    var castedSender = (Button)sender;
                    _invoker.ExecuteCommand(castedSender.Content.ToString());
                    InputScreen.Text = _processor.displayValue;
                };
            }
        }
    }

    private void ConfirmMxParserLicense()
    {
        License.iConfirmNonCommercialUse("John Doe");
        License.checkIfUseTypeConfirmed();
        License.getUseTypeConfirmationMessage();
    }
}