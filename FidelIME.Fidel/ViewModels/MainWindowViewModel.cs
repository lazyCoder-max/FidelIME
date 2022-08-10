using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Threading;
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
                keyboardManager.KeyboardTyped += KeyboardManager_KeyboardTyped;
                keyboardManager.WordCreated += KeyboardManager_WordCreated;
                await keyboardManager.StartHookAsync();
            }
            else
            {
                FidelChangeBtn = $"{Directory.GetCurrentDirectory()}/Assets/logo2.png";
                IsAmharic = false;
                keyboardManager.KeyboardTyped -= KeyboardManager_KeyboardTyped;
                keyboardManager.StopHook();
            }
        }

        private async void KeyboardManager_WordCreated(object? sender, string e)
        {
            await SaveSuggestionAsync(e);
        }

        private async void KeyboardManager_KeyboardTyped(object? sender, string e)
        {
            await SuggestWordAsync(e);
        }

        public async Task SuggestWordAsync(string input)
        {
            await Dispatcher.UIThread.InvokeAsync(() =>
            {
                var datas = list.Where(x => x.Contains(input)).ToList().Take(5).OrderByDescending(x=>x.StartsWith(input));
                SuggestionGrid.Children.Clear();
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
        private async Task SaveSuggestionAsync(string word)
        {
            await Dispatcher.UIThread.InvokeAsync(() =>
            {
                var path = $@"{Directory.GetCurrentDirectory()}/Assets/AmharicWordListSortedSimplified.txt";
                var data = list.Where(x => x.Equals(word)).ToList();
                if (data.Count == 0)
                {
                    using (StreamWriter writer = new StreamWriter(path: path, true, Encoding.UTF8))
                    {
                        writer.WriteLine(word);
                    }
                    list = File.ReadLines($@"{Directory.GetCurrentDirectory()}/Assets/AmharicWordListSortedSimplified.txt", Encoding.UTF8).Distinct().ToList();
                }
            });

        }
    }
    #endregion
}
