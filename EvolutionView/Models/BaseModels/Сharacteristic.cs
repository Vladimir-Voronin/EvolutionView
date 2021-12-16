using System;
using System.Collections.Generic;
using System.Text;

namespace EvolutionView.Models.BaseModels
{
    class Сharacteristic
    {
        public GeneSeries GenesObject { get; set; }

        public virtual int StartIndex { get; set; }
        public virtual int EndIndex { get; set; }
    }
}
