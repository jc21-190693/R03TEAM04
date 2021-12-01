//編集した
//Main.xaml.csが名前
//教科書118

/*using Xamarin.Forms;

namespace App3
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
*/

using System;
using System.IO;
using Xamarin.Forms;

namespace App3
{
    public partial class App : Application
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(Object sender,EventArgs e)
        {
            //subpageに遷移する
            Navigtion.PushAsync(new subPage());
        }











/*


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
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
*/
    }

}