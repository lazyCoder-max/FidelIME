using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using FidelIME.Plugin.InputManager;
using ReactiveUI;
using System.IO;
using System.Threading.Tasks;

namespace FidelIME.Fidel.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private static bool IsAmharic = false;
        IKeyboardManager keyboardManager = new KeyboardManager();
        private string fidelBtn = $"";
        private string helpBtn  = $"";
        public string FidelChangeBtn { get =>fidelBtn; set=> this.RaiseAndSetIfChanged(ref fidelBtn, value); }
        public string HelpBtn { get => helpBtn; set => this.RaiseAndSetIfChanged(ref helpBtn, value); }
        public void Initiallise(Image fidelChangeBtn, Image helpBtn)
        {
            FidelChangeBtn = $"{Directory.GetCurrentDirectory()}/Assets/logo2.png";
            HelpBtn = $"{Directory.GetCurrentDirectory()}/Assets/help_100px.png";
        }

        public void ChangeImage(bool isEnter=true)
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

        public async Task ChangeLanguageAsync()
        {
            if (IsAmharic == false)
            {
                FidelChangeBtn = $"{Directory.GetCurrentDirectory()}/Assets/logo.png";
                IsAmharic = true;
                await keyboardManager.StartHookAsync();
            }
            else
            {
                FidelChangeBtn = $"{Directory.GetCurrentDirectory()}/Assets/logo2.png";
                IsAmharic = false;
                keyboardManager.StopHook();
            }
        }
    }
}
