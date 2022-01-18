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

        private async void OnAddButtonClicked(object sender, EventArgs e)
        {
            //Medicineテーブルを保存
            await App.Database.SaveMedicineAsync(new Medicine
            {
                
                Medicine_name = Medicine_Name_Entry.Text,

            }) ;

        }
    }
}