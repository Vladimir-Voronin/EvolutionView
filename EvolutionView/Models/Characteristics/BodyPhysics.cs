using EvolutionView.Models.BaseModels;

namespace EvolutionView.Models.Characteristics
{
    class BodyPhysics : Characteristic
    {
        private int? _value;

        public int? Value
        {
            get { return _value; }
            set
            {
                if (value < BodyPhisicsParametrsDefault.min_value) _value = BodyPhisicsParametrsDefault.min_value;
                else if (value > BodyPhisicsParametrsDefault.max_value) _value = BodyPhisicsParametrsDefault.max_value;
                else _value = value;
            }
        }

        public BodyPhysics(GeneSeries genes)
        {
            GenesObject = genes;
        }
    }
}
