using System;
using Core.Foods;
using UnityEngine;
using View.Foods;

namespace View.Common
{
    public class ResourceManager : MonoBehaviour
    {
        [SerializeField] private GameObject[] FoodPrefabs;

        public static ResourceManager Instance { get; private set; }

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
        }

        public GameObject InstantiateFood(Food food)
        {
            var foodPrefab = Array.Find(FoodPrefabs, p => p.name == food.FoodType.ToString());
            if (foodPrefab == null) return null;

            var foodGo = Instantiate(foodPrefab);
            var foodView = foodGo.AddComponent<FoodView>();
            foodView.Food = food;
            return foodGo;
        }
    }
}