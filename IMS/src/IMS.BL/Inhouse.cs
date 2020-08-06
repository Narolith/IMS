using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.BL
{
    public class InhousePart : Part
    {

        #region Constructors
        public InhousePart(int partID, string name, int inStock, decimal? price, int min, int max, int machineID)
        {
            PartID = partID;
            Name = name;
            InStock = inStock;
            Price = price;
            Min = min;
            Max = max;
            MachineID = machineID;
        }
        #endregion

        #region Properties
        public int MachineID { get; set; }
        #endregion

        #region Methods
        #endregion
    }
}
