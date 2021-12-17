using System;
using System.Collections.Generic;
using System.Text;

namespace EvolutionView.Models.BaseModels
{
    static class CharacteristicParametrsDefault
    {
        public static bool IsActive = true;
        public static string Name;
        public static readonly int min_genes;
        public static readonly int max_genes;

        public static int StartIndex { get; set; }
        public static int EndIndex { get; set; }
    }
}
