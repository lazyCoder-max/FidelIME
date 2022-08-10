using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using FidelIME.Plugin.InputManager;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FidelIME.Fidel.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        #region Fields
        private static bool IsAmharic = false;
        IKeyboardManager keyboardManager = new KeyboardManager();
        private string fidelBtn = $"{Directory.GetCurrentDirectory()}/Assets/logo2.png";
        private string helpBtn = $"{Directory.GetCurrentDirectory()}/Assets/help_100px.png";
        private List<string> list = new List<string>();
        private StackPanel grid;
        #endregion

        #region Properties
        public StackPanel SuggestionGrid { get => grid; set => this.RaiseAndSetIfChanged(ref grid, value); }
        public string FidelChangeBtn { get => fidelBtn; set => this.RaiseAndSetIfChanged(ref fidelBtn, value); }
        public string HelpBtn { get => helpBtn; set => this.RaiseAndSetIfChanged(ref helpBtn, value); }
        
        #endregion

        #region Methods
        public void Initiallise(Image fidelChangeBtn, Image helpBtn)
        {
            FidelChangeBtn = $"{Directory.GetCurrentDirectory()}/Assets/logo2.png";
            HelpBtn = $"{Directory.GetCurrentDirectory()}/Assets/help_100px.png";
            list =  File.ReadLines($@"{Directory.GetCurrentDirectory()}/Assets/AmharicWordListSortedSimplified.txt", Encoding.UTF8).Distinct().ToList();
        }

        public void ChangeImage(bool isEnter = true)
        {
            switch (isEnter)
            {
                case true:
                    HelpBtn = $"{Directory.GetCurrentDirectory()}/Assets/help_1002px.png";
                    break;
                case false:
                    HelpBtn = $"{Directory.GetCurrentDirectory()}/Assets/help_100px.png";
                    break;
            }
        }
        public void Dispose()
        {
            keyboardManager.StopHook();
        }
        public async Task ChangeLanguageAsync()
        {
            if (IsAmharic == false)
            {
                FidelChangeBtn = $"{Directory.GetCurrentDirectory()}/Assets/logo.png";
                IsAmharic = true;
                await keyboardManager.StartHookAsync();
                keyboardManager.KeyboardTyped += KeyboardManager_KeyboardTyped;
            }
            else
            {
                FidelChangeBtn = $"{Directory.GetCurrentDirectory()}/Assets/logo2.png";
                IsAmharic = false;
                keyboardManager.StopHook();
            }
        }

        private async void KeyboardManager_KeyboardTyped(object? sender, string e)
        {
            await SuggestWordAsync(e);
        }

        public async Task SuggestWordAsync(string input)
        {
            await Task.Factory.StartNew(() =>
            {
                var datas = list.Where(x => x.Contains(input)).ToList().Take(6);
                foreach (var data in datas)
                {
                    TextBlock textBlock = new TextBlock();
                    textBlock.Foreground = Brushes.White;
                    textBlock.FontSize = 25;
                    textBlock.Text = $"{data} ";
                    SuggestionGrid.HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center;
                    SuggestionGrid.Children.Add(textBlock);
                }
            });
        }
    }
    #endregion
}
