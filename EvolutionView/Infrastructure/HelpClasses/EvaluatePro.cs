using System;
using System.Collections.Generic;
using System.Text;

namespace EvolutionView.Infrastructure.HelpClasses
{
    static class EvaluatePro
    {
        public static float LinearFunction(int min, int max, int max_points, int current_value, bool IsUpper = true)
        {
            max = max - min;
            current_value = current_value - min;
            float percent = (float)current_value / max;

            if (IsUpper) return percent * max_points;
            else return (1 - percent) * max_points;
        }
    }
}
