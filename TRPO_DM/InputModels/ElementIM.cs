using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRPO_DM.Interfaces;

namespace TRPO_DM.InputModels
{
    public class ElementIM : IElementData
    {
        public ElementIM(int id, string name, string data, int categoryID)
        {
            ID = id;
            Name = name;
            Data = data;
            CategoryID = categoryID;
        }

        public int ID { get; set; }

        public string Name { get; set; }

        public string Data { get; set; }

        public int CategoryID { get; set; }
    }
}
