using System;

namespace Conduit
{
    class Program
    {
        public static bool windowIsOpen;

        public static string APP_NAME = "LOL阿狸自动接受";
        public static string VERSION = "1.0.0";

        public static string Contact = "https://www.52pojie.cn/thread-1188859-1-1.html";

        private static App _instance;

        [STAThread]
        public static void Main()
        {
            // Start the application.
            _instance = new App();
            _instance.InitializeComponent();
            _instance.Run();
        }
    }
}
