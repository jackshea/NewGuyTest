using Core.Common;

namespace Core.Foods
{
    public class Food : Entity
    {
        public Food()
        {
        }

        public Food(int id, FoodType type)
        {
            Id = id;
            FoodType = type;
        }

        public FoodType FoodType { get; }
    }
}