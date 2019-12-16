using System.Collections.Generic;
using Core.Foods;
using UnityEngine;
using View.Common;

namespace View.Foods
{
    /// <summary>
    ///     管理场景中的食物
    /// </summary>
    public class FoodManagerView : MonoBehaviour
    {
        private const int Range = 10;
        private readonly Dictionary<int, GameObject> foodView = new Dictionary<int, GameObject>();

        public void Start()
        {
            FoodsManager.Instance.OnAddFood += handleOnAddFood;
            FoodsManager.Instance.OnRemoveFood += handleOnRemoveFood;
            FoodsManager.Instance.Init();
        }

        public void OnDestroy()
        {
            FoodsManager.Instance.OnAddFood -= handleOnAddFood;
            FoodsManager.Instance.OnRemoveFood -= handleOnRemoveFood;
        }

        private void handleOnRemoveFood(Food food)
        {
            GameObject foodGo = null;
            if (foodView.TryGetValue(food.Id, out foodGo))
            {
                foodView.Remove(food.Id);
                Destroy(foodGo);
            }
        }

        private void handleOnAddFood(Food food)
        {
            var foodGo = ResourceManager.Instance.InstantiateFood(food);
            foodGo.transform.SetParent(transform);
            foodGo.transform.localPosition = new Vector3(Random.Range(0f, Range), 0, Random.Range(0f, Range));
            foodView.Add(food.Id, foodGo);
        }
    }
}