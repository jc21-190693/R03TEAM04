
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App3.page
{

    public partial class TestPage : ContentPage
    {

        public TestPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listview.ItemsSource = await App.Database.GetNotesAsync();
        }

        private async void OnAddButtonClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(SubjectEntry.Text) && !string.IsNullOrWhiteSpace(ContentEntry.Text))
            {
                await App.Database.SaveNoteAsync(new Note
                {
                    Subject = SubjectEntry.Text,
                    Content = ContentEntry.Text,
                    Date = DateTime.Now
                });

                SubjectEntry.Text = ContentEntry.Text = string.Empty;
                listview.ItemsSource = await App.Database.GetNotesAsync();
            }
        }

        private async void TappedlistviewItem(object sender, ItemTappedEventArgs e)
        {
            var item = e.Item as Note;
            string action = await DisplayActionSheet("どれにする？?", "キャンセル", null, "更新", "削除");
            string check = await DisplayActionSheet("これでよろしいですか？?", "いいえ", null, "はい");

            //checkで「はい」なら
            if (check == "はい")
            {
                if (action == "削除")
                {
                    await App.Database.DeleteNoteAsync(item);
                    listview.ItemsSource = await App.Database.GetNotesAsync();
                }
                else if (action == "更新")
                {
                    if (!string.IsNullOrWhiteSpace(SubjectEntry.Text) && !string.IsNullOrWhiteSpace(ContentEntry.Text))
                    {
                        item.Subject = SubjectEntry.Text;
                        item.Content = ContentEntry.Text;
                        item.Date = DateTime.Now;
                        await App.Database.SaveNoteAsync(item);
                        SubjectEntry.Text = ContentEntry.Text = string.Empty;
                        listview.ItemsSource = await App.Database.GetNotesAsync();
                    }
                    else
                    {
                        await DisplayAlert("ErrorCode:????", "入力してください", "はい");
                    }
                }
            }
        }
    }
}