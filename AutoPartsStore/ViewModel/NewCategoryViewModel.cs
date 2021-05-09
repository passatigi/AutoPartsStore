using AutoPartsStore.Command;
using AutoPartsStore.Model;
using AutoPartsStore.DataBaseConnector;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AutoPartsStore.ViewModel
{
    class NewCategoryViewModel : INotifyPropertyChanged
    {
        private RelayCommand addCategoryCommand;
        public RelayCommand AddCategoryCommand
        {
            get
            {
                return addCategoryCommand ?? (addCategoryCommand = mainViewModel.CategoriesViewModel.AddCategoryCommand);
            }
        }

        private Category category;
        public Category Category
        {
            get
            {
                return category;
            }
            set
            {
                category = value;
                NotifyPropertyChanged("Category");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        MainViewModel mainViewModel;
        public NewCategoryViewModel()
        {
            mainViewModel = MainViewModel.GetMainViewModel();
            mainViewModel.NewCategoryViewModel = this;
        }

    }
}
