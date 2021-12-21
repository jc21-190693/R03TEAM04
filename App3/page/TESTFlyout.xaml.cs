using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NavPageSample.page
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TESTFlyout : ContentPage
    {
        public ListView ListView;

        public TESTFlyout()
        {
            InitializeComponent();

            BindingContext = new TESTFlyoutViewModel();
            ListView = MenuItemsListView;
        }

        class TESTFlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<TESTFlyoutMenuItem> MenuItems { get; set; }

            public TESTFlyoutViewModel()
            {
                MenuItems = new ObservableCollection<TESTFlyoutMenuItem>(new[]
                {
                    new TESTFlyoutMenuItem { Id = 0, Title = "Page 1" },
                    new TESTFlyoutMenuItem { Id = 1, Title = "Page 2" },
                    new TESTFlyoutMenuItem { Id = 2, Title = "Page 3" },
                    new TESTFlyoutMenuItem { Id = 3, Title = "Page 4" },
                    new TESTFlyoutMenuItem { Id = 4, Title = "Page 5" },
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}