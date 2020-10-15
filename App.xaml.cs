using System.Windows.Forms;

namespace Conduit
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        private NotifyIcon icon;
        private ConnectionManager manager;

        public App()
        {

            icon = new NotifyIcon
            {
                Text = Program.APP_NAME,
                Icon = Conduit.Properties.Resources.mimic,
                Visible = true,
                ContextMenu = new ContextMenu(new []
                {
                    new MenuItem(Program.APP_NAME + " " + Program.VERSION)
                    {
                        Enabled = false
                    },
                    new MenuItem("退出", (a, b) => Shutdown())
                })
            };

            icon.Click += (a, b) =>
            {
                // Only open about if left mouse is used (otherwise right clicking opens both context menu and about).
                if (b is MouseEventArgs args && args.Button == MouseButtons.Left)
                {
                    if(!Program.windowIsOpen)
                    {
                        Program.windowIsOpen = true;
                        new AboutWindow().Show();
                    }
                }
            };

            icon.BalloonTipClicked += (a, b) =>
            {
                if (!Program.windowIsOpen)
                {
                    Program.windowIsOpen = true;
                    new AboutWindow().Show();
                }
            };

            manager = new ConnectionManager(this);

            ShowNotification("已最小化到托盘。");

        }

        /**
         * Shows a simple notification with the specified text for 5 seconds.
         */
        public void ShowNotification(string text)
        {
            icon.BalloonTipTitle = "LOL 自动接受";
            icon.BalloonTipText = text;
            icon.ShowBalloonTip(5000);
        }
    }
}