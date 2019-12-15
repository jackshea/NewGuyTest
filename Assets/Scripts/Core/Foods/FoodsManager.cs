using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

namespace Core.Foods
{
    /// <summary>
    /// 管理场景中的食物
    /// </summary>
    public class FoodsManager
    {
        public event Action<Food> OnAddFood;
        public event Action<Food> OnRemoveFood;

        public List<Food> Foods { get; private set; } = new List<Food>();

        public static FoodsManager Instance { get; } = new FoodsManager();

        private int SpawnFoodId;

        private FoodsManager()
        {

        }

        public void Init()
        {
            // 生成初始食物
            var foodTypeLength = Enum.GetValues(typeof(FoodType)).Length;
            for (int i = 0; i < 30; i++)
            {
                var type = (FoodType)Random.Range(0, foodTypeLength);
                Spawn(type);
            }
        }

        /// <summary>
        /// 生成食物
        /// </summary>
        public Food Spawn(FoodType type)
        {
            var newFood = new Food(SpawnFoodId++, type);
            AddFood(newFood);
            return newFood;
        }

        /// <summary>
        /// 添加食物
        /// </summary>
        public bool AddFood(Food food)
        {
            var existFood = Foods.Find(p => p.Id == food.Id);
            if (existFood != null)
            {
                return false;
            }

            Foods.Add(food);
            OnAddFood?.Invoke(food);
            return true;
        }

        /// <summary>
        /// 减少食物
        /// </summary>
        /// <param name="foodId">食物Id</param>
        /// <returns></returns>
        public bool RemoveFood(int foodId)
        {
            var food = Foods.Find(p => p.Id == foodId);
            if (food == null)
            {
                return false;
            }

            var success = Foods.Remove(food);
            if (success)
            {
                OnRemoveFood?.Invoke(food);
            }

            return success;
        }
    }
}