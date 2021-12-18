using EvolutionView.Models.BaseModels;

namespace EvolutionView.Models.Characteristics
{
    class Beauty : Characteristic
    {
        private int? _value;

        public int? Value
        {
            get { return _value; }
            set
            {
                if (value < BeautyParametrsDefault.min_value) _value = BeautyParametrsDefault.min_value;
                else if (value > BeautyParametrsDefault.max_value) _value = BeautyParametrsDefault.max_value;
                else _value = value;
            }
        }

        public Beauty(GeneSeries genes)
        {
            GenesObject = genes;
        }
    }
}
