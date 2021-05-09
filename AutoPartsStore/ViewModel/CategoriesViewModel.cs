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
using AutoPartsStore.View;
using AutoPartsStore.BusinessLayer;
using System.Runtime.CompilerServices;

namespace AutoPartsStore.ViewModel
{
    class CategoriesViewModel : INotifyPropertyChanged
    {
       

        private RelayCommand findCommand;
        public RelayCommand FindCommand
        {
            get
            {
                return findCommand ?? (findCommand = new RelayCommand(action =>
                {
                    MessageBox.Show(((int)action).ToString());
                    //ProductViewModel.ProductViewModelObject.

                }, func =>
                {
                    return true;
                }));
            }
        }
        private string inputCategoryString;
        public string InputCategoryString
        {
            get
            {
                return inputCategoryString;
            }
            set
            {
                inputCategoryString = value;
                NotifyPropertyChanged("InputCategoryString");
            }
        }
        private RelayCommand addCategoryCommand;
        public RelayCommand AddCategoryCommand
        {
            get
            {
                return addCategoryCommand ?? (addCategoryCommand = new RelayCommand(action =>
                {
                    categoryАccess.AddCategory(mainViewModel.NewCategoryViewModel.Category);

                }, func =>
                {
                    return true;
                }));
            }
        }

    

        private RelayCommand addIntoCategoryCommand;
        public RelayCommand AddIntoCategoryCommand
        {
            get
            {
                return addIntoCategoryCommand ?? (addIntoCategoryCommand = new RelayCommand(action =>
                {
                    //MessageBox.Show((int)action + " добавить в");
                    NewCategoryWindow newCategoryWindow = new NewCategoryWindow();
                    newCategoryWindow.Show();
                    Category parent = categoryАccess.GetCategoryById((int)action);
                    mainViewModel.NewCategoryViewModel.Category = new Category(parent, "");
                }, func =>
                {
                    return true;
                }));
            }
        }

        

        private RelayCommand renameCategoryCommand;
        public RelayCommand RenameCategoryCommand
        {
            get
            {
                return renameCategoryCommand ?? (renameCategoryCommand = new RelayCommand(action =>
                {
                    //MessageBox.Show((int)action + " добавить в");
                    NewCategoryWindow newCategoryWindow = new NewCategoryWindow();
                    newCategoryWindow.Show();
                    Category parent = categoryАccess.GetCategoryById((int)action);
                    mainViewModel.NewCategoryViewModel.Category = categoryАccess.GetCategoryById((int)action);
                }, func =>
                {
                    return true;
                }));
            }
        }

        private RelayCommand addWithCategoryCommand;
        public RelayCommand AddWithCategoryCommand
        {
            get
            {
                return addWithCategoryCommand ?? (addWithCategoryCommand = new RelayCommand(action =>
                {
                    //MessageBox.Show((in)action + "добавить с");
                    NewCategoryWindow newCategoryWindow = new NewCategoryWindow();
                    newCategoryWindow.Show();
                    Category parent = categoryАccess.GetCategoryById((int)action).ParentCategory;
                    mainViewModel.NewCategoryViewModel.Category = new Category(parent, "");
                }, func =>
                {
                    return true;
                }));
            }
        }

        private RelayCommand deleteCategoryCommand;
        public RelayCommand DeleteCategoryCommand
        {
            get
            {
                return deleteCategoryCommand ?? (deleteCategoryCommand = new RelayCommand(action =>
                {
                    /// сделать удаление всего
                    MessageBox.Show((int)action + "удалить");
                    categoryАccess.DeleteCategory((int)action);
                }, func =>
                {
                    return true;
                }));
            }
        }

        protected virtual bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(storage, value)) return false;

            storage = value;
            NotifyPropertyChanged(propertyName);

            return true;
        }

        private Category mainCategoryNode;
        public Category MainCategoryNode
        {
            get
            {
                return mainCategoryNode;
            }
            set
            {
                SetProperty(ref mainCategoryNode, value);
            }
        }

        CategoryАccess categoryАccess;

        MainViewModel mainViewModel;
        public CategoriesViewModel()
        {
            categoryАccess = new CategoryАccess();
            

            mainViewModel = MainViewModel.GetMainViewModel();
            mainViewModel.CategoriesViewModel = this;

            MainCategoryNode = categoryАccess.GetMainCategory();
        }

       

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
