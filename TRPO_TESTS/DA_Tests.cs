using AutoMapper;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRPO_DA;
using TRPO_DA.DataAccess;
using TRPO_DM.InputModels;

namespace TRPO_TESTS
{
    public class DA_Tests
    {
        private DataContext dataContext;
        private Mapper mapper;
        private ElementDataAccess elementDA;
        private CategoryDataAccess categoryDA;

        public DA_Tests()
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
        }

        [Test]
        public void CreateAndDeleteCategory()
        {
            var created = categoryDA.Create(new CategoryIM(0, null, "TestCategory"));
            var deletionSuccessful = true;
            try
            {
                var deleted = categoryDA.Delete(created.ID);
            }
            catch (Exception)
            {
                deletionSuccessful = false;
            }

            Assert.That(created != null && deletionSuccessful);
        }

        [Test]
        public void CannotCreateEmptyNameCategory()
        {
            var created = categoryDA.Create(new CategoryIM(0, null, ""));

            Assert.IsNull(created);
        }

        [Test]
        public void ReadCategories()
        {
            var read = categoryDA.Get();

            Assert.NotNull(read);
        }

        [Test]
        public void ReadNewCategory()
        {
            var created = categoryDA.Create(new CategoryIM(0, null, "TestCategory"));

            var read = categoryDA.Get(created.ID);

            var deletionSuccessful = true;
            try
            {
                var deleted = categoryDA.Delete(created.ID);
            }
            catch (Exception)
            {
                deletionSuccessful = false;
            }

            Assert.That(created != null && created.Name == read.Name && created.ID == read.ID && deletionSuccessful);
        }

        [Test]
        public void UpdateAndReadNewCategory()
        {
            var created = categoryDA.Create(new CategoryIM(0, null, "TestCategory"));

            var updated = categoryDA.Update(new CategoryIM(created.ID, null, "NewTestCategory"));
            var read = categoryDA.Get(created.ID);

            var deletionSuccessful = true;
            try
            {
                var deleted = categoryDA.Delete(created.ID);
            }
            catch (Exception)
            {
                deletionSuccessful = false;
            }

            Assert.That(created != null && updated.Name == "NewTestCategory" && read.Name == "NewTestCategory" && deletionSuccessful);
        }

        [Test]
        public void CreateAndDeleteElement()
        {
            var createdCat = categoryDA.Create(new CategoryIM(0, null, "TestCategory"));

            var created = elementDA.Create(new ElementIM(0, "TestElement", "{}", createdCat.ID));
            var deletionSuccessful = true;
            try
            {
                var deleted = elementDA.Delete(created.ID);
            }
            catch (Exception)
            {
                deletionSuccessful = false;
            }

            var deletionCatSuccessful = true;
            try
            {
                var deletedCat = categoryDA.Delete(createdCat.ID);
            }
            catch (Exception)
            {
                deletionCatSuccessful = false;
            }

            Assert.That(createdCat != null && created != null && deletionSuccessful && deletionCatSuccessful);
        }

        [Test]
        public void ReadElements()
        {
            var read = elementDA.Get();        

            Assert.NotNull(read);
        }

        [Test]
        public void ReadNewElement()
        {
            var createdCat = categoryDA.Create(new CategoryIM(0, null, "TestCategory"));

            var created = elementDA.Create(new ElementIM(0, "TestElement", "{}", createdCat.ID));
            var read = elementDA.Get(created.ID);

            var deletionSuccessful = true;
            try
            {
                var deleted = elementDA.Delete(created.ID);
            }
            catch (Exception)
            {
                deletionSuccessful = false;
            }

            var deletionCatSuccessful = true;
            try
            {
                var deletedCat = categoryDA.Delete(createdCat.ID);
            }
            catch (Exception)
            {
                deletionCatSuccessful = false;
            }

            Assert.That(createdCat != null && created != null && read != null
                && read.ID == created.ID && read.Name == created.Name && deletionSuccessful && deletionCatSuccessful);
        }

        [Test]
        public void CannotCreateEmptyNameElement()
        {
            var createdCat = categoryDA.Create(new CategoryIM(0, null, "TestCategory"));

            var created = elementDA.Create(new ElementIM(0, "", "{}", createdCat.ID));

            var deletionCatSuccessful = true;
            try
            {
                var deletedCat = categoryDA.Delete(createdCat.ID);
            }
            catch (Exception)
            {
                deletionCatSuccessful = false;
            }

            Assert.That(createdCat != null && created == null && deletionCatSuccessful);
        }

        [Test]
        public void CannotCreateInvalidDataElement()
        {
            var createdCat = categoryDA.Create(new CategoryIM(0, null, "TestCategory"));

            var created = elementDA.Create(new ElementIM(0, "TestElement", "{invalidinvalidinvalid", createdCat.ID));

            var deletionCatSuccessful = true;
            try
            {
                var deletedCat = categoryDA.Delete(createdCat.ID);
            }
            catch (Exception)
            {
                deletionCatSuccessful = false;
            }

            Assert.That(createdCat != null && created == null && deletionCatSuccessful);
        }

        [Test]
        public void CannotUpdateElementWithEmptyNameOrInvalidData()
        {
            var createdCat = categoryDA.Create(new CategoryIM(0, null, "TestCategory"));

            var created = elementDA.Create(new ElementIM(0, "TestElement", "{}", createdCat.ID));

            var updatedEmptyName = elementDA.Update(new ElementIM(created.ID, "", "{}", createdCat.ID));
            var updatedInvalidData = elementDA.Update(new ElementIM(created.ID, "TestElement", "{invalidinvalid", createdCat.ID));

            var deletionSuccessful = true;
            try
            {
                var deleted = elementDA.Delete(created.ID);
            }
            catch (Exception)
            {
                deletionSuccessful = false;
            }

            var deletionCatSuccessful = true;
            try
            {
                var deletedCat = categoryDA.Delete(createdCat.ID);
            }
            catch (Exception)
            {
                deletionCatSuccessful = false;
            }

            Assert.That(createdCat != null && created != null &&
                updatedEmptyName == null && updatedInvalidData == null && deletionSuccessful && deletionCatSuccessful);
        }
    }
}
