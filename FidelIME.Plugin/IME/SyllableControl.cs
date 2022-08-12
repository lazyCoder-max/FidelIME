using FidelIME.Plugin.IME.Enum;
using FidelIME.Plugin.IME.Interfaces;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace FidelIME.Plugin.IME
{
    /// <summary>
    /// Provides Syllable Control of Ethiopic Letters
    /// </summary>
    public class SyllableControl : ISyllableControl
    {
        private char[] inputManager = new char[5];
        private int inputPointer = 0;

        public bool IsPerformClean { get; set; }
        public NumberContol NumberControl { get; set; }
        public MarksControl MarksControl { get; set; }

        /// <summary>
        /// Constractor
        /// </summary>
        /// <param name="editor"></param>
        public SyllableControl()
        {
            NumberControl = new NumberContol();
            MarksControl = new MarksControl();
        }
        public bool IsNumber(char value)
        {
            if (char.IsNumber(value))
                return true;
            return false;
        }

        /// <summary>
        /// check if input value is vowel
        /// </summary>
        /// <param name="value"></param>
        /// <returns><see cref="bool"/></returns>
        public bool IsVowel(char value)
        {
            if (value == 'a' || value == 'e' || value == 'i' || value == 'o' || value == 'u')
                return true;
            return false;
        }
        /// <summary>
        /// Returns Ethiopic vowel value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private string? GetEthiopicVowel(string value)
        {
            switch (value)
            {
                case "a":
                    return "ኣ";
                case "A":
                    return "እ";
                case "e":
                    return "አ";
                case "ie":
                    return "ኤ";
                case "i":
                    return "ኢ";
                case "o":
                    return "ኦ";
                case "u":
                    return "ኡ";
                case "U":
                    return "ኡ";
            }
            return null;
        }

        /// <summary>
        /// Returns Ethiopic syllables
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string GetSyllable(string value)
        {
            string result = $"";
            switch (value)
            {
                case "he":
                    result = $"{Syllables.ሀ}";
                    break;
                case "hu":
                    result = $"{Syllables.ሁ}";
                    break;
                case "hi":
                    result = $"{Syllables.ሂ}";
                    break;
                case "ha":
                    result = $"{Syllables.ሃ}";
                    break;
                case "hie":
                    result = $"{Syllables.ሄ}";
                    break;
                case "h":
                    result = $"{Syllables.ህ}";
                    break;
                case "ho":
                    result = $"{Syllables.ሆ}";
                    break;
                case "le":
                    result = $"{Syllables.ለ}";
                    break;
                case "lu":
                    result = $"{Syllables.ሉ}";
                    break;
                case "li":
                    result = $"{Syllables.ሊ}";
                    break;
                case "la":
                    result = $"{Syllables.ላ}";
                    break;
                case "lie":
                    result = $"{Syllables.ሌ}";
                    break;
                case "l":
                    result = $"{Syllables.ል}";
                    break;
                case "lo":
                    result = $"{Syllables.ሎ}";
                    break;
                case "He":
                    result = $"{Syllables.ሐ}";
                    break;
                case "Hu":
                    result = $"{Syllables.ሑ}";
                    break;
                case "Hi":
                    result = $"{Syllables.ሒ}";
                    break;
                case "Ha":
                    result = $"{Syllables.ሓ}";
                    break;
                case "Hie":
                    result = $"{Syllables.ሔ}";
                    break;
                case "H":
                    result = $"{Syllables.ሕ}";
                    break;
                case "Ho":
                    result = $"{Syllables.ሖ}";
                    break;
                case "me":
                    result = $"{Syllables.መ}";
                    break;
                case "mu":
                    result = $"{Syllables.ሙ}";
                    break;
                case "mi":
                    result = $"{Syllables.ሚ}";
                    break;
                case "ma":
                    result = $"{Syllables.ማ}";
                    break;
                case "mie":
                    result = $"{Syllables.ሜ}";
                    break;
                case "m":
                    result = $"{Syllables.ም}";
                    break;
                case "mo":
                    result = $"{Syllables.ሞ}";
                    break;
                case "s2e":
                    result = $"{Syllables.ሠ}";
                    break;
                case "s2u":
                    result = $"{Syllables.ሡ}";
                    break;
                case "s2i":
                    result = $"{Syllables.ሢ}";
                    break;
                case "s2a":
                    result = $"{Syllables.ሣ}";
                    break;
                case "s2ie":
                    result = $"{Syllables.ሤ}";
                    break;
                case "s2":
                    result = $"{Syllables.ሥ}";
                    break;
                case "s2o":
                    result = $"{Syllables.ሦ}";
                    break;
                case "re":
                    result = $"{Syllables.ረ}";
                    break;
                case "ru":
                    result = $"{Syllables.ሩ}";
                    break;
                case "ri":
                    result = $"{Syllables.ሪ}";
                    break;
                case "ra":
                    result = $"{Syllables.ራ}";
                    break;
                case "rie":
                    result = $"{Syllables.ሬ}";
                    break;
                case "r":
                    result = $"{Syllables.ር}";
                    break;
                case "ro":
                    result = $"{Syllables.ሮ}";
                    break;
                case "se":
                    result = $"{Syllables.ሰ}";
                    break;
                case "su":
                    result = $"{Syllables.ሱ}";
                    break;
                case "si":
                    result = $"{Syllables.ሲ}";
                    break;
                case "sa":
                    result = $"{Syllables.ሳ}";
                    break;
                case "sie":
                    result = $"{Syllables.ሴ}";
                    break;
                case "s":
                    result = $"{Syllables.ስ}";
                    break;
                case "so":
                    result = $"{Syllables.ሶ}";
                    break;
                case "qe":
                    result = $"{Syllables.ቀ}";
                    break;
                case "qu":
                    result = $"{Syllables.ቁ}";
                    break;
                case "qi":
                    result = $"{Syllables.ቂ}";
                    break;
                case "qa":
                    result = $"{Syllables.ቃ}";
                    break;
                case "qie":
                    result = $"{Syllables.ቄ}";
                    break;
                case "q":
                    result = $"{Syllables.ቅ}";
                    break;
                case "qo":
                    result = $"{Syllables.ቆ}";
                    break;
                case "be":
                    result = $"{Syllables.በ}";
                    break;
                case "bu":
                    result = $"{Syllables.ቡ}";
                    break;
                case "bi":
                    result = $"{Syllables.ቢ}";
                    break;
                case "ba":
                    result = $"{Syllables.ባ}";
                    break;
                case "bie":
                    result = $"{Syllables.ቤ}";
                    break;
                case "b":
                    result = $"{Syllables.ብ}";
                    break;
                case "bo":
                    result = $"{Syllables.ቦ}";
                    break;
                case "ve":
                    result = $"{Syllables.ቨ}";
                    break;
                case "vu":
                    result = $"{Syllables.ቩ}";
                    break;
                case "vi":
                    result = $"{Syllables.ቪ}";
                    break;
                case "va":
                    result = $"{Syllables.ቫ}";
                    break;
                case "vie":
                    result = $"{Syllables.ቬ}";
                    break;
                case "v":
                    result = $"{Syllables.ቭ}";
                    break;
                case "vo":
                    result = $"{Syllables.ቮ}";
                    break;
                case "te":
                    result = $"{Syllables.ተ}";
                    break;
                case "tu":
                    result = $"{Syllables.ቱ}";
                    break;
                case "ti":
                    result = $"{Syllables.ቲ}";
                    break;
                case "ta":
                    result = $"{Syllables.ታ}";
                    break;
                case "tie":
                    result = $"{Syllables.ቴ}";
                    break;
                case "t":
                    result = $"{Syllables.ት}";
                    break;
                case "to":
                    result = $"{Syllables.ቶ}";
                    break;
                case "ce":
                    result = $"{Syllables.ቸ}";
                    break;
                case "cu":
                    result = $"{Syllables.ቹ}";
                    break;
                case "ci":
                    result = $"{Syllables.ቺ}";
                    break;
                case "ca":
                    result = $"{Syllables.ቻ}";
                    break;
                case "cie":
                    result = $"{Syllables.ቼ}";
                    break;
                case "c":
                    result = $"{Syllables.ች}";
                    break;
                case "co":
                    result = $"{Syllables.ቾ}";
                    break;
                case "T2e":
                    result = $"{Syllables.ጠ}";
                    break;
                case "T2u":
                    result = $"{Syllables.ጡ}";
                    break;
                case "T2i":
                    result = $"{Syllables.ጢ}";
                    break;
                case "T2a":
                    result = $"{Syllables.ጣ}";
                    break;
                case "T2ei":
                    result = $"{Syllables.ጤ}";
                    break;
                case "T2":
                    result = $"{Syllables.ጥ}";
                    break;
                case "T2o":
                    result = $"{Syllables.ጦ}";
                    break;
                case "h2e":
                    result = $"{Syllables.ኀ}";
                    break;
                case "h2u":
                    result = $"{Syllables.ኁ}";
                    break;
                case "h2i":
                    result = $"{Syllables.ኂ}";
                    break;
                case "h2a":
                    result = $"{Syllables.ኃ}";
                    break;
                case "h2ie":
                    result = $"{Syllables.ኄ}";
                    break;
                case "h2":
                    result = $"{Syllables.ኅ}";
                    break;
                case "h2o":
                    result = $"{Syllables.ኆ}";
                    break;
                case "ne":
                    result = $"{Syllables.ነ}";
                    break;
                case "nu":
                    result = $"{Syllables.ኑ}";
                    break;
                case "ni":
                    result = $"{Syllables.ኒ}";
                    break;
                case "na":
                    result = $"{Syllables.ና}";
                    break;
                case "nie":
                    result = $"{Syllables.ኔ}";
                    break;
                case "n":
                    result = $"{Syllables.ን}";
                    break;
                case "no":
                    result = $"{Syllables.ኖ}";
                    break;
                case "Ne":
                    result = $"{Syllables.ኘ}";
                    break;
                case "Nu":
                    result = $"{Syllables.ኙ}";
                    break;
                case "Ni":
                    result = $"{Syllables.ኚ}";
                    break;
                case "Na":
                    result = $"{Syllables.ኛ}";
                    break;
                case "Nie":
                    result = $"{Syllables.ኜ}";
                    break;
                case "N":
                    result = $"{Syllables.ኝ}";
                    break;
                case "No":
                    result = $"{Syllables.ኞ}";
                    break;
                case "ke":
                    result = $"{Syllables.ከ}";
                    break;
                case "ku":
                    result = $"{Syllables.ኩ}";
                    break;
                case "ki":
                    result = $"{Syllables.ኪ}";
                    break;
                case "ka":
                    result = $"{Syllables.ካ}";
                    break;
                case "kie":
                    result = $"{Syllables.ኬ}";
                    break;
                case "k":
                    result = $"{Syllables.ክ}";
                    break;
                case "ko":
                    result = $"{Syllables.ኮ}";
                    break;
                case "Ke":
                    result = $"{Syllables.ኸ}";
                    break;
                case "Ku":
                    result = $"{Syllables.ኹ}";
                    break;
                case "Ki":
                    result = $"{Syllables.ኺ}";
                    break;
                case "Ka":
                    result = $"{Syllables.ኻ}";
                    break;
                case "Kie":
                    result = $"{Syllables.ኼ}";
                    break;
                case "K":
                    result = $"{Syllables.ኽ}";
                    break;
                case "Ko":
                    result = $"{Syllables.ኾ}";
                    break;
                case "we":
                    result = $"{Syllables.ወ}";
                    break;
                case "wu":
                    result = $"{Syllables.ዉ}";
                    break;
                case "wi":
                    result = $"{Syllables.ዊ}";
                    break;
                case "wa":
                    result = $"{Syllables.ዋ}";
                    break;
                case "wie":
                    result = $"{Syllables.ዌ}";
                    break;
                case "w":
                    result = $"{Syllables.ው}";
                    break;
                case "wo":
                    result = $"{Syllables.ዎ}";
                    break;
                case "e":
                    result = $"{Syllables.ዐ}";
                    break;
                case "u2":
                    result = $"{Syllables.ዑ}";
                    break;
                case "i2":
                    result = $"{Syllables.ዒ}";
                    break;
                case "a2":
                    result = $"{Syllables.ዓ}";
                    break;
                case "ie2":
                    result = $"{Syllables.ዔ}";
                    break;
                case "A2":
                    result = $"{Syllables.ዕ}";
                    break;
                case "O2":
                    result = $"{Syllables.ዖ}";
                    break;
                case "ze":
                    result = $"{Syllables.ዘ}";
                    break;
                case "zu":
                    result = $"{Syllables.ዙ}";
                    break;
                case "zi":
                    result = $"{Syllables.ዚ}";
                    break;
                case "za":
                    result = $"{Syllables.ዛ}";
                    break;
                case "zie":
                    result = $"{Syllables.ዜ}";
                    break;
                case "z":
                    result = $"{Syllables.ዝ}";
                    break;
                case "zo":
                    result = $"{Syllables.ዞ}";
                    break;
                case "Ze":
                    result = $"{Syllables.ዠ}";
                    break;
                case "Zu":
                    result = $"{Syllables.ዡ}";
                    break;
                case "Zi":
                    result = $"{Syllables.ዢ}";
                    break;
                case "Za":
                    result = $"{Syllables.ዣ}";
                    break;
                case "Zie":
                    result = $"{Syllables.ዤ}";
                    break;
                case "Z":
                    result = $"{Syllables.ዥ}";
                    break;
                case "Zo":
                    result = $"{Syllables.ዦ}";
                    break;
                case "ye":
                    result = $"{Syllables.የ}";
                    break;
                case "yu":
                    result = $"{Syllables.ዩ}";
                    break;
                case "yi":
                    result = $"{Syllables.ዪ}";
                    break;
                case "ya":
                    result = $"{Syllables.ያ}";
                    break;
                case "yie":
                    result = $"{Syllables.ዬ}";
                    break;
                case "y":
                    result = $"{Syllables.ይ}";
                    break;
                case "yo":
                    result = $"{Syllables.ዮ}";
                    break;
                case "de":
                    result = $"{Syllables.ደ}";
                    break;
                case "du":
                    result = $"{Syllables.ዱ}";
                    break;
                case "di":
                    result = $"{Syllables.ዲ}";
                    break;
                case "da":
                    result = $"{Syllables.ዳ}";
                    break;
                case "die":
                    result = $"{Syllables.ዴ}";
                    break;
                case "d":
                    result = $"{Syllables.ድ}";
                    break;
                case "do":
                    result = $"{Syllables.ዶ}";
                    break;
                case "De":
                    result = $"{Syllables.ዸ}";
                    break;
                case "Du":
                    result = $"{Syllables.ዹ}";
                    break;
                case "Di":
                    result = $"{Syllables.ዺ}";
                    break;
                case "Da":
                    result = $"{Syllables.ዻ}";
                    break;
                case "Die":
                    result = $"{Syllables.ዼ}";
                    break;
                case "D":
                    result = $"{Syllables.ዽ}";
                    break;
                case "Do":
                    result = $"{Syllables.ዾ}";
                    break;
                case "je":
                    result = $"{Syllables.ጀ}";
                    break;
                case "ju":
                    result = $"{Syllables.ጁ}";
                    break;
                case "ji":
                    result = $"{Syllables.ጂ}";
                    break;
                case "ja":
                    result = $"{Syllables.ጃ}";
                    break;
                case "jie":
                    result = $"{Syllables.ጄ}";
                    break;
                case "j":
                    result = $"{Syllables.ጅ}";
                    break;
                case "jo":
                    result = $"{Syllables.ጆ}";
                    break;
                case "ge":
                    result = $"{Syllables.ገ}";
                    break;
                case "gu":
                    result = $"{Syllables.ጉ}";
                    break;
                case "gi":
                    result = $"{Syllables.ጊ}";
                    break;
                case "ga":
                    result = $"{Syllables.ጋ}";
                    break;
                case "gie":
                    result = $"{Syllables.ጌ}";
                    break;
                case "g":
                    result = $"{Syllables.ግ}";
                    break;
                case "go":
                    result = $"{Syllables.ጎ}";
                    break;
                case "Too":
                    result = $"{Syllables.ቶ}";
                    break;
                case "Ce":
                    result = $"{Syllables.ጨ}";
                    break;
                case "Cu":
                    result = $"{Syllables.ጩ}";
                    break;
                case "Ci":
                    result = $"{Syllables.ጪ}";
                    break;
                case "Ca":
                    result = $"{Syllables.ጫ}";
                    break;
                case "Cie":
                    result = $"{Syllables.ጬ}";
                    break;
                case "C":
                    result = $"{Syllables.ጭ}";
                    break;
                case "Co":
                    result = $"{Syllables.ጮ}";
                    break;
                case "Pe":
                    result = $"{Syllables.ጰ}";
                    break;
                case "Pu":
                    result = $"{Syllables.ጱ}";
                    break;
                case "Pi":
                    result = $"{Syllables.ጲ}";
                    break;
                case "Pa":
                    result = $"{Syllables.ጳ}";
                    break;
                case "Pie":
                    result = $"{Syllables.ጴ}";
                    break;
                case "P":
                    result = $"{Syllables.ጵ}";
                    break;
                case "Po":
                    result = $"{Syllables.ጶ}";
                    break;
                case "xe":
                    result = $"{Syllables.ፀ}";
                    break;
                case "xu":
                    result = $"{Syllables.ፁ}";
                    break;
                case "xi":
                    result = $"{Syllables.ፂ}";
                    break;
                case "xa":
                    result = $"{Syllables.ፃ}";
                    break;
                case "xie":
                    result = $"{Syllables.ፄ}";
                    break;
                case "x":
                    result = $"{Syllables.ፅ}";
                    break;
                case "xo":
                    result = $"{Syllables.ፆ}";
                    break;
                case "x2e":
                    result = $"{Syllables.ጸ}";
                    break;
                case "x2u":
                    result = $"{Syllables.ጹ}";
                    break;
                case "x2i":
                    result = $"{Syllables.ጺ}";
                    break;
                case "x2a":
                    result = $"{Syllables.ጻ}";
                    break;
                case "x2ie":
                    result = $"{Syllables.ጼ}";
                    break;
                case "x2":
                    result = $"{Syllables.ጽ}";
                    break;
                case "Se":
                    result = $"{Syllables.ሸ}";
                    break;
                case "Su":
                    result = $"{Syllables.ሹ}";
                    break;
                case "Si":
                    result = $"{Syllables.ሺ}";
                    break;
                case "Sa":
                    result = $"{Syllables.ሻ}";
                    break;
                case "Sie":
                    result = $"{Syllables.ሼ}";
                    break;
                case "S":
                    result = $"{Syllables.ሽ}";
                    break;
                case "Swa":
                    result = $"{Syllables.ሿ}";
                    break;
                case "So":
                    result = $"{Syllables.ሾ}";
                    break;
                case "fe":
                    result = $"{Syllables.ፈ}";
                    break;
                case "fu":
                    result = $"{Syllables.ፉ}";
                    break;
                case "fi":
                    result = $"{Syllables.ፊ}";
                    break;
                case "fa":
                    result = $"{Syllables.ፋ}";
                    break;
                case "fie":
                    result = $"{Syllables.ፌ}";
                    break;
                case "f":
                    result = $"{Syllables.ፍ}";
                    break;
                case "fo":
                    result = $"{Syllables.ፎ}";
                    break;
                case "pe":
                    result = $"{Syllables.ፐ}";
                    break;
                case "pu":
                    result = $"{Syllables.ፑ}";
                    break;
                case "pi":
                    result = $"{Syllables.ፒ}";
                    break;
                case "pa":
                    result = $"{Syllables.ፓ}";
                    break;
                case "pie":
                    result = $"{Syllables.ፔ}";
                    break;
                case "p":
                    result = $"{Syllables.ፕ}";
                    break;
                case "po":
                    result = $"{Syllables.ፖ}";
                    break;
                case "hoa":
                    result = $"{Syllables.ሇ}";
                    break;
                case "lua":
                    result = $"{Syllables.ሏ}";
                    break;
                case "Hua":
                    result = $"{Syllables.ሗ}";
                    break;
                case "mua":
                    result = $"{Syllables.ሟ}";
                    break;
                case "s2ua":
                    result = $"{Syllables.ሧ}";
                    break;
                case "rua":
                    result = $"{Syllables.ሯ}";
                    break;
                case "sua":
                    result = $"{Syllables.ሷ}";
                    break;
                case "Sua":
                    result = $"{Syllables.ሿ}";
                    break;
                case "qoa":
                    result = $"{Syllables.ቇ}";
                    break;
                case "qwu":
                    result = $"{Syllables.ቈ}";
                    break;
                case "qwi":
                    result = $"{Syllables.ቊ}";
                    break;
                case "qua":
                    result = $"{Syllables.ቋ}";
                    break;
                case "qwie":
                    result = $"{Syllables.ቌ}";
                    break;
                case "qw":
                    result = $"{Syllables.ቍ}";
                    break;
                case "Qe":
                    result = $"{Syllables.ቐ}";
                    break;
                case "Qu":
                    result = $"{Syllables.ቑ}";
                    break;
                case "Qi":
                    result = $"{Syllables.ቒ}";
                    break;
                case "Qa":
                    result = $"{Syllables.ቓ}";
                    break;
                case "Qie":
                    result = $"{Syllables.ቔ}";
                    break;
                case "Q":
                    result = $"{Syllables.ቕ}";
                    break;
                case "Qo":
                    result = $"{Syllables.ቖ}";
                    break;
                case "Qwe":
                    result = $"{Syllables.ቘ}";
                    break;
                case "Qwu":
                    result = $"{Syllables.ቚ}";
                    break;
                case "Qwa":
                    result = $"{Syllables.ቛ}";
                    break;
                case "Qwie":
                    result = $"{Syllables.ቜ}";
                    break;
                case "Qw":
                    result = $"{Syllables.ቝ}";
                    break;
                case "bua":
                    result = $"{Syllables.ቧ}";
                    break;
                case "vua":
                    result = $"{Syllables.ቯ}";
                    break;
                case "tua":
                    result = $"{Syllables.ቷ}";
                    break;
                case "Tua":
                    result = $"{Syllables.ጧ}";
                    break;
                case "Cua":
                    result = $"{Syllables.ጯ}";
                    break;
                case "h2ua":
                    result = $"{Syllables.ኇ}";
                    break;
                case "h2we":
                    result = $"{Syllables.ኈ}";
                    break;
                case "h2wi":
                    result = $"{Syllables.ኊ}";
                    break;
                case "h2wa":
                    result = $"{Syllables.ኋ}";
                    break;
                case "h2wie":
                    result = $"{Syllables.ኌ}";
                    break;
                case "h2w":
                    result = $"{Syllables.ኍ}";
                    break;
                case "nua":
                    result = $"{Syllables.ኗ}";
                    break;
                case "Nua":
                    result = $"{Syllables.ኟ}";
                    break;
                case "Te":
                    result = $"{Syllables.ጠ}";
                    break;
                case "Tu":
                    result = $"{Syllables.ጡ}";
                    break;
                case "Ti":
                    result = $"{Syllables.ጢ}";
                    break;
                case "Ta":
                    result = $"{Syllables.ጣ}";
                    break;
                case "Tie":
                    result = $"{Syllables.ጤ}";
                    break;
                case "T":
                    result = $"{Syllables.ጥ}";
                    break;
                case "To":
                    result = $"{Syllables.ጦ}";
                    break;
                case "Oe":
                    result = $"{Syllables.ዐ}";
                    break;
                case "Ou":
                    result = $"{Syllables.ዑ}";
                    break;
                case "Oi":
                    result = $"{Syllables.ዒ}";
                    break;
                case "Oa":
                    result = $"{Syllables.ዓ}";
                    break;
                case "Oie":
                    result = $"{Syllables.ዔ}";
                    break;
                case "O":
                    result = $"{Syllables.ዕ}";
                    break;
                case "Oo":
                    result = $"{Syllables.ዖ}";
                    break;
                case "ew":
                    result = $"{Syllables.ኧ}";
                    break;
                case "koa":
                    result = $"{Syllables.ኯ}";
                    break;
                case "kue":
                    result = $"{Syllables.ኰ}";
                    break;
                case "kui":
                    result = $"{Syllables.ኲ}";
                    break;
                case "kua":
                    result = $"{Syllables.ኳ}";
                    break;
                case "kuie":
                    result = $"{Syllables.ኴ}";
                    break;
                case "kuo":
                    result = $"{Syllables.ኵ}";
                    break;
                case "Kue":
                    result = $"{Syllables.ዀ}";
                    break;
                case "Kui":
                    result = $"{Syllables.ዂ}";
                    break;
                case "Kua":
                    result = $"{Syllables.ዃ}";
                    break;
                case "Kuie":
                    result = $"{Syllables.ዄ}";
                    break;
                case "Kuo":
                    result = $"{Syllables.ዅ}";
                    break;
                case "woa":
                    result = $"{Syllables.ዏ}";
                    break;
                case "zua":
                    result = $"{Syllables.ዟ}";
                    break;
                case "Zua":
                    result = $"{Syllables.ዧ}";
                    break;
                case "Yua":
                    result = $"{Syllables.ዯ}";
                    break;
                case "dua":
                    result = $"{Syllables.ዷ}";
                    break;
                case "Dua":
                    result = $"{Syllables.ዿ}";
                    break;
                case "jua":
                    result = $"{Syllables.ጇ}";
                    break;
                case "gua":
                    result = $"{Syllables.ጓ}";
                    break;
                case "goa":
                    result = $"{Syllables.ጏ}";
                    break;
                case "gue":
                    result = $"{Syllables.ጐ}";
                    break;
                case "gui":
                    result = $"{Syllables.ጒ}";
                    break;
                case "guie":
                    result = $"{Syllables.ጔ}";
                    break;
                case "gwe":
                    result = $"{Syllables.ጕ}";
                    break;
                case "Ge":
                    result = $"{Syllables.ጘ}";
                    break;
                case "Gu":
                    result = $"{Syllables.ጙ}";
                    break;
                case "Gi":
                    result = $"{Syllables.ጚ}";
                    break;
                case "Ga":
                    result = $"{Syllables.ጛ}";
                    break;
                case "Gie":
                    result = $"{Syllables.ጜ}";
                    break;
                case "G":
                    result = $"{Syllables.ጝ}";
                    break;
                case "Go":
                    result = $"{Syllables.ጞ}";
                    break;
                case "Gua":
                    result = $"{Syllables.ጟ}";
                    break;
                case "Pua":
                    result = $"{Syllables.ጷ}";
                    break;
                case "xua":
                    result = $"{Syllables.ጿ}";
                    break;
                case "X2ua":
                    result = $"{Syllables.ፇ}";
                    break;
                case "fua":
                    result = $"{Syllables.ፏ}";
                    break;
                case "pua":
                    result = $"{Syllables.ፗ}";
                    break;
                case "rwa":
                    result = $"{Syllables.ሯ}";
                    break;
                case "mwa":
                    result = $"{Syllables.ፙ}";
                    break;
                case "fwa":
                    result = $"{Syllables.ፚ}";
                    break;
                case "mw":
                    result = $"{Syllables.ᎀ}";
                    break;
                case "mwi":
                    result = $"{Syllables.ᎁ}";
                    break;
                case "mwie":
                    result = $"{Syllables.ᎂ}";
                    break;
                case "mwe":
                    result = $"{Syllables.ᎃ}";
                    break;
                case "bwe":
                    result = $"{Syllables.ᎄ}";
                    break;
                case "bwi":
                    result = $"{Syllables.ᎅ}";
                    break;
                case "bwie":
                    result = $"{Syllables.ᎆ}";
                    break;
                case "bw":
                    result = $"{Syllables.ᎇ}";
                    break;
                case "fw":
                    result = $"{Syllables.ᎈ}";
                    break;
                case "fwi":
                    result = $"{Syllables.ᎉ}";
                    break;
                case "fwo":
                    result = $"{Syllables.ᎊ}";
                    break;
                case "fwie":
                    result = $"{Syllables.ᎋ}";
                    break;
                case "pwe":
                    result = $"{Syllables.ᎌ}";
                    break;
                case "pwi":
                    result = $"{Syllables.ᎍ}";
                    break;
                case "pwie":
                    result = $"{Syllables.ᎎ}";
                    break;
                case "pw":
                    result = $"{Syllables.ᎏ}";
                    break;
                default:
                    break;
            }
            return result;
        }

        /// <summary>
        /// Convert character to Ethiopic value
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public string ToEthiopic(string[] values)
        {
            Contract.Requires(values != null);
            Contract.Requires(values.Length <= 5);
            string result = null;
            foreach (var value in values)
            {
                var formatedValues = ConvertInput(value);
                foreach (var formatedValue in formatedValues)
                {
                    result += GetEthiopic(formatedValue);
                }

            }

            return result;
        }

        /// <summary>
        /// Convert character to Ethiopic value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string ToEthiopic(char value)
        {
            var input = CheckInput(value);
            var values = ConvertInput(input);
            string result = null;
            foreach (var val in values)
            {
                if(IsAllNumber(val))
                {
                    result += NumberControl.GetNumber(val);
                }
                else
                    result += GetEthiopic(input);
            }

            return result;
        }

        /// <summary>
        /// This method prepares string value for conversion
        /// </summary>
        /// <returns></returns>
        public string[] ConvertInput(string value)
        {
            
            List<string> result = new();
            if(IsAllNumber(value))
            {
                result = ConvertNumber(value);
            }
            else
            {
                result = ConvertSyllable(value);
            }
            return result.ToArray();
        }

        private List<string> ConvertSyllable(string value)
        {
            List<string> result = new();
            int i = 0;
            while (i != value.Length)
            {
                string syllable = "";
                while (IsVowel(value[i]) || value[i] == 'w' || value[i] == '2' || i == 0 || i > value.Length)
                {
                    syllable += $"{value[i]}";
                    i++;
                    if (i == value.Length)
                        break;
                }
                syllable = syllable.Length == 0 ? $"{value[i]}" : syllable;
                value = value.Remove(0, i);
                i = 0;
                result.Add($"{syllable}");
            }
            return result;
        }
        private List<string> ConvertNumber(string value)
        {
            List<string> result = new();
            result.Add(value);
            return result;
        }
        private string GetEthiopic(string value)
        {
            string result = null;
            result += IsVowel(value[0]) ? GetEthiopicVowel(value) : GetSyllable(value);

            return result;
        }

        /// <summary>
        /// Convert string to Character code
        /// </summary>
        /// <param name="utf8String"></param>
        /// <returns></returns>
        public string GetCharacterValue(string utf8String)
        {
            string characters = "";
            for (int i = 0; i < utf8String.Length; i++)
            {
                characters += $"{(int)utf8String[i]:x4}";
            }
            return characters;
        }

        private string CheckInput(char input)
        {
            var result = "";
            if(IsNumber(input) && IsNumber(inputManager[0]))
            {
                if (inputPointer > 2 || (inputPointer >= 1 && input != '0'))
                {
                    ResetInputManager();
                }
                inputManager[input=='0'? inputPointer: 0] = input;
                IsPerformClean = input == '0'? true : false ;
                inputPointer++;
            }
            else
            {
                if (inputPointer >= 1)
                {
                    if (!IsVowel(input) && input != '2' && (inputManager[1] != '2' && input != 'w'))
                    {
                        ResetInputManager();
                        inputManager[inputPointer] = input;
                        inputPointer++;
                    }
                    else if (!IsVowel(inputManager[0]))
                    {
                        inputManager[inputPointer] = input;
                        if (IsAllVowel(input))
                        {
                            result = Join();
                            inputPointer++;
                            IsPerformClean = true;
                        }
                        else
                        {
                            ResetInputManager();
                            inputManager[inputPointer] = input;
                            inputPointer++;
                        }
                    }

                }
                else
                {
                    inputManager[inputPointer] = input;
                    inputPointer++;
                    IsPerformClean = false;
                }
            }
            
            return Join();
        }
        public void ResetInputManager()
        {
            inputManager = new char[5];
            inputPointer = 0;
            IsPerformClean = false;
        }
        private bool IsAllVowel(char input)
        {
            if(inputPointer>=1)
            {
                bool[] ins = new bool[inputPointer+1];
               ins[0] = true;
                for(int i=1; i<=inputPointer; i++)
                {
                    if (IsVowel(input) || inputManager[i] == 'w' || inputManager[i] == '2')
                        ins[i] = true;
                }
                if (ins.All(x => x.Equals(true)))
                    return true;
            }
            return false;
        }
        private bool IsAllNumber(string value)
        {
            var val = value.ToCharArray();
            var result = val.All<char>(x => char.IsNumber(x));
            return result;
        }
        private string Join()
        {
            var result = "";
            foreach (var item in inputManager)
            {
                if (item != '\0')
                    result += item;
            }
            return result;
        }
    }
}