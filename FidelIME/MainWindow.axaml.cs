using System;
using System.IO;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Media;
using Avalonia.Media.Imaging;

namespace FidelIME
{
    public partial class MainWindow : Window
    {
        private static bool IsAmharic = false;
        private IKeyboardManager keyboard = new InputManager.KeyboardManager();
        public MainWindow()
        {
            InitializeComponent();
            FidelChangeBtn.Source = new Bitmap($"{Directory.GetCurrentDirectory()}/logo2.png");
        }

        private void FidelChangeBtn_OnPointerPressed(object? sender, PointerPressedEventArgs e)
        {
            this.BorderThickness = new Thickness(0, 0, 0, 0);
            if (e.ClickCount == 2)
            {
                if (IsAmharic == false)
                {
                    FidelChangeBtn.Source = new Bitmap($"{Directory.GetCurrentDirectory()}/logo.png");
                    IsAmharic = true;
                    keyboard.StartKeyboardListener();
                }
                else
                {
                    FidelChangeBtn.Source = new Bitmap($"{Directory.GetCurrentDirectory()}/logo2.png");
                    IsAmharic = false;
                    keyboard.DisposeKeyboardListener();
                }
            }
        }
    }
}