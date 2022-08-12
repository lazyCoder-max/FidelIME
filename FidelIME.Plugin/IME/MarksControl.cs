namespace FidelIME.Plugin.IME
{
    /// <summary>
    /// Provides Ethiopic Input marks ie: ፥ ። ፣
    /// </summary>
    public class MarksControl
    {
        public string GetMarks(string value)
        {
            var result = "";
            switch (value)
            {
                case "!":
                    result = "᎐";
                    break;
                case "@":
                    result = "᎑";
                    break;
                case "#":
                    result = "᎒";
                    break;
                case "$":
                    result = "᎓";
                    break;
                case "%":
                    result = "᎔";
                    break;
                case "^":
                    result = "᎕";
                    break;
                case "&":
                    result = "᎖";
                    break;
                case "*":
                    result = "᎗";
                    break;
                case "(":
                    result = "᎘";
                    break;
                case ")":
                    result = "᎙";
                    break;
                case "-":
                    result = "፝";
                    break;
                case "=":
                    result = "፞";
                    break;
                case "[":
                    result = "፟";
                    break;
                case "]":
                    result = "፠";
                    break;
                case ":":
                    result = "፡";
                    break;
                case ".":
                    result = "።";
                    break;
                case ",":
                    result = "፣";
                    break;
                case ">":
                    result = "፤";
                    break;
                case "/":
                    result = "፥";
                    break;
                case "<":
                    result = "፦";
                    break;
                default:
                    break;
            }
            return result;
        }
    }
}