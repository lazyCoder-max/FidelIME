using FidelIME.Plugin.IME.Interfaces;
using System.Collections.Generic;
using System.Timers;

namespace FidelIME.Plugin.IME
{
    /// <summary>
    /// 
    /// </summary>
    public class InputEditor : IInputEditor
    {
        /// <summary>
        /// Get and set input Character
        /// </summary>
        public List<string> InputCharacter { get; set; }
        private Timer _timer;

        public InputEditor()
        {
            InputCharacter = new List<string>();
            _timer = new Timer(3000);
            _timer.Elapsed += TimerOnElapsed;
            _timer.Start();
        }

        private void TimerOnElapsed(object? sender, ElapsedEventArgs e)
        {
            // Reset input characters to default value
            InputCharacter.Clear();
        }


        /// <summary>
        /// Check if the character counter is on the first index
        /// </summary>
        public bool IsFirstCharacter
        {
            get
            {
                if (InputCharacter.Count <= 1)
                    return true;
                return false;
            }
        }
    }
}