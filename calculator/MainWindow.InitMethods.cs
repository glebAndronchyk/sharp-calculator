using System;
using System.Windows.Controls;
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

        for (int i = 0; i < 10; i++)
        {
            _invoker.RegisterCommand(new WriteNumber(_processor, i.ToString()));
        }
    }

    private void AppendButtons()
    {
        foreach (var keyValuePair in _invoker.GetCommands())
        {
            var btn = CreateButton(keyValuePair.Key, _invoker.ExecuteCommand);
            CalculatorGrid.Children.Add(btn);
        }
    }

    private Button CreateButton(string content, Action<string> clickCallback)
    {
        var btn = new Button
        {
            Width = 20,
            Height = 20,
            Content = content,
        };
                
        btn.Click += (sender, e) => clickCallback(content);

        return btn;
    }

    private void ConfirmMxParserLicense()
    {
        License.iConfirmNonCommercialUse("John Doe");
        License.checkIfUseTypeConfirmed();
        License.getUseTypeConfirmationMessage();
    }
}