using _8247_ScrollCrash.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq;

namespace _8247_ScrollCrash.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public MainPageViewModel()
        {
            var items = new List<PhoneBookItem>();

            for (var i = 0; i < 1000; i++)
            {
                items.Add(new PhoneBookItem
                {
                    Title = $"{Faker.Enum.Random<Title>()}",
                    FirstName = Faker.Name.First(),
                    LastName = Faker.Name.Last(),
                    PhoneNumber = Faker.Phone.Number(),
                    EmailAddress = Faker.Internet.Email(),
                    DateOfBirth = Faker.Identification.DateOfBirth(),
                });
            }

            groupedItems = new List<PhoneBookGrouping>(
                items
                .Select(x => x.LastName[0])
                .Distinct()
                .OrderBy(x => x)
                .Select(x =>
                    new PhoneBookGrouping($"{x}", $"{x}",
                        items
                            .Where(y => y.LastName.StartsWith($"{x}"))
                            .OrderBy(x => x.LastName)
                            .ThenBy(x => x.FirstName)
                            .ToList())));
        }


        #region Properties

        private List<PhoneBookGrouping> groupedItems;

        public List<PhoneBookGrouping> GroupedItems
        {
            get
            {
                return groupedItems;
            }
            set
            {
                groupedItems = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region INotifyPropertyChanged

        public event Action OnChange;
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        public void NotifyStateChanged() => OnChange?.Invoke();

        #endregion
    }
}
