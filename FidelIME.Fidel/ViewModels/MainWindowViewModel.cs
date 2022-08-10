using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Threading;
using FidelIME.Fidel.Views;
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
        private MainWindow view;
        #endregion

        #region Properties
        public StackPanel SuggestionGrid { get => grid; set => this.RaiseAndSetIfChanged(ref grid, value); }
        public string FidelChangeBtn { get => fidelBtn; set => this.RaiseAndSetIfChanged(ref fidelBtn, value); }
        public string HelpBtn { get => helpBtn; set => this.RaiseAndSetIfChanged(ref helpBtn, value); }

        public MainWindow View { get=>view; set=>this.RaiseAndSetIfChanged(ref view,value); }
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
                SuggestionGrid.Children.Clear();
                keyboardManager.StopHook();
                View.Width = 150;
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
                var datas = list.Where(x => x.StartsWith(input)).ToList().Take(5).OrderByDescending(x=>x.StartsWith(input));
                SuggestionGrid.Children.Clear();
                foreach (var data in datas)
                {
                    Button suggestedWordBtn = new Button();
                    suggestedWordBtn.FontSize = 25;
                    suggestedWordBtn.Foreground = Brushes.LightGoldenrodYellow;
                    suggestedWordBtn.Content = $"{data}";
                    suggestedWordBtn.Margin = new Thickness(5,0,5,0);
                    suggestedWordBtn.PointerEnter += SuggestedWordBtn_PointerEnter;
                    suggestedWordBtn.PointerLeave += SuggestedWordBtn_PointerLeave;
                    suggestedWordBtn.Click += SuggestedWordBtn_Click;
                    SuggestionGrid.HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center;
                    SuggestionGrid.Children.Add(suggestedWordBtn);
                }
                View.Width = 771.21;
            });
            
        }

        private void SuggestedWordBtn_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            var btn = sender as Button;
            keyboardManager.Replace(btn?.Content.ToString());
        }

        private void SuggestedWordBtn_PointerLeave(object? sender, PointerEventArgs e)
        {
            var btn = sender as Button;
            btn.Foreground = Brushes.LightGoldenrodYellow;
        }

        private void SuggestedWordBtn_PointerEnter(object? sender, PointerEventArgs e)
        {
            var btn = sender as Button;
            btn.Opacity = 1;
            btn.Foreground = Brushes.Yellow;
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
