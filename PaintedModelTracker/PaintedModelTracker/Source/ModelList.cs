using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintedModelTracker.Source
{
    internal class ModelList
    {
        private List<Model> _models;
        private int _totalModelQuantity;
        private int _totalPaintedModelQuantity;
        private int _totalNotPainted;
        private decimal _totalPercentagePainted;

        public ModelList()
        {
            _models = new List<Model>();
        }

        public List<Model> Models => _models;
        public int TotalModelQuantity => _totalModelQuantity;
        public int TotalPaintedModelQuantity => _totalPaintedModelQuantity;
        public int TotalNotPainted => _totalNotPainted;
        public decimal TotalPercentagePainted => _totalPercentagePainted;

        public void AddModel(Model newModel)
        {
            Models.Add(newModel);
            UpdateTotals();
        }

        public void RemoveModel(int index)
        {
            Models.RemoveAt(index);
            UpdateTotals();
        }

        public void ClearList()
        {
            Models.Clear();
            _totalModelQuantity = 0;
            _totalPaintedModelQuantity = 0;
            _totalNotPainted = 0;
            _totalPercentagePainted = 0;
        }

        private void UpdateTotals()
        {
            foreach (var model in Models)
            {
                _totalModelQuantity += model.Quantity;
                _totalPaintedModelQuantity += model.Painted;
            }
            _totalNotPainted = _totalModelQuantity - _totalPaintedModelQuantity;
            _totalPercentagePainted = Math.Round(Convert.ToDecimal((_totalPaintedModelQuantity / _totalModelQuantity) * 100), 2);
        }
    }
}
