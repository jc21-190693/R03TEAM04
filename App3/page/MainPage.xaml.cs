
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App3.page;

namespace App3
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();
            // 上部のバーを消す
            // 消したいページ毎に実行する必要がある
            NavigationPage.SetHasNavigationBar(this, false);
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            // SubPageに遷移する
            //Navigation.PushAsync(new SubPage());

            //label.Text = "Hello Xamarin.Forms World!!";?????
            Navigation.PushAsync(new SetPage());

            // このようにMainPageプロパティに遷移したいページを渡すことで画面を切り替えることができる
            // この場合NavigationPageのように遷移したページをスタックしないので、前のページに戻る処理などは自前で管理する必要がある
            //App.Current.MainPage = new SubPage();
        }




    }
}

