using BookStoreAPP.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace BookStoreAPP.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}