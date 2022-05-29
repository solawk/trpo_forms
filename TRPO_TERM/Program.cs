using TRPO_BL;

DataManager manager = new DataManager();

var allElements = manager.elements.Read();
Console.WriteLine("Elements:");
foreach (var e in allElements)
{
    Console.WriteLine(e.Name + "(id = " + e.ID + ", category id = " + e.CategoryID + ", category name = " + e.Category.Name
        + ", data = " + e.Data + ", image URI = " + e.ImageURI + ")");
}

var allCategories = manager.categories.Read();
Console.WriteLine("Categories:");
foreach (var c in allCategories)
{
    Console.WriteLine(c.Name + "(id = " + c.ID + ", parent id = " + (c.ParentID != null ? c.ParentID.ToString() : "none") + ")");
}

Console.ReadLine();