using Core.Characters;
using Core.Foods;
using UnityEngine;
using View.Common;
using View.Foods;

namespace View.GUI
{
    public class BackpackUI : MonoBehaviour
    {
        private ItemList _itemList;

        private void Start()
        {
            var refs = GetComponent<GameObjectRef>();
            EventTriggerListener.Get(refs["Close"]).OnClick += Close_OnClick;
            var foods = refs["Foods"];
            _itemList = foods.GetComponent<ItemList>();
            Character.Instance.Backpack.OnObtainedFood += HandleOnObtainedFood;
            Character.Instance.Backpack.OnDroppedFood += HandleOnDroppedFood;
            Refresh();
        }

        private void OnDestroy()
        {
            Character.Instance.Backpack.OnObtainedFood -= HandleOnObtainedFood;
            Character.Instance.Backpack.OnDroppedFood -= HandleOnDroppedFood;
        }

        private void HandleOnDroppedFood(Food obj)
        {
            Refresh();
        }

        private void HandleOnObtainedFood(Food obj)
        {
            Refresh();
        }

        private void Close_OnClick(GameObject obj)
        {
            gameObject.SetActive(false);
        }

        private void Refresh()
        {
            _itemList.Reset();
            for (var i = 0; i < Character.Instance.Backpack.Foods.Count; i++)
            {
                var food = Character.Instance.Backpack.Foods[i];
                _itemList.Refresh(i, food, DrawFood);
            }
        }

        private void DrawFood(Food food, GameObject itemGo)
        {
            var foodItem = itemGo.GetComponent<FoodItem>();
            foodItem.name = food.FoodType + "_" + food.Id;
            foodItem.FoodId = food.Id;
            var foodIcon = ResourceManager.Instance.GetFoodIcon(food.FoodType);
            foodItem.SetIcon(foodIcon);
        }
    }
}