using EvolutionView.Models.BaseModels;

namespace EvolutionView.Models.Characteristics
{
    class Extroversion : Characteristic
    {
        private int? _value;

        public int? Value
        {
            get { return _value; }
            set
            {
                if (value < ExtroversionParametrsDefault.min_value) _value = ExtroversionParametrsDefault.min_value;
                else if (value > ExtroversionParametrsDefault.max_value) _value = ExtroversionParametrsDefault.max_value;
                else _value = value;
            }
        }

        public Extroversion(GeneSeries genes)
        {
            GenesObject = genes;
        }
    }
}
