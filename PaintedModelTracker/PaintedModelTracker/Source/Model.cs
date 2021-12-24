using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintedModelTracker.Source
{
    internal class Model
    {
        private int _id;
        private string _name;
        private int _quantity;
        private int _painted;
        private int _notPainted;
        private decimal _percentagePainted;

        public Model(int id, string name, int quantity, int painted)
        {
            _id = id;
            if (name == null)
            {
                throw new Exception("Please enter a name.");
            }
            else if (quantity <= 0)
            {
                throw new Exception("Model quantity cannot be 0 or less");
            }
            else
            {
                _name = name;
                _quantity = quantity;
                _painted = painted;
                _notPainted = quantity - painted;
                _percentagePainted = Math.Round(Convert.ToDecimal((painted / quantity) * 100), 2);
            }            
        }

        public int Id => _id;
        public string Name => _name;
        public int Quantity => _quantity;
        public int Painted => _painted;
        public int NotPainted => _notPainted;
        public decimal PercentagePainted => _percentagePainted;

        public void UpdateModel(string name, int quantity, int painted)
        {
            if (name == null)
            {
                throw new Exception("Please enter a name.");
            }
            else if (quantity <= 0)
            {
                throw new Exception("Model quantity cannot be 0 or less");
            }
            else
            {
                _name = name;
                _quantity = quantity;
                _painted = painted;
                _notPainted = quantity - painted;
                _percentagePainted = Math.Round(Convert.ToDecimal((painted / quantity) * 100), 2);
            }
        }
    }
}
