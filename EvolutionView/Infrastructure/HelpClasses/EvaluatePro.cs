using System;
using System.Collections.Generic;
using System.Text;
using EvolutionView.Infrastructure;

namespace EvolutionView.Infrastructure.HelpClasses
{
    static class EvaluatePro
    {
        public static float LinearFunctionFloat(int min, int max, int max_points, int current_value, bool IsUpper = true)
        {
            max = max - min;
            current_value = current_value - min;
            float percent = (float)current_value / max;

            float a = percent * max_points;
            float b = (1 - percent) * max_points;


            if (IsUpper) return percent * max_points;
            else return (1 - percent) * max_points;
        }
        
        public static float LinearFunctionFloatWithFlatMax(int min, int max, int max_points, int current_value, int flat_value)
        {
            if (current_value >= flat_value) return max_points;

            flat_value = flat_value - min;
            current_value = current_value - min;
            float percent = (float)current_value / flat_value;
            return percent * max_points;
        }

        public static float LinearFunctionFloatWithLocalMax(int min, int max, int max_points, int current_value, int local_max)
        {
            if (current_value > 90)
            {
                _ = 1;
            }

            local_max = local_max - min;
            current_value = current_value - min;
            float step =  max_points / (float)local_max;
            if (current_value <= local_max)
            {
                float check = step * current_value;
                return step * current_value;
            }
            else
            {
                float check = max_points - step * (current_value - local_max);
                return max_points - step * (current_value - local_max);

            }

        }

        private static int LinearFunction(float first_coef, float second_coef, int first_val, int second_value, float search_coef)
        {
            second_coef = second_coef - first_coef;
            search_coef = search_coef - first_coef;
            first_coef = 0;

            float percent = search_coef / second_coef;

            if(first_val > second_value)
                return Convert.ToInt32(first_val - (first_val - second_value) * percent);  
            else
                return Convert.ToInt32(first_val + (second_value - first_val) * percent);
        }

        public static int LinearFunctionIntRandomByLists(List<(float, float)> coef, List<(int, int)> values)
        {
            if (coef.Count != values.Count) throw new Exception("Lengthes of Lists not equals to each other");

            float randomFloat = (float)StaticVariables.Rand.NextDouble();

            int i = 0;
            float first_coef = -1;
            float second_coef = -1;
            foreach (var (first, second) in coef)
            {
                if(randomFloat >= first && randomFloat <= second)
                {
                    first_coef = first;
                    second_coef = second;
                    break;
                }
                i++;
            }

            int first_value = values[i].Item1;
            int second_value = values[i].Item2;

            return LinearFunction(first_coef, second_coef, first_value, second_value, randomFloat); ;
        }

        public static float LinearFunctionFloatByLists(List<(int, int)> coef, List<(int, int)> values, int current_value)
        {
            if(current_value > 90)
            {
                _ = 1;
            }
            int i = 0;
            int first_coef = -1;
            int second_coef = -1;
            foreach (var (first, second) in coef)
            {
                if (current_value >= first && current_value <= second)
                {
                    first_coef = first;
                    second_coef = second;
                    break;
                }
                i++;
            }
            int first_value = values[i].Item1;
            int second_value = values[i].Item2;

            if (first_value == second_value)
                return first_value;

            else if(second_value > first_value)
            {
                return LinearFunctionFloat(first_value, second_coef, second_value, current_value, true);
            }
            else
            {
                float step = (float)(first_value - second_value)/ (second_coef - first_coef);
                int shift = current_value - first_coef;
                float a = first_value - (shift * step);
                return first_value - (shift * step);
            }
        }
    }
}
