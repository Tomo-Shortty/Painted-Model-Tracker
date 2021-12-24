using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintedModelTracker.Source
{
    internal class ModelList
    {
        private int _id;
        private string _name;
        private List<Model> _models;
        private int _totalModelQuantity;
        private int _totalPaintedModelQuantity;
        private int _totalNotPainted;
        private decimal _percentagePainted;

        public ModelList(int id, string name)
        {
            _id = id;
            _name = name;
            _models = new List<Model>();
        }

        public int Id => _id;
        public string Name => _name;
        public List<Model> Models => _models;
        public int TotalModelQuantity => _totalModelQuantity;
        public int TotalPaintedModelQuantity => _totalPaintedModelQuantity;
        public int TotalNotPainted => _totalNotPainted;
        public decimal PercentagePainted => _percentagePainted;

        public void AddModel(Model newModel)
        {
            Models.Add(newModel);
            UpdateTotals();
        }

        public void RemoveModel(Model selectedModel)
        {
            Models.Remove(selectedModel);
            UpdateTotals();
        }

        public void ClearList()
        {
            Models.Clear();
            _totalModelQuantity = 0;
            _totalPaintedModelQuantity = 0;
            _totalNotPainted = 0;
            _percentagePainted = 0;
        }

        private void UpdateTotals()
        {
            foreach (var model in Models)
            {
                _totalModelQuantity += model.TotalQuantity;
                _totalPaintedModelQuantity += model.PaintedQuantity;
            }
            _totalNotPainted = _totalModelQuantity - _totalPaintedModelQuantity;
            _percentagePainted = (_totalPaintedModelQuantity / _totalModelQuantity) * 100;
        }
    }
}
