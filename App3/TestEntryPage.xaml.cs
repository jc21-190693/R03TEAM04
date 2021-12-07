using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App3
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TestEntryPage : ContentPage
    {
        public TestEntryPage()
        {
            InitializeComponent();
        }

        async void LoadPerson(string PersonId)
        {
            try
            {
                int id = Convert.ToInt32(PersonId);
                // Retrieve the note and set it as the BindingContext of the page.
                Person person = await App.Database.GetPeopleAsync(id);
                BindingContext = person;
            }
            catch (Exception)
            {
                Console.WriteLine("Failed to load Person.");
            }
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var person = (Person)BindingContext;
            //ネーム
            person.Name = DateTime.UtcNow;
            if (!string.IsNullOrWhiteSpace(person.Name))
            {
                await App.Database.SavePeopleAsync(note);
            }

            // Navigate backwards
            await Shell.Current.GoToAsync("..");
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var note = (Note)BindingContext;
            await App.Database.DeleteNoteAsync(note);

            // Navigate backwards
            await Shell.Current.GoToAsync("..");
        }
    }
}