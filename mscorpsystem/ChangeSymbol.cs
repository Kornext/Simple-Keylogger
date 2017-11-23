using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mscorpsystem
{
    public static class ChangeSymbol
    {
        public static string keyboardLayotSmallLeterEN(string origin)
        {
            if (origin == "Q")
                origin = "q";
            else if (origin == "W")
                origin = "w";
            else if (origin == "E")
                origin = "e";
            else if (origin == "R")
                origin = "r";
            else if (origin == "T")
                origin = "t";
            else if (origin == "Y")
                origin = "y";
            else if (origin == "U")
                origin = "u";
            else if (origin == "I")
                origin = "i";
            else if (origin == "O")
                origin = "o";
            else if (origin == "P")
                origin = "p";
            else if (origin == "A")
                origin = "a";
            else if (origin == "S")
                origin = "s";
            else if (origin == "D")
                origin = "d";
            else if (origin == "F")
                origin = "f";
            else if (origin == "G")
                origin = "g";
            else if (origin == "H")
                origin = "h";
            else if (origin == "J")
                origin = "j";
            else if (origin == "K")
                origin = "k";
            else if (origin == "L")
                origin = "l";
            else if (origin == "Z")
                origin = "z";
            else if (origin == "X")
                origin = "x";
            else if (origin == "C")
                origin = "c";
            else if (origin == "V")
                origin = "v";
            else if (origin == "B")
                origin = "b";
            else if (origin == "N")
                origin = "n";
            else if (origin == "M")
                origin = "m";

            return origin;
        }

        public static string keyboardLayotBigLeterEN(string origin)
        {
            if (origin == "q")
                origin = "Q";
            else if (origin == "w")
                origin = "W";
            else if (origin == "e")
                origin = "E";
            else if (origin == "r")
                origin = "R";
            else if (origin == "t")
                origin = "T";
            else if (origin == "y")
                origin = "Y";
            else if (origin == "u")
                origin = "U";
            else if (origin == "i")
                origin = "I";
            else if (origin == "o")
                origin = "O";
            else if (origin == "p")
                origin = "P";
            else if (origin == "a")
                origin = "A";
            else if (origin == "s")
                origin = "S";
            else if (origin == "d")
                origin = "D";
            else if (origin == "f")
                origin = "F";
            else if (origin == "g")
                origin = "G";
            else if (origin == "h")
                origin = "H";
            else if (origin == "j")
                origin = "J";
            else if (origin == "k")
                origin = "K";
            else if (origin == "l")
                origin = "L";
            else if (origin == "z")
                origin = "Z";
            else if (origin == "x")
                origin = "X";
            else if (origin == "c")
                origin = "C";
            else if (origin == "v")
                origin = "V";
            else if (origin == "b")
                origin = "B";
            else if (origin == "n")
                origin = "N";
            else if (origin == "m")
                origin = "M";
            else if (origin == "=")
                origin = "+";
            else if (origin == "-")
                origin = "_";
            else if (origin == "0")
                origin = ")";
            else if (origin == "9")
                origin = "(";
            else if (origin == "8")
                origin = "*";
            else if (origin == "7")
                origin = "&";
            else if (origin == "6")
                origin = "^";
            else if (origin == "5")
                origin = "%";
            else if (origin == "4")
                origin = "$";
            else if (origin == "3")
                origin = "#";
            else if (origin == "2")
                origin = "@";
            else if (origin == "1")
                origin = "!";
            else if (origin == "`")
                origin = "~";
            else if (origin == "\\")
                origin = "|";
            else if (origin == "]")
                origin = "}";
            else if (origin == "[")
                origin = "{";
            else if (origin == "'")
                origin = "\"";
            else if (origin == ";")
                origin = ":";
            else if (origin == "/")
                origin = "?";
            else if (origin == ".")
                origin = ">";
            else if (origin == ",")
                origin = "<";

            return origin;
        }

        public static string keyboardLayotReverse(string origin)
        {
            if (origin == "Space")
                origin = " ";
            else if (origin == "NumPad1")
                origin = "1";
            else if (origin == "NumPad2")
                origin = "2";
            else if (origin == "NumPad3")
                origin = "3";
            else if (origin == "NumPad4")
                origin = "4";
            else if (origin == "NumPad5")
                origin = "5";
            else if (origin == "NumPad6")
                origin = "6";
            else if (origin == "NumPad7")
                origin = "7";
            else if (origin == "NumPad8")
                origin = "8";
            else if (origin == "NumPad9")
                origin = "9";
            else if (origin == "NumPad0")
                origin = "0";
            else if (origin == "Add")
                origin = "+";
            else if (origin == "Subtract")
                origin = "-";
            else if (origin == "Multiply")
                origin = "*";
            else if (origin == "Divide")
                origin = "/";
            else if (origin == "Decimal")
                origin = ".";
            else if (origin == "Up")
                origin = "";
            else if (origin == "Left")
                origin = "";
            else if (origin == "Down")
                origin = "";
            else if (origin == "Right")
                origin = "";
            else if (origin == "Enter")
                origin = "\n";
            else if (origin == "Oemplus")
                origin = "=";
            else if (origin == "OemMinus")
                origin = "-";
            else if (origin == "Oem5")
                origin = "\\";
            else if (origin == "Oem6")
                origin = "]";
            else if (origin == "OemOpenBrackets")
                origin = "[";
            else if (origin == "Oem7")
                origin = "\'";
            else if (origin == "Oem1")
                origin = ";";
            else if (origin == "OemQuestion")
                origin = "/";
            else if (origin == "OemPeriod")
                origin = ".";
            else if (origin == "Oemcomma")
                origin = ",";
            else if (origin == "Oemtilde")
                origin = "`";

            return origin;
        }

        public static string keyboardLayotSmallLeterRU(string origin)
        {
            if (origin == "Й")
                origin = "й";
            else if (origin == "Ц")
                origin = "ц";
            else if (origin == "У")
                origin = "у";
            else if (origin == "К")
                origin = "к";
            else if (origin == "Е")
                origin = "е";
            else if (origin == "Н")
                origin = "н";
            else if (origin == "Г")
                origin = "г";
            else if (origin == "Ш")
                origin = "ш";
            else if (origin == "Щ")
                origin = "щ";
            else if (origin == "З")
                origin = "з";
            else if (origin == "Х")
                origin = "х";
            else if (origin == "Ъ")
                origin = "ъ";
            else if (origin == "Ф")
                origin = "ф";
            else if (origin == "Ы")
                origin = "ы";
            else if (origin == "В")
                origin = "в";
            else if (origin == "А")
                origin = "а";
            else if (origin == "П")
                origin = "п";
            else if (origin == "Р")
                origin = "р";
            else if (origin == "О")
                origin = "о";
            else if (origin == "Л")
                origin = "л";
            else if (origin == "Д")
                origin = "д";
            else if (origin == "Ж")
                origin = "ж";
            else if (origin == "Э")
                origin = "э";
            else if (origin == "Я")
                origin = "я";
            else if (origin == "Ч")
                origin = "ч";
            else if (origin == "С")
                origin = "с";
            else if (origin == "М")
                origin = "м";
            else if (origin == "И")
                origin = "и";
            else if (origin == "Т")
                origin = "т";
            else if (origin == "Ь")
                origin = "ь";
            else if (origin == "Б")
                origin = "б";
            else if (origin == "Ю")
                origin = "ю";
            else if (origin == "Ё")
                origin = "ё";

            return origin;
        }

        public static string keyboardLayotBigLeterRU(string origin)
        {
            if (origin == "й")
                origin = "Й";
            else if (origin == "ц")
                origin = "Ц";
            else if (origin == "у")
                origin = "У";
            else if (origin == "к")
                origin = "К";
            else if (origin == "е")
                origin = "Е";
            else if (origin == "н")
                origin = "Н";
            else if (origin == "г")
                origin = "Г";
            else if (origin == "ш")
                origin = "Ш";
            else if (origin == "щ")
                origin = "Щ";
            else if (origin == "з")
                origin = "З";
            else if (origin == "х")
                origin = "Х";
            else if (origin == "ъ")
                origin = "Ъ";
            else if (origin == "ф")
                origin = "Ф";
            else if (origin == "ы")
                origin = "Ы";
            else if (origin == "в")
                origin = "В";
            else if (origin == "а")
                origin = "А";
            else if (origin == "п")
                origin = "П";
            else if (origin == "р")
                origin = "Р";
            else if (origin == "о")
                origin = "О";
            else if (origin == "л")
                origin = "Л";
            else if (origin == "д")
                origin = "Д";
            else if (origin == "ж")
                origin = "Ж";
            else if (origin == "э")
                origin = "Э";
            else if (origin == "я")
                origin = "Я";
            else if (origin == "ч")
                origin = "Ч";
            else if (origin == "с")
                origin = "С";
            else if (origin == "м")
                origin = "М";
            else if (origin == "и")
                origin = "И";
            else if (origin == "т")
                origin = "Т";
            else if (origin == "ь")
                origin = "Ь";
            else if (origin == "б")
                origin = "Б";
            else if (origin == "ю")
                origin = "Ю";
            else if (origin == "ё")
                origin = "Ё";
            else if (origin == ".")
                origin = ",";
            else if (origin == "=")
                origin = "+";
            else if (origin == "-")
                origin = "_";
            else if (origin == "0")
                origin = ")";
            else if (origin == "9")
                origin = "(";
            else if (origin == "8")
                origin = "*";
            else if (origin == "7")
                origin = "?";
            else if (origin == "6")
                origin = ":";
            else if (origin == "5")
                origin = "%";
            else if (origin == "4")
                origin = ";";
            else if (origin == "3")
                origin = "№";
            else if (origin == "2")
                origin = "\"";
            else if (origin == "1")
                origin = "!";
            else if (origin == "\\")
                origin = "/";

            return origin;
        }

        public static string keyboardLayotRU(string origin)
        {
            if (origin == "Q")
                origin = "Й";
            else if (origin == "W")
                origin = "Ц";
            else if (origin == "E")
                origin = "У";
            else if (origin == "R")
                origin = "К";
            else if (origin == "T")
                origin = "Е";
            else if (origin == "Y")
                origin = "Н";
            else if (origin == "U")
                origin = "Г";
            else if (origin == "I")
                origin = "Ш";
            else if (origin == "O")
                origin = "Щ";
            else if (origin == "P")
                origin = "З";
            else if (origin == "[")
                origin = "Х";
            else if (origin == "]")
                origin = "Ъ";
            else if (origin == "A")
                origin = "Ф";
            else if (origin == "S")
                origin = "Ы";
            else if (origin == "D")
                origin = "В";
            else if (origin == "F")
                origin = "А";
            else if (origin == "G")
                origin = "П";
            else if (origin == "H")
                origin = "Р";
            else if (origin == "J")
                origin = "О";
            else if (origin == "K")
                origin = "Л";
            else if (origin == "L")
                origin = "Д";
            else if (origin == ";")
                origin = "Ж";
            else if (origin == "'")
                origin = "Э";
            else if (origin == "Z")
                origin = "Я";
            else if (origin == "X")
                origin = "Ч";
            else if (origin == "C")
                origin = "С";
            else if (origin == "V")
                origin = "М";
            else if (origin == "B")
                origin = "И";
            else if (origin == "N")
                origin = "Т";
            else if (origin == "M")
                origin = "Ь";
            else if (origin == ",")
                origin = "Б";
            else if (origin == ".")
                origin = "Ю";
            else if (origin == "/")
                origin = ".";
            else if (origin == "`")
                origin = "Ё";
            else if (origin == "\\")
                origin = "\\";
            //else if (origin == " ")
            //    origin = ",";

            return origin;
        }
    }
}

