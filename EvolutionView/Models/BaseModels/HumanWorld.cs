using EvolutionView.Models.Organisms;

namespace EvolutionView.Models.BaseModels
{
    abstract class HumanWorld
    {
        abstract public float CalculatePointsForHumanInThisWorld(Human human);
    }
}
