using System;
using System.IO;
using Xamarin.Forms;

namespace sample
{
    public partial class App : Application
    {
        static Database database;

        public static Database Database
        {
            get
            {
                if (database == null)
                {
                    database = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "people.db3"));
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // デバック開始時に出力
            Console.WriteLine("開始");
        }

        protected override void OnSleep()
        {
            // アプリを閉じた時に出力
            Console.WriteLine("中断");
        }

        protected override void OnResume()
        {
            // アプリを中断から再度開いたときに出力
            Console.WriteLine("再開");
        }
    }
}
