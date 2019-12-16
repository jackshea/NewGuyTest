using System;
using System.Collections.Generic;
using Core.Foods;

namespace Core.Characters
{
    /// <summary>
    ///     背包
    /// </summary>
    public class Package
    {
        public List<Food> Foods { get; } = new List<Food>();
        public event Action<Food> OnObtainedFood;
        public event Action<Food> OnDroppedFood;

        /// <summary>
        ///     获得食物
        /// </summary>
        public bool ObtainFood(Food food)
        {
            var existFood = Foods.Find(p => p.Id == food.Id);
            if (existFood != null) return false;

            Foods.Add(food);
            OnObtainedFood?.Invoke(food);
            return true;
        }

        /// <summary>
        ///     丢弃食物
        /// </summary>
        /// <param name="foodId"></param>
        /// <returns></returns>
        public bool DropFood(int foodId)
        {
            var food = Foods.Find(p => p.Id == foodId);
            if (food == null) return false;

            var success = Foods.Remove(food);
            if (success) OnDroppedFood?.Invoke(food);

            return success;
        }
    }
}