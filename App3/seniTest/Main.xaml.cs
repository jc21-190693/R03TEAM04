//教科書118

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

    }

}