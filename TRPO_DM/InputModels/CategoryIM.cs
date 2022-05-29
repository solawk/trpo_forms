using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRPO_DM.Interfaces;

namespace TRPO_DM.InputModels
{
    public class CategoryIM : ICategoryData
    {
        public CategoryIM(int id, int? parentID, string name)
        {
            ID = id;
            ParentID = parentID;
            Name = name;
        }

        public int ID { get; set; }

        public int? ParentID { get; set; }

        public string Name { get; set; }
    }
}
