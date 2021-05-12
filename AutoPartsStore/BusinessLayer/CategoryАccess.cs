using AutoPartsStore.DataBaseConnector;
using AutoPartsStore.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPartsStore.BusinessLayer
{
    interface ICategoryАccess
    {
        void AddCategory(int parentCategoryId, string categoryName);
        Category DeleteCategory(int categoryId);
        Category UpdateCategory(Category newCategory);

        Category GetCategoryById(int categoryId);

        List<Category> GetAllCategories();

    }
    class CategoryАccess : ICategoryАccess
    {
        AutoPartsStoreContext db;

        List<Category> categories;


        public CategoryАccess()
        {
            
            db = AutoPartsStoreContext.GetStoreContext();
            if (db.Categories.Where(c => c.CategoryLevel == 0).FirstOrDefault() == null)
            {
                Category topCategory = new Category(null, "Top category");
                topCategory.CategoryLevel = 0;
                db.Categories.Add(topCategory);
                db.SaveChanges();
                
            }
            UpdateCategoryInfo();
        } 


        public void UpdateCategoryInfo()
        {
            categories = db.Categories.ToList();
        }

        public List<Category> GetAllCategories()
        {
            return categories;
        }

        public void AddCategory(Category category)
        {
            AddCategory(category.ParentCategory.CategoryId, category.Name);
        }
        public void AddCategory(int parentCategoryId, string categoryName)
        {
            Category parentCategory = categories.Where(c => c.CategoryId == parentCategoryId).FirstOrDefault();
            if(parentCategory is null)
            {
                throw new Exception("parent category is null");
            }
            Category category = new Category(parentCategory, categoryName);
            db.Categories.Add(category);
            db.SaveChanges();

            UpdateCategoryInfo();

            //parentCategory.Nodes.Add(category);
            //categories.Add(category);

        }
        public Category DeleteCategory(int categoryId)
        {
            Category category = categories.Where(c => c.CategoryId == categoryId).FirstOrDefault();
            if (category is null)
            {
                throw new Exception("Category is null");
            }
            db.Categories.Remove(category);
            IEnumerable<Category> removeCategories = db.Categories.Where(c => c.ParentCategory == null && c.CategoryLevel != 0).AsEnumerable();
            db.Categories.RemoveRange(removeCategories);

            db.SaveChanges();
            UpdateCategoryInfo();
            return category;
        }
        public Category UpdateCategory(Category newCategory)
        {
            Category category = categories.Where(c => c.CategoryId == newCategory.CategoryId).FirstOrDefault();
            if (category is null)
            {
                throw new Exception("Category is null");
            }
            category.Name = newCategory.Name;
            db.SaveChanges();
            UpdateCategoryInfo();
            return newCategory;
        }
        public Category GetCategoryById(int categoryId)
        {
            return categories.Where(c => c.CategoryId.Equals(categoryId)).FirstOrDefault();
        }
        public Category GetMainCategory()
        {
            return GetCategoryById(db.Categories.Where(c => c.CategoryLevel == 0).FirstOrDefault().CategoryId);
        }

    }
}
