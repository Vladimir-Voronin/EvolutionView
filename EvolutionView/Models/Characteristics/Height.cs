using System;
using System.Linq;
using EvolutionView.Models.BaseModels;

namespace EvolutionView.Models.Characteristics
{
    class Height : Сharacteristic
    {
        public int? Value { get; set; }

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
