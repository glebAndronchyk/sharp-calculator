using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace calculator;

public partial class MainWindow
{
    private void ConfigureTextInput()
    {
        InputScreen.CaretIndex = InputScreen.Text.Length;
    }

    // private void InputScreen_OnTextChanged(object sender, TextChangedEventArgs textChangedEventArgs)
    // {
    //     Console.WriteLine(InputScreen.Text);
    //     Debounce(() => Console.WriteLine(InputScreen.Text))();
    // }
    //
    // public static Action Debounce(Action func, int milliseconds = 300)
    // {
    //     CancellationTokenSource? cancelTokenSource = null;
    //     return () =>
    //     {
    //         cancelTokenSource?.Cancel();
    //         cancelTokenSource = new CancellationTokenSource();
    //
    //         Task.Delay(milliseconds, cancelTokenSource.Token)
    //             .ContinueWith(t =>
    //             {
    //                 Console.WriteLine(t.IsCompletedSuccessfully);
    //                 if (t.IsCompletedSuccessfully)
    //                 {
    //                     func();
    //                 }
    //             }, TaskScheduler.Default);
    //     };
    // }
    
    // private void InputScreen_TextChanged(object sender, TextChangedEventArgs e)
    // {
    //     TextBox textBox = (TextBox)sender;
    //     Console.WriteLine(textBox);
    // }
}