using QRCoder;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media.Imaging;

namespace Conduit
{
    /// <summary>
    /// Interaction logic for AboutWindow.xaml
    /// </summary>
    public partial class AboutWindow : Window
    {
        public AboutWindow()
        {
            InitializeComponent();
            Logo.Source = Imaging.CreateBitmapSourceFromHIcon(Properties.Resources.mimic.Handle, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());

            AboutTitle.Content = "LOL阿狸自动接受 v" + Program.VERSION;
        }

        /**
         * Opens the project github link in the default browser.
         */
        public void OpenGithub(object sender, EventArgs args)
        {
            Process.Start(Program.Contact);
        }

        /**
         * Invoked when window closes, unregisters from persistence listeners.
         */
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Program.windowIsOpen = false;
        }

    }
}
