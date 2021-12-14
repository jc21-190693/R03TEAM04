
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NavPageSample.page;
using Xamarin.Forms;

namespace NavPageSample.page
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
            string action = await DisplayActionSheet("なにを選択しますか？", "キャンセル", null, "データの更新", "データの削除");
            string check = await DisplayActionSheet("本当に良いですか？？", "No", null, "Yes");
            if (check == "Yes")
            {
                if (action == "データの削除")
                {
                    await App.Database.DeleteNoteAsync(item);
                    listview.ItemsSource = await App.Database.GetNotesAsync();
                }
                else if (action == "データの更新")
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
                        await DisplayAlert("エラーです！", "文字を入力してください", "完了！");
                    }
                }
            }
        }
    }
}