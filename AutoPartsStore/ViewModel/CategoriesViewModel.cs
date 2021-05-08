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
        public NewCategoryViewModel NewCategoryViewModel { get; set; }

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
                    categories = null; 
                    UpdateCategoryTree();

                }, func =>
                {
                    return true;
                }));
            }
        }

        private RelayCommand addMainCategoryCommand;
        public RelayCommand AddMainCategoryCommand
        {
            get
            {
                return addMainCategoryCommand ?? (addMainCategoryCommand = new RelayCommand(action =>
                {
                    NewCategoryWindow newCategoryWindow = new NewCategoryWindow();
                    newCategoryWindow.Show();
                    Category parent = categoryАccess.GetCategoryById(1);
                    mainViewModel.NewCategoryViewModel.Category = new Category(parent, "");
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
                    UpdateCategoryTree();
                }, func =>
                {
                    return true;
                }));
            }
        }

        private void UpdateCategoryTree()
        {
            Categories = categoryАccess.GetCategoryTree();
        }
        protected virtual bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(storage, value)) return false;

            storage = value;
            NotifyPropertyChanged(propertyName);

            return true;
        }
        public ObservableCollection<Category> Categories
        {
            get
            {
                return categories;
            }
            set
            {
                //categories = value;
                SetProperty(ref categories, value);
            }
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
        private ObservableCollection<Category> categories;

        CategoryАccess categoryАccess;

        MainViewModel mainViewModel;
        public CategoriesViewModel()
        {
            categoryАccess = new CategoryАccess();
            NewCategoryViewModel = new NewCategoryViewModel();
            Categories = categoryАccess.GetCategoryTree();

            mainViewModel = MainViewModel.GetMainViewModel();
            mainViewModel.CategoriesViewModel = this;
            MainCategoryNode = categoryАccess.GetCategoryById(1);

            //Category category1 = new Category("1", "Mоторное масло");
            //Category category2 = new Category("2", "Система сцепления / навесные части", new ObservableCollection<Category>{ 
            //    new Category("2.1", "Комплект сцепления"),
            //    new Category("2.2", "Корзина"),
            //    new Category("2.3", "Диск сцепления"),
            //    new Category("2.4", "Система управление сцепления", new ObservableCollection<Category>{
            //        new Category("2.4.1", "Цилиндр сцепления рабочий"),
            //        new Category("2.4.2", "Накладка на педаль сцепления"),
            //        new Category("2.4.3", "Обменный клапан"),
            //    }),
            //});
            //Category category3 = new Category("2", "Система сцепления / навесные части", new ObservableCollection<Category>{
            //    new Category("2.1", "Комплект сцепления"),
            //    new Category("2.2", "Корзина", new ObservableCollection<Category>{
            //        new Category("2.4.1", "Цилиндр сцепления рабочий"),
            //        new Category("2.4.2", "Накладка на педаль сцепления"),
            //        new Category("2.4.3", "Обменный клапан"),
            //    }),
            //    new Category("2.3", "Диск сцепления"),
            //    new Category("2.4", "Система управление сцепления"),
            //});

            //categories = new ObservableCollection<Category> { 
            //    category1, category2, category3
            //};

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
