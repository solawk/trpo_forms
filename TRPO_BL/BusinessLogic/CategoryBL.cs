using TRPO_DA.DataAccess;
using TRPO_DM.Interfaces;
using TRPO_DM.ViewModels;

namespace TRPO_BL.BusinessLogic
{
    public class CategoryBL
    {
        private CategoryDataAccess dataAccess { get; }

        public CategoryBL(CategoryDataAccess categoryDataAccess)
        {
            dataAccess = categoryDataAccess;
        }

        public CategoryVM Create(ICategoryData category)
        {
            category.ID = 0;

            return dataAccess.Create(category);
        }

        public List<CategoryVM> Read()
        {
            return dataAccess.Get();
        }

        public CategoryVM Read(int id)
        {
            try
            {
                return dataAccess.Get(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public CategoryVM Update(ICategoryData category)
        {
            return dataAccess.Update(category);
        }

        public CategoryVM Delete(int id)
        {
            return dataAccess.Delete(id);
        }
    }
}
