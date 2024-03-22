using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace calculator;

public partial class MainWindow
{
    private bool _isExtended = false;

    private List<List<string>> _extendedLayout = new()
    {
        new() { "sqrt" },
        new() { "sqrt" },
        new() { "sqrt" },
        new() { "sqrt" },
        new() { "sqrt" },
    };

    private void ToggleExtended(object sender, RoutedEventArgs e)
    {
        _isExtended = !_isExtended;
        
        if (_isExtended)
        {
            ExtendOperationList();
        }
        else
        {
            ResetToDefaultOperationList();
        }

        Redraw();
    }

    private void ChangeGridSizing(int increaseVal)
    {
        CalculatorGrid.Columns += increaseVal;
    }

    private void ResetToDefaultOperationList()
    {
        for (int i = 0; i < _extendedLayout.Count; i++)
        {
            var currentExtendedRow = _extendedLayout[i];
            var removeAmount = currentExtendedRow.Count;
            
            _layout[i].RemoveRange(_layout[i].Count - removeAmount, removeAmount);
        }
        
        ChangeGridSizing(-1);
        ExtendButton.Content = ">";
    }

    private void ExtendOperationList()
    {
        for (int i = 0; i < _extendedLayout.Count; i++)
        {
            var currentExtendedRow = _extendedLayout[i];

            _layout[i] = _layout[i].Concat(currentExtendedRow).ToList();
        }

        ChangeGridSizing(1);
        ExtendButton.Content = "<";
    }

    private void Redraw()
    {
        while (CalculatorGrid.Children.Count > 0)
        {
            CalculatorGrid.Children.RemoveAt(0);
        }

        AppendButtons();
    }
}