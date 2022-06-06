using TRPO_DA;
using TRPO_DA.DataAccess;
using TRPO_BL.BusinessLogic;

using AutoMapper;

namespace TRPO_BL
{
    public class DataManager
    {
        public DataManager()
        {
            dataContext = new DataContext();

            var automapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TRPO_DM.Models.Element, TRPO_DM.ViewModels.ElementVM>();
                cfg.CreateMap<TRPO_DM.Models.Category, TRPO_DM.ViewModels.CategoryVM>(); 
                
                cfg.CreateMap<TRPO_DM.InputModels.CategoryIM, TRPO_DM.Models.Category>();
                cfg.CreateMap<TRPO_DM.InputModels.ElementIM, TRPO_DM.Models.Element>();
            });

            Mapper mapper = new Mapper(automapperConfig);

            elementDataAccess = new ElementDataAccess(dataContext, mapper);
            categoryDataAccess = new CategoryDataAccess(dataContext, mapper);

            elements = new ElementBL(elementDataAccess);
            categories = new CategoryBL(categoryDataAccess);
        }

        private DataContext dataContext;

        private ElementDataAccess elementDataAccess;
        private CategoryDataAccess categoryDataAccess;

        public ElementBL elements;
        public CategoryBL categories;
    }
}
