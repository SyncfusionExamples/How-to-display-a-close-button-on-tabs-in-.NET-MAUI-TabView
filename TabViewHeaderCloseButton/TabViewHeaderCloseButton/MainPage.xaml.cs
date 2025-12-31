using Microsoft.Maui.Controls;
using Syncfusion.Maui.Core;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TabViewHeaderCloseButton
{
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {

        private readonly MainPageViewModel viewModel = new MainPageViewModel();
        public MainPage()
        {
            InitializeComponent();
            BindingContext = viewModel;
        }

        private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
        {
            var model = (sender as View)?.BindingContext as Model;
            if (model != null && viewModel.TabItems.Contains(model))
            {
                viewModel.TabItems.Remove(model);
            }
        }

    }

    public class MainPageViewModel
    {
        public ObservableCollection<Model> TabItems { get; set; }
        public MainPageViewModel()
        {
            TabItems = new ObservableCollection<Model>
            {
               new Model
                {
                    Title = "Home",
                    ContentText = "Welcome to the Home tab. Here you can find an overview of your application and quick access to essential features."
                },
                new Model
                {
                    Title = "Tasks",
                    ContentText = "Manage your tasks efficiently. Add new tasks, track progress, and stay organized to meet your goals."
                },
                new Model
                {
                    Title = "Reports",
                    ContentText = "View detailed reports and analytics. Gain insights into your performance and make informed decisions."
                }
            };
        }

    }
    public class Model
    {
        public string Title { get; set; }
        public string ContentText { get; set; }
    }

}
