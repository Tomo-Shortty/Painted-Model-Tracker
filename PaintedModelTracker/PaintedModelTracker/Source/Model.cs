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
        private int _totalQuantity;
        private int _paintedQuantity;

        public Model(int id, string name, int totalQuantity, int paintedQuantity)
        {
            _id = id;
            _name = name;
            _totalQuantity = totalQuantity;
            _paintedQuantity = paintedQuantity;
        }

        public int Id => _id;
        public string Name => _name;
        public int TotalQuantity => _totalQuantity;
        public int PaintedQuantity => _paintedQuantity;
    }
}
