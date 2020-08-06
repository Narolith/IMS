using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.BL
{
    public abstract class Part
    {
        #region Constructors
        #endregion

        #region Properties
        public int PartID { get; set; }
        public string Name { get; set; }
        public int InStock { get; set; }
        public decimal? Price { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }
        #endregion

        #region Methods
        #endregion
    }
}
