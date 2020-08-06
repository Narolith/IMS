using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace IMS.BL
{
    public class Product
    {
        #region Constructors
        public Product()
        {
            AssociatedParts = new BindingList<Part>();
        }

        public Product(BindingList<Part> associatedParts, int productID, string name, decimal? price, int inStock, int min, int max)
        {
            AssociatedParts = associatedParts;
            ProductID = productID;
            Name = name;
            Price = price;
            InStock = inStock;
            Min = min;
            Max = max;
        }
        #endregion

        #region Properties
        public BindingList<Part> AssociatedParts { get; set; }
        public int ProductID { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public int InStock { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }
        #endregion

        #region Methods
        public void AddAssociatedPart(Part part)
        {
            AssociatedParts.Add(part);
        }
        public bool RemoveAssociatedPart(int partID)
        {
            var part = AssociatedParts.Where(p => p.PartID == partID).FirstOrDefault();
            AssociatedParts.Remove(part);
            return true;
        }
        public Part LookupAssociatedPart(int partID)
        {
            var part = AssociatedParts.Where(p => p.PartID == partID).FirstOrDefault();
            return part;
        }
        #endregion
    }
}
