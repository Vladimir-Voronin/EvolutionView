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
                if (value < HeightParametrsDefault.min_value) _value = HeightParametrsDefault.min_value;
                else if (value > HeightParametrsDefault.max_value) _value = HeightParametrsDefault.max_value;
                else _value = value;
            }
        }

        public Intelligence(GeneSeries genes)
        {
            GenesObject = genes;
        }
    }
}
