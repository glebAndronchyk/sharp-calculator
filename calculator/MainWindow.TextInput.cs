using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace calculator;

public partial class MainWindow
{
    private Dictionary<Key, string> keyboardKeys = new ()
    {
        { Key.OemMinus, "-"},
        { Key.OemPlus, "+"},
        { Key.Add, "+"},
        { Key.OemBackslash, "/"},
        { Key.Multiply, "*"},
        { Key.Divide, "/"},
        { Key.Back, "Back"},
        { Key.Return, "="},
        { Key.OemPeriod, "."},
        { Key.OemQuestion, "/"},
        { Key.Decimal, "."},
    };
    
    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        KeyDown += OnKeyPress;
    }

    private void OnKeyPress(object sender, KeyEventArgs textChangedEventArgs)
    {
        if (keyboardKeys.TryGetValue(textChangedEventArgs.Key, out var key))
        {
            _invoker.ExecuteCommand(key);
        } else if (textChangedEventArgs.Key.ToString().Any(char.IsDigit))
        {
            _invoker.ExecuteCommand(textChangedEventArgs.Key.ToString()[^1].ToString());
        }
        
        InputScreen.Text = _processor.displayValue;
    }
}