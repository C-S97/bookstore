using BookStoreAPP.Models;
using BookStoreAPP.Services;
using BookStoreAPP.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BookStoreAPP.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        private Book _selectedItem;

        public ObservableCollection<Book> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<Book> ItemTapped { get; }

        public ItemsViewModel()
        {
            Title = "All books";
            Items = new ObservableCollection<Book>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            ItemTapped = new Command<Book>(OnItemSelected);

            AddItemCommand = new Command(OnAddItem);
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            var books = await API.shared.GetBooks();
            Items.Clear();
            foreach (Book book in books)
            {
                Items.Add(book);
            }

            OnPropertyChanged(nameof(Items));
            IsBusy = false;
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }

        public Book SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }

        private async void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewItemPage));
        }

        async void OnItemSelected(Book item)
        {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item.Id}");
        }
    }
}