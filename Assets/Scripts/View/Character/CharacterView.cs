using Core.Foods;
using UnityEngine;
using View.Foods;

namespace View.Character
{
    public class CharacterView : MonoBehaviour
    {
        private void Start()
        {
        }

        private void Update()
        {
        }

        private void OnTriggerEnter(Collider other)
        {
            var foodView = other.gameObject.GetComponent<FoodView>();
            if (foodView == null) return;

            Core.Character.Character.Instance.Packaget.ObtainFood(foodView.Food);
            FoodsManager.Instance.RemoveFood(foodView.Food.Id);
        }
    }
}