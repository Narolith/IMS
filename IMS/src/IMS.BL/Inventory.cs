using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace IMS.BL
{
    public class Inventory
    {
        #region Constructors
        #endregion

        #region Properties
        public static BindingList<Product> Products = new BindingList<Product>();
        public static BindingList<Part> AllParts = new BindingList<Part>();
        #endregion

        #region Methods

        public static int CalculatePartID()
        {
            int i = 0;
            foreach (var part in AllParts)
            {
                i++;
                if (i != part.PartID)
                {
                    return i;
                }
            }
            i++;
            return i;
        }

        public static int CalculateProductID()
        {
            int i = 0;
            foreach (var product in Products)
            {
                i++;
                if (i != product.ProductID)
                {
                    return i;
                }
            }
            i++;
            return i;
        }

        public static void AddProduct(Product product)
        {
            Products.Add(product);
        }

        public static bool RemoveProduct(int productID)
        {
            var product = Products.Where(p => p.ProductID == productID).FirstOrDefault();
            Products.Remove(product);
            return true;
        }

        public static Product LookupProduct(int productID)
        {
            var product = Products.Where(p => p.ProductID == productID).FirstOrDefault();
            return product;
        }

        public static void UpdateProduct(int productID, Product updatedProduct)
        {
            var productToUpdate = Products.Where(p => p.ProductID == productID).FirstOrDefault();
            productToUpdate.Name = updatedProduct.Name;
            productToUpdate.InStock = updatedProduct.InStock;
            productToUpdate.Price = updatedProduct.Price;
            productToUpdate.Min = updatedProduct.Min;
            productToUpdate.Max = updatedProduct.Max;
            productToUpdate.AssociatedParts = updatedProduct.AssociatedParts;
        }
        public static void AddPart(Part part)
        {
            AllParts.Add(part);
        }

        public static bool DeletePart(Part part)
        {
            var removePart = AllParts.Where(p => p == part).FirstOrDefault();
            AllParts.Remove(removePart);
            return true;
        }

        public static Part LookupPart(int partID)
        {
            var part = AllParts.Where(p => p.PartID == partID).FirstOrDefault();
            return part;
        }

        public static void UpdatePart(int partID, InhousePart updatedPart)
        {
            if (AllParts.Where(p => p.PartID == partID).FirstOrDefault().GetType() == typeof(InhousePart))
            {
                InhousePart partToUpdate = (InhousePart)AllParts.Where(p => p.PartID == partID).FirstOrDefault();
                partToUpdate.Name = updatedPart.Name;
                partToUpdate.InStock = updatedPart.InStock;
                partToUpdate.Price = updatedPart.Price;
                partToUpdate.Min = updatedPart.Min;
                partToUpdate.Max = updatedPart.Max;
                partToUpdate.MachineID = updatedPart.MachineID;
            }
            else
            {
                Inventory.DeletePart(AllParts.Where(p => p.PartID == partID).FirstOrDefault());
                AllParts.Add(updatedPart);
            }
        }

        public static void UpdatePart(int partID, OutsourcedPart updatedPart)
        {
            if (AllParts.Where(p => p.PartID == partID).FirstOrDefault().GetType() == typeof(OutsourcedPart))
            {
                OutsourcedPart partToUpdate = (OutsourcedPart)AllParts.Where(p => p.PartID == partID).FirstOrDefault();
                partToUpdate.Name = updatedPart.Name;
                partToUpdate.InStock = updatedPart.InStock;
                partToUpdate.Price = updatedPart.Price;
                partToUpdate.Min = updatedPart.Min;
                partToUpdate.Max = updatedPart.Max;
                partToUpdate.CompanyName = updatedPart.CompanyName;
            }
            else
            {
                Inventory.DeletePart(AllParts.Where(p => p.PartID == partID).FirstOrDefault());
                AllParts.Add(updatedPart);
            }
        }
        #endregion
    }
}
