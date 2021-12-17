
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
            listview.ItemsSource = await App.Database.GetUsersAsync();
        }

        private async void OnAddButtonClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Birth_Entry.Text) && !string.IsNullOrWhiteSpace(Tabako_Entry.Text))
            {

                //Userテーブルにデータを入力してもらう。(アンケート？？？)
                await App.Database.SaveUserAsync(new User
                {
                    date_of_birth = Birth_Entry,
                    sex = Sex_Entry,
                    boodType = BloodType_Entry,
                    height = Height_Entry,
                    weight = Weight_Entry,
                    tabako = Tabako_Entry,
                    drinking = Drinking_Entry,
                    //allergy = Allegry_Entry,
                    taking_history = Taking_History_Entry,

                    //平日の
                    day_breakfast = Day_Breakfast_Entry,
                    day_lunch = Day_lunch_Entry,
                    clockin_time = Clockin_Time_Entry,

                    //休日
                    end_breakfast = End_Breakfast_Entry,
                    end_lunch = End_Lunch_Entry

                });

                SubjectEntry.Text = ContentEntry.Text = string.Empty;
                listview.ItemsSource = await App.Database.GetUsersAsync();
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
                    await App.Database.DeleteUserAsync(item);
                    listview.ItemsSource = await App.Database.GetUsersAsync();
                }
                else if (action == "データの更新")
                {
                    if (!string.IsNullOrWhiteSpace(SubjectEntry.Text) && !string.IsNullOrWhiteSpace(ContentEntry.Text))
                    {
                        item.Subject = SubjectEntry.Text;
                        item.Content = ContentEntry.Text;
                        item.Date = DateTime.Now;
                        await App.Database.SaveUserAsync(item);
                        SubjectEntry.Text = ContentEntry.Text = string.Empty;
                        listview.ItemsSource = await App.Database.GetUsersAsync();
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