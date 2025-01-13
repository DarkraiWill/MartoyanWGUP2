using System;
using System.Linq;

namespace MartoyanWGUP2.Classes
{
    internal class ProductionClass
    {
        ProductionDBEntities _context = ProductionDBEntities.GetContext();
        public int GetProductionCount(int ProdID, int MatTypeID, int CountNeeded, double Fp, double Sp)
        {
            if (Fp < 0 || Sp < 0)
            {
                return -1;
            }
            double Coeficent = (double)_context.ProductTypes.FirstOrDefault(x => x.ID == ProdID).Coefficient;
            double DefectRate = (double)_context.MaterialTypes.FirstOrDefault(x => x.ID == MatTypeID).DefectRate;

            if (Coeficent == 0 || DefectRate == 0)
            {
                return -1;
            }
            double MaterialForOneProduction = Fp * Sp * Coeficent;

            return (int)Math.Ceiling(Convert.ToDouble(CountNeeded) / (MaterialForOneProduction * (1.0 + DefectRate)));
        }
    }
}
