using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System;
using Avalonia.Interactivity;

namespace CalculatorQuest;

public partial class CalculatorScreen : Window
{
    public string CurrentInput = "";
    public string FirstInput = "";
    public string Operand = "";

    
    public CalculatorScreen()
    {
        this.Width = 300;
        this.Height = 600;
        InitializeComponent();
    }
    

    private void Number_OnClick(object? sender, RoutedEventArgs e)
    {
     Button? btn = (Button)sender!;
     CurrentInput += btn.Content?.ToString();
     NumbersBox.Content = CurrentInput;
    }
    
    private void Operator_OnClick(object? sender, RoutedEventArgs e)
    {
        Button? btn = (Button)sender!;
        FirstInput = CurrentInput;
        SavedNumber.Content = FirstInput;
        CurrentInput = "";
        NumbersBox.Content = CurrentInput;

        if (btn == More)
        {
            OperatorBox.Content = "+";
        }
        else if (btn == Less)
        {
            OperatorBox.Content = "-";
        }
        else if (btn == Multiply)
        {
            OperatorBox.Content = "x";
        }
        else if (btn == Divide)
        {
            OperatorBox.Content = "/";
        }
        else if (btn == Mod)
        {
            OperatorBox.Content = "%";
        }
        else if (btn == Sign)
        {
            OperatorBox.Content = "+/-";
        }
    }

    private void C_Button_Click(object sender, RoutedEventArgs e)
    {
        CurrentInput = "";
        SavedNumber.Content = "";
        NumbersBox.Content = CurrentInput;
    }
    private void EqualButton_Click(object sender, RoutedEventArgs e)
    {
        Calc c = new Calc();
        string operatorContent = OperatorBox.Content.ToString(); 

        if (!string.IsNullOrEmpty(operatorContent))
        {
    
            string expression = FirstInput + operatorContent + CurrentInput;

           
            string result = c.Operator(expression);
            
            SavedNumber.Content = result.ToString();
            CurrentInput = result.ToString();
            NumbersBox.Content = "";
            OperatorBox.Content = "";
        }
    }
    
    private void Control_OnClick(object? sender, RoutedEventArgs e)
    {
        
        Button? btn = (Button)sender!;
        CurrentInput += btn.Content?.ToString();
        if (btn  == ClearAll)
        {
            CurrentInput = "";
            NumbersBox.Content = CurrentInput;
        }
        else if (btn == Del)
        {
            var size = CurrentInput.Length;
            CurrentInput = CurrentInput.Remove(size - 2);
            NumbersBox.Content = CurrentInput;

        }
       
    }
}