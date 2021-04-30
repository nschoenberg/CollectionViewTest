using System.Collections.ObjectModel;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;

namespace CollectionViewTest.ViewModels
{

    public class Item : BindableBase
    {
        public string Name { get; set; }
    }

    public class MainPageViewModel : ViewModelBase
    {
        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "CollectionView Test";
            Items = new ObservableCollection<Item>();

            Items.Add(new Item { Name = "Anton" });
            Items.Add(new Item { Name = "Franz" });
            Items.Add(new Item { Name = "Maren" });

        }

        public Item SelectedItem
        {
            get => _selectedItem;
            set => SetProperty(ref _selectedItem, value);
        }

        public ObservableCollection<Item> Items { get; set; }

        private DelegateCommand<Item> _tapCommand;
        private Item _selectedItem;

        public DelegateCommand<Item> TapCommand =>
            _tapCommand ?? (_tapCommand = new DelegateCommand<Item>(ExecuteCommandName));

        void ExecuteCommandName(Item item)
        {
            SelectedItem = item;
        }
    }
}
