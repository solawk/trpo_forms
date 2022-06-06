using AutoMapper;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRPO_BL.BusinessLogic;
using TRPO_DA;
using TRPO_DA.DataAccess;
using TRPO_DM.InputModels;

namespace TRPO_TESTS
{
    public class BL_Tests
    {
        private DataContext dataContext;
        private Mapper mapper;
        private ElementDataAccess elementDA;
        private CategoryDataAccess categoryDA;
        private ElementBL elementBL;
        private CategoryBL categoryBL;

        public BL_Tests()
        {
            dataContext = new DataContext();

            var automapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TRPO_DM.Models.Element, TRPO_DM.ViewModels.ElementVM>();
                cfg.CreateMap<TRPO_DM.Models.Category, TRPO_DM.ViewModels.CategoryVM>(); 
                
                cfg.CreateMap<TRPO_DM.InputModels.CategoryIM, TRPO_DM.Models.Category>();
                cfg.CreateMap<TRPO_DM.InputModels.ElementIM, TRPO_DM.Models.Element>();
            });

            mapper = new Mapper(automapperConfig);

            elementDA = new ElementDataAccess(dataContext, mapper);
            categoryDA = new CategoryDataAccess(dataContext, mapper);

            elementBL = new ElementBL(elementDA);
            categoryBL = new CategoryBL(categoryDA);
        }

        [Test]
        public void SubstitutingIDZeroForCategory()
        {
            var created = categoryBL.Create(new CategoryIM(99, null, "TestCategory"));

            var deletionSuccessful = true;
            try
            {
                var deleted = categoryBL.Delete(created.ID);
            }
            catch (Exception)
            {
                deletionSuccessful = false;
            }

            Assert.That(created != null && deletionSuccessful);
        }

        [Test]
        public void SubstitutingIDZeroForElement()
        {
            var createdCat = categoryBL.Create(new CategoryIM(0, null, "TestCategory"));

            var created = elementBL.Create(new ElementIM(99, "TestElement", "{}", createdCat.ID));

            var deletionSuccessful = true;
            try
            {
                var deleted = elementBL.Delete(created.ID);
            }
            catch (Exception)
            {
                deletionSuccessful = false;
            }

            var deletionCatSuccessful = true;
            try
            {
                var deletedCat = categoryBL.Delete(createdCat.ID);
            }
            catch (Exception)
            {
                deletionCatSuccessful = false;
            }

            Assert.That(createdCat != null && created != null && deletionSuccessful && deletionCatSuccessful);
        }

        [Test]
        public void SearchElements()
        {
            var result = elementBL.Search("[{\"type\":2,\"key\":\"\",\"value\":1,\"predicate\":0}]");

            Assert.NotNull(result);
        }
    }
}
