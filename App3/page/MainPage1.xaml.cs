using Xamarin.Forms;

namespace App3.page

{
    public partial class MainPage1 : ContentPage
    {
        public MainPage1()
        {
            InitializeComponent();
              SetButton.Clicked += SetButton_Clicked;
        }

        	
       private void SettButton_Clicked(object sender, EventArgs e)
{
   Application.Current.MainPage1 = new SetPage();
}
    }
}
