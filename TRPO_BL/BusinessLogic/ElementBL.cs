using TRPO_DA.DataAccess;
using TRPO_DM.Interfaces;
using TRPO_DM.InputModels;
using TRPO_DM.ViewModels;

namespace TRPO_BL.BusinessLogic
{
    public class ElementBL
    {
        private ElementDataAccess dataAccess { get; }

        public ElementBL(ElementDataAccess elementDataAccess)
        {
            dataAccess = elementDataAccess;
        }

        public ElementVM Create(IElementData element)
        {
            element.ID = 0;
            return dataAccess.Create(element);
        }

        public List<ElementVM> Read()
        {
            return dataAccess.Get();
        }

        public ElementVM Read(int id)
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

        public ElementVM Update(IElementData element)
        {
            return dataAccess.Update(element);
        }

        public ElementVM Delete(int id)
        {
            return dataAccess.Delete(id);
        }

        // Advanced

        public List<ElementVM> ReadCategory(int categoryID)
        {
            return dataAccess.ReadCategory(categoryID);
        }

        public List<ElementVM> Search(string filtersJson)
        {
            List<Filter> filters = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Filter>>(filtersJson);

            foreach (var f in filters)
            {
                Console.WriteLine("Searching " + f.type + " " + f.key + " " + f.predicate + " " + f.value);
            }

            return dataAccess.Search(filters);
        }
    }
}
