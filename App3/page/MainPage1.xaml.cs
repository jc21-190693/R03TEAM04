using System;
using Xamarin.Forms;

namespace App3.page

{
    public partial class MainPage1 : ContentPage
    {
        public MainPage1()
        {
            InitializeComponent();
            NextButton.Clicked += NextButton_Clicked;
        }
        private void NextButton_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new SetPage();
        }


    }
}
