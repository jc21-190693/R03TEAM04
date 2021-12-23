using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NavPageSample.page
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MedicineEntryPage : ContentPage
    {
        public MedicineEntryPage()
        {
            InitializeComponent();
        }


        void Button_MainPage(object sender, EventArgs e) {
            string name = Medicine_name.Text;

            var MainPage1 = new MainPage1();
            Navigation.PushAsync(MainPage1);

            MainPage1.NameSet(name);


        }

    }
}