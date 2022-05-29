using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TRPO_DM.Interfaces;
using TRPO_DM.Models;
using TRPO_DM.ViewModels;

namespace TRPO_DA.DataAccess
{
    public class CategoryDataAccess
    {
        private DataContext dataContext { get; }
        private IMapper mapper { get; }

        public CategoryDataAccess(DataContext context, IMapper mapper)
        {
            dataContext = context;
            this.mapper = mapper;
        }

        // Basic

        private Category? GetEntry(int id)
        {
            return dataContext.Categories.FirstOrDefault(c => c.ID == id);
        }

        // CRUD

        public CategoryVM Create(ICategoryData categoryData)
        {
            var created = dataContext.Add(mapper.Map<Category>(categoryData));

            try
            {
                dataContext.SaveChanges();
            }
            catch (DbUpdateException exception)
            {
                Debug.WriteLine("Creating failed: " + exception.InnerException.Message);
            }

            var result = Get(created.Entity.ID);
            var resultViewModel = mapper.Map<CategoryVM>(result);

            return resultViewModel;
        }

        public List<CategoryVM> Get()
        {
            var result = dataContext.Categories.ToList();
            var resultViewModel = mapper.Map<List<CategoryVM>>(result);

            return resultViewModel;
        }

        public CategoryVM Get(int id)
        {
            var result = GetEntry(id);

            if (result == null)
            {
                throw new Exception($"Element with ID {id} doesn't exist");
            }

            var resultViewModel = mapper.Map<CategoryVM>(result);

            return resultViewModel;
        }

        public CategoryVM Update(ICategoryData categoryData)
        {
            Category? result = GetEntry(categoryData.ID);

            if (result == null)
            {
                throw new Exception($"Category with ID {categoryData.ID} doesn't exist");
            }

            result.Name = categoryData.Name;
            result.ParentID = categoryData.ParentID;
            
            dataContext.Update(result);
            dataContext.SaveChanges();

            var resultViewModel = mapper.Map<CategoryVM>(result);
            return resultViewModel;
        }

        public CategoryVM Delete(int id)
        {
            Category? toBeDeleted = GetEntry(id);

            if (toBeDeleted == null)
            {
                throw new Exception($"Category with ID {id} doesn't exist");
            }

            ProcessChildrenOfCategory(id, ChildrenProcessAction.Transition);
            
            var deleted = dataContext.Categories.Remove(toBeDeleted);
            dataContext.SaveChanges();

            var resultViewModel = mapper.Map<CategoryVM>(deleted.Entity);
            return resultViewModel;
        }

        // Advanced

        private List<Category> GetChildrenOfCategoryEntries(int id)
        {
            return dataContext.Categories.Where(c => c.ParentID == id).ToList();
        }

        public List<CategoryVM> GetChildrenOfCategory(int id)
        {
            var result = GetChildrenOfCategoryEntries(id);
            var resultViewModel = mapper.Map<List<CategoryVM>>(result);

            return resultViewModel;
        }

        public enum ChildrenProcessAction
        {
            Unparent,
            Transition,
            Delete
        };

        public void ProcessChildrenOfCategory(int id, ChildrenProcessAction action)
        {
            var children = GetChildrenOfCategoryEntries(id);

            foreach (var child in children)
            {
                switch (action)
                {
                    case ChildrenProcessAction.Unparent:
                        child.ParentID = null;
                        dataContext.Categories.Update(child);
                        break;

                    case ChildrenProcessAction.Transition:
                        child.ParentID = Get(id).ParentID;
                        dataContext.Categories.Update(child);
                        break;

                    case ChildrenProcessAction.Delete:
                        ProcessChildrenOfCategory(child.ID, ChildrenProcessAction.Delete);
                        dataContext.Categories.Remove(child);
                        break;
                }
            }

            dataContext.SaveChanges();
        }
    }
}
