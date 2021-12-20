using EvolutionView.Models.Organisms;

namespace EvolutionView.Models.BaseModels
{
    abstract class HumanWorld
    {
        abstract public float CalculatePointsForHumanInThisWorld(Human human);

        abstract public int getHeightMaxPoints();
        abstract public int getBodyPhysicsMaxPoints();
        abstract public int getBeautyMaxPoints();
        abstract public int getIntelligenceMaxPoints();
        abstract public int getEmotionalityMaxPoints();
        abstract public int getExtroversionMaxPoints();
        abstract public int getCreativityMaxPoints();





        public static string Name { get; set; }

        public static int HeightMaxPoints { get; set; }
        public static int BodyPhysicsMaxPoints { get; set; }
        public static int BeautyMaxPoints { get; set; }
        public static int IntelligenceMaxPoints { get; set; }
        public static int EmotionalityMaxPoints { get; set; }
        public static int ExtroversionMaxPoints { get; set; }
        public static int CreativityMaxPoints { get; set; }


        public override string ToString()
        {
            return Name;
        }
    }
}
