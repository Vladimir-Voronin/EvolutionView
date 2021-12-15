using System;
using System.Linq;
using EvolutionView.Models.BaseModels;

namespace EvolutionView.Models.Characteristics
{
    class Height : Сharacteristic
    {
        public int? Value { get; set; }
        public readonly int min_height;
        public readonly int max_height;

        public override GeneSeries GenesObject { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Height(int min, int max)
        {
            min_height = min;
            max_height = max;
        }

        public void SetValue()
        {
            float percent_equals_to_1 = GenesObject.Serie.Count((x) => x.Value == 1) /GenesObject.Serie.Length;
            Value = Convert.ToInt32(min_height + (max_height - min_height) * percent_equals_to_1);
        }
    }
}
