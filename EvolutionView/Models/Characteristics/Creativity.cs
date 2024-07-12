using EvolutionView.Models.BaseModels;

namespace EvolutionView.Models.Characteristics
{
    class Creativity : Characteristic
    {
        private int? _value;

        public int? Value
        {
            get { return _value; }
            set
            {
                if (value < CreativityParametrsDefault.min_value) _value = CreativityParametrsDefault.min_value;
                else if (value > CreativityParametrsDefault.max_value) _value = CreativityParametrsDefault.max_value;
                else _value = value;
            }
        }

        public Creativity(GeneSeries genes)
        {
            GenesObject = genes;
        }
    }
}
