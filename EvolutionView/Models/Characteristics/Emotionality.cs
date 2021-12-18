using EvolutionView.Models.BaseModels;

namespace EvolutionView.Models.Characteristics
{
    class Emotionality : Сharacteristic
    {
        private int? _value;

        public int? Value
        {
            get { return _value; }
            set
            {
                if (value < EmotionalityParametrsDefault.min_value) _value = EmotionalityParametrsDefault.min_value;
                else if (value > EmotionalityParametrsDefault.max_value) _value = EmotionalityParametrsDefault.max_value;
                else _value = value;
            }
        }

        public Emotionality(GeneSeries genes)
        {
            GenesObject = genes;
        }
    }
}
