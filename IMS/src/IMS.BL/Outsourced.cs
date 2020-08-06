using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.BL
{
    public class OutsourcedPart : Part
    {
        #region Constructors
        public OutsourcedPart(int partID, string name, int inStock, decimal? price, int min, int max, string companyName)
        {
            PartID = partID;
            Name = name;
            InStock = inStock;
            Price = price;
            Min = min;
            Max = max;
            CompanyName = companyName;
        }
        #endregion

        #region Properties
        public string CompanyName { get; set; }
        #endregion

        #region Methods
        #endregion
    }
}
