using EvolutionView.Models.BaseModels;

namespace EvolutionView.Models.Characteristics
{
    class Intelligence : Сharacteristic
    {
        private int? _value;

        public int? Value
        {
            get { return _value; }
            set
            {
                if (value < IntelligenceParametrsDefault.min_value) _value = IntelligenceParametrsDefault.min_value;
                else if (value > IntelligenceParametrsDefault.max_value) _value = IntelligenceParametrsDefault.max_value;
                else _value = value;
            }
        }

        public Intelligence(GeneSeries genes)
        {
            GenesObject = genes;
        }
    }
}
