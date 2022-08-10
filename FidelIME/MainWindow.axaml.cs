using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Media.Imaging;
using FidelIME.Plugin.InputManager;
using System.IO;

namespace FidelIME
{
    public partial class MainWindow : Window
    {
        private static bool IsAmharic = false;
        IKeyboardManager keyboardManager = new KeyboardManager();
        public MainWindow()
        {
            InitializeComponent();
            FidelChangeBtn.Source = new Bitmap($"{Directory.GetCurrentDirectory()}/logo2.png");
            FidelChangeBtn1.Source = new Bitmap($"{Directory.GetCurrentDirectory()}/help_100px.png");
        }

        private void MainWindow_Closing(object? sender, System.ComponentModel.CancelEventArgs e)
        {
            keyboardManager.StopHook();
        }

        private async void FidelChangeBtn_OnPointerPressed(object? sender, PointerPressedEventArgs e)
        {
            this.BorderThickness = new Thickness(0, 0, 0, 0);
            if (e.ClickCount == 2)
            {
                if (IsAmharic == false)
                {
                    FidelChangeBtn.Source = new Bitmap($"{Directory.GetCurrentDirectory()}/logo.png");
                    IsAmharic = true;
                   await keyboardManager.StartHookAsync();
                }
                else
                {
                    FidelChangeBtn.Source = new Bitmap($"{Directory.GetCurrentDirectory()}/logo2.png");
                    IsAmharic = false;
                    keyboardManager.StopHook();
                }
            }
        }
        private void FidelChangeBtn1_OnPointerEnter(object? sender, PointerEventArgs e)
        {
            FidelChangeBtn1.Source = new Bitmap($"{Directory.GetCurrentDirectory()}/help_1002px.png");
        }
        private void FidelChangeBtn1_OnPointerLeave(object? sender, PointerEventArgs e)
        {
            FidelChangeBtn1.Source = new Bitmap($"{Directory.GetCurrentDirectory()}/help_100px.png");
        }
    }
}