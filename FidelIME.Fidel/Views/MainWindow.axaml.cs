using Avalonia.Controls;
using Avalonia.Input;
using FidelIME.Fidel.ViewModels;

namespace FidelIME.Fidel.Views
{
    public partial class MainWindow : Window
    {
        private MainWindowViewModel ViewModel;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void FidelChangeBtn1_PointerPressed(object? sender, PointerPressedEventArgs e)
        {
            ViewModel?.OpenUserGuide();   
        }

        private void MainWindow_Closing(object? sender, System.ComponentModel.CancelEventArgs e)
        {
            ViewModel?.Dispose();
        }

        private async void FidelChangeBtn_PointerPressed(object? sender, PointerPressedEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                await ViewModel?.ChangeLanguageAsync();
            }
        }

        private void MainWindow_Opened(object? sender, System.EventArgs e)
        {

            ViewModel = this.DataContext as MainWindowViewModel;
            ViewModel?.Initiallise(FidelChangeBtn, FidelChangeBtn1);
            ViewModel.SuggestionGrid = sv;
            ViewModel.View = this;
        }

        private void FidelChangeBtn1_OnPointerEnter(object? sender, PointerEventArgs e)
        {
            ViewModel?.ChangeImage();
        }
        private void FidelChangeBtn1_OnPointerLeave(object? sender, PointerEventArgs e)
        {
            ViewModel?.ChangeImage(false);
        }

    }
}
