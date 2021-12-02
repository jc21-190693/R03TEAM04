using System;
using Xamarin.Forms;

namespace App3.page

{
    public partial class MainPage1 : ContentPage
    {
        public MainPage1()
        {
            
            InitializeComponent();
          
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SetPage());
        }
    }
}
