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
    private List<List<string>> _layout = new()
    {
        new () {"CE", "C", "Back", "+"},
        new () { "7", "8", "9", "-"},
        new () { "4", "5", "6", "*"},
        new () { "1", "2", "3", "/"},
        new () { "00", "0", ".", "="},
    };

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
    
    private void AppendButtons()
    {
        foreach (var row in _layout)
        {
            foreach (var content in row)
            {
                var btn = CreateButton(content, () =>
                {
                    Console.WriteLine(content);
                    _invoker.ExecuteCommand(content);
                    InputScreen.Text = _processor.displayValue;
                });
                CalculatorGrid.Children.Add(btn);
            }
        }
    }

    private Button CreateButton(string content, Action clickCallback)
    {
        var btn = new Button
        {
            Content = content,
            HorizontalAlignment = HorizontalAlignment.Stretch,
            FontSize = 16,
        };
                
        btn.Click += (sender, e) => clickCallback();

        return btn;
    }

    private void ConfirmMxParserLicense()
    {
        License.iConfirmNonCommercialUse("John Doe");
        License.checkIfUseTypeConfirmed();
        License.getUseTypeConfirmationMessage();
    }
}