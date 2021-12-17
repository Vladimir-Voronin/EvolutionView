using System;
using System.Linq;
using EvolutionView.Models.BaseModels;

namespace EvolutionView.Models.Characteristics
{
    class Height : Сharacteristic
    {
        private int? _value;

        public int? Value
        {
            get { return _value; }
            set
            {
                if (value < HeightParametrsDefault.min_value) _value = HeightParametrsDefault.min_value;
                else if (value > HeightParametrsDefault.max_value) _value = HeightParametrsDefault.max_value;
                else _value = value;
            }
        }

        public Height(GeneSeries genes)
        {
            GenesObject = genes;
        }

        //public void SetValue()
        //{
        //    float percent_equals_to_1 = GenesObject.Serie.Count((x) => x.Value == 1) /GenesObject.Serie.Length;
        //    Value = Convert.ToInt32(HeightParametrsDefault.min_height + (HeightParametrsDefault.max_height - HeightParametrsDefault.min_height) * percent_equals_to_1);
        //}
    }
}
