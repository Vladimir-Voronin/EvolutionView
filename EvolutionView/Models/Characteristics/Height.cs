using System;
using System.Linq;
using EvolutionView.Models.BaseModels;

namespace EvolutionView.Models.Characteristics
{
    class Height : Сharacteristic
    {
        public int? Value { get; set; }

        public override int StartIndex { get; set; }
        public override int EndIndex { get; set; }

        public Height(GeneSeries genes, int start_ind, int end_ind)
        {
            GenesObject = genes;
            StartIndex = start_ind;
            EndIndex = end_ind;
        }

        public void SetValue()
        {
            float percent_equals_to_1 = GenesObject.Serie.Count((x) => x.Value == 1) /GenesObject.Serie.Length;
            Value = Convert.ToInt32(HeightParametrsDefault.min_height + (HeightParametrsDefault.max_height - HeightParametrsDefault.min_height) * percent_equals_to_1);
        }
    }
}
