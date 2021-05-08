using AutoPartsStore.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPartsStore.Model
{
    public class Category : BaseViewModel
    {
        private int categoryId;
        private int categoryLevel;
        private Category parentCategory;
        private string name;
        private ObservableCollection<Category> nodes;

        public Category()
        {

        }
        public Category(Category parentCategory, string category)
        {
            this.parentCategory = parentCategory;
            this.name = category;
            if(parentCategory != null)
            {
                categoryLevel = parentCategory.CategoryLevel + 1;
            }
        }
        public int CategoryId
        {
            get
            {
                return categoryId;
            }
            set
            {
                categoryId = value;
                NotifyPropertyChanged(nameof(CategoryId));

            }
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                NotifyPropertyChanged(nameof(Name));
            }
        }
        public  ObservableCollection<Category> Nodes
        {
            get
            {
                return nodes;
            }
            set
            {
                nodes = value;
                NotifyPropertyChanged(nameof(Nodes));

            }
        }
        public int CategoryLevel {
            get
            {
                return categoryLevel;
            }
            set
            {
                categoryLevel = value;
                NotifyPropertyChanged(nameof(CategoryLevel));
            }

        }
        public Category ParentCategory 
        {
            get
            {
                return parentCategory;
            }
            set
            {
                parentCategory = value;
                NotifyPropertyChanged(nameof(ParentCategory));
            }
        }

        public Category GetNodeById(string id)
        {
            return nodes.Where(n => n.categoryId.Equals(id)).First();
        }

    }
}
