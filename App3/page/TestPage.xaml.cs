
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NavPageSample.notification;
using NavPageSample.page;
using Xamarin.Forms;

namespace NavPageSample.page
{

    public partial class TestPage : ContentPage
    {

        public TestPage()
        {
            InitializeComponent();

            // 2021/12/28 吉澤追加分 ここから

            notificationManager = DependencyService.Get<INotificationManager>();
            notificationManager.NotificationReceived += (sender, eventArgs) =>
            {
                var evtData = (NotificationEventArgs)eventArgs;
                ShowNotification(evtData.Title, evtData.Message);
                DisplayAlert("Alert", "TestPage.NotificationReceived", "ok");
            };
            DisplayAlert("Alert", "TestPage.InitializeComponent", "ok");
            // 2021/12/28 吉澤追加分 ここまで

        }

        protected override void OnAppearing()
        {
            //OnAppearingメソッドでデータベースに格納されている物がlistviewに設定される
            base.OnAppearing();
            /*listview.ItemsSource = await App.Database.GetUsersAsync();*/
        }


        private async void OnAddButtonClicked(object sender, EventArgs e)
        {
            //IsNullWhiteSpaceでは指定した文字列が空白」かどうか、true(空白あり)とfalseで返す。
            if (!string.IsNullOrWhiteSpace(Birth_Entry.Text) && !string.IsNullOrWhiteSpace(Tabako_Entry.Text))
            {

                //Userテーブルにデータを入力してもらう。全部STRINGなので変換してDBへ
                await App.Database.SaveUserAsync(new User
                {
                    User_id = 1,
                    Date_of_birth = DateTime.Parse(Birth_Entry.Text),
                    Sex = Sex_Entry.Text,
                    BoodType = BloodType_Entry.Text,

                    //STRINGをINTに型変換し格納
                    Height = int.Parse(Height_Entry.Text),
                    Weight = int.Parse(Weight_Entry.Text),

                    Tabako = Tabako_Entry.Text,
                    Drinking = Drinking_Entry.Text,
                    Taking_history = Taking_History_Entry.Text,

                    //平日の
                    Day_breakfast = DateTime.Parse(Day_Breakfast_Entry.Text),
                    Day_lunch = DateTime.Parse(Day_lunch_Entry.Text),
                    Clockin_time = DateTime.Parse(Clockin_Time_Entry.Text),

                    //休日の
                    End_breakfast = DateTime.Parse(End_Breakfast_Entry.Text),
                    End_lunch = DateTime.Parse(End_Lunch_Entry.Text)

                }); ;

                //入力欄を空にする　必要？？
                /*SubjectEntry.Text = ContentEntry.Text = string.Empty;*/

                //USERテーブルからデータを取得し、リストにするメソッドでlistviewに代入
                /*listview.ItemsSource = await App.Database.GetUsersAsync();*/
            }
        }


        //登録した後
        private async void TappedlistviewItem(object sender, ItemTappedEventArgs e)
        {
            var enquete = e.Item as User;
            string action = await DisplayActionSheet("なにを選択しますか？", "キャンセル", null, "データの更新", "データの削除");
            string check = await DisplayActionSheet("本当に良いですか？？", "No", null, "Yes");
            if (check == "Yes")
            {
                if (action == "データの削除")
                {
                    await App.Database.DeleteUserAsync(enquete);
                    /*listview.ItemsSource = await App.Database.GetUsersAsync();*/
                }
                else if (action == "データの更新")
                {
                    if (!string.IsNullOrWhiteSpace(Sex_Entry.Text) && !string.IsNullOrWhiteSpace(Tabako_Entry.Text))
                    {
                        //ででで
                        enquete.Date_of_birth = DateTime.Parse(Birth_Entry.Text);
                        enquete.Sex = Sex_Entry.Text;
                        enquete.BoodType = BloodType_Entry.Text;

                        //STRINGをINTに型変換し格納
                        enquete.Height = int.Parse(Height_Entry.Text);
                        enquete.Weight = int.Parse(Weight_Entry.Text);

                        enquete.Tabako = Tabako_Entry.Text;
                        enquete.Drinking = Drinking_Entry.Text;
                        enquete.Taking_history = Taking_History_Entry.Text;

                        //平日の
                        enquete.Day_breakfast = DateTime.Parse(Day_Breakfast_Entry.Text);
                        enquete.Day_lunch = DateTime.Parse(Day_lunch_Entry.Text);
                        enquete.Clockin_time = DateTime.Parse(Clockin_Time_Entry.Text);

                        //休日の
                        enquete.End_breakfast = DateTime.Parse(End_Breakfast_Entry.Text);
                        enquete.End_lunch = DateTime.Parse(End_Lunch_Entry.Text);


                        await App.Database.SaveUserAsync(enquete);
                        /*SubjectEntry.Text = ContentEntry.Text = string.Empty;*/
                        /*listview.ItemsSource = await App.Database.GetUsersAsync();*/
                    }
                    else
                    {
                        await DisplayAlert("アンケート欄を全て入力してください。", "文字を入力してください", "完了！");
                    }
                }
            }
        }

        // 2021/12/28 吉澤追加分 ここから

        INotificationManager notificationManager;

        int notificationNumber = 0;

        private void OnNotifyButtonClicked(object sender, EventArgs e)
        {
            notificationNumber++;
            string title = $"Local Notification #{notificationNumber}";
            string message = $"You have now received {notificationNumber} notifications!";
            notificationManager.SendNotification(title, message);
            var msg = new Label()
            {
                Text = $"Notification send:\nTitle: {title}\nMessage: {message}"
            };
            stackLayout.Children.Add(msg);

        }
        private  void OnScheduleButtonClicked(object sender, EventArgs e)
        {
            notificationNumber++;
            string title = $"Local Notification #{notificationNumber}";
            string message = $"You have now received {notificationNumber} notifications!";
            notificationManager.SendNotification(title, message, DateTime.Now.AddSeconds(10));
            var msg = new Label()
            {
                Text = $"Schedule Notification send:\nTitle: {title}\nMessage: {message}"
            };
            stackLayout.Children.Add(msg);
        }

        void ShowNotification(string title, string message)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                var msg = new Label()
                {
                    Text = $"Notification Received:\nTitle: {title}\nMessage: {message}"
                };
                stackLayout.Children.Add(msg);
            });
        }

        // 2021/12/28 吉澤追加分 ここまで


    }
}