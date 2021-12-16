using EvolutionView.Infrastructure.HelpClasses;
using EvolutionView.Models.BaseModels;
using EvolutionView.Models.Characteristics;
using EvolutionView.Models.Organisms;

namespace EvolutionView.Models.Worlds
{
    class BasketballPlayersWorld : HumanWorld
    {
        public static string Name { get; set; } = "Basketball Players";

        public override float CalculatePointsForHumanInThisWorld(Human human)
        {
            float points = 0;

            points += EvaluateHeight(human.HeightObject);

            return points;
        }

        #region Evaluation Methods

        private float EvaluateHeight(Height height)
        {
            if (height != null && height.Value.HasValue)
            {
                return EvaluatePro.LinearFunction(HeightParametrsDefault.min_height, HeightParametrsDefault.max_height, 200, height.Value.Value);
            }
            return 0;
        }

        #endregion
    }
}
