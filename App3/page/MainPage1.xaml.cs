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

        void OnButtonClicked(object sender, EventArgs e)
{
    (sender as Button).Text = "Click me again!";
}
      
    }
}
