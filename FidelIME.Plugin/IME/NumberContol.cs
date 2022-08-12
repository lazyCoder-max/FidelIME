namespace FidelIME.Plugin.IME
{
    /// <summary>
    /// Provides Ethiopic Numbers 
    /// </summary>
    public class NumberContol
    {
        public string GetNumber(string value)
        {
            var result = "";
            switch (value)
            {
                case "1":
                    result = "፩";
                    break;
                case "2":
                    result = "፪";
                    break;
                case "3":
                    result = "፫";
                    break;
                case "4":
                    result = "፬";
                    break;
                case "5":
                    result = "፭";
                    break;
                case "6":
                    result = "፮";
                    break;
                case "7":
                    result = "፯";
                    break;
                case "8":
                    result = "፰";
                    break;
                case "9":
                    result = "፱";
                    break;
                case "10":
                    result = "፲";
                    break;
                case "20":
                    result = "፳";
                    break;
                case "30":
                    result = "፴";
                    break;
                case "40":
                    result = "፵";
                    break;
                case "50":
                    result = "፶";
                    break;
                case "60":
                    result = "፷";
                    break;
                case "70":
                    result = "፸";
                    break;
                case "80":
                    result = "፹";
                    break;
                case "90":
                    result = "፺";
                    break;
                case "100":
                    result = "፻";
                    break;
                case "1000":
                    result = "፼";
                    break;
                default:
                    break;
            }
            return result;
        }
    }
}