using Core.Characters;
using Core.Foods;
using UnityEngine;
using UnityEngine.UI;
using View.Common;

namespace View.Foods
{
    /// <summary>
    /// 背包中的食物项
    /// </summary>
    public class FoodItem : MonoBehaviour
    {
        public int FoodId { get; set; }

        private Image _foodIcon;

        private void Awake()
        {
            _foodIcon = GetComponent<Image>();
            EventTriggerListener.Get(_foodIcon.gameObject).OnClick += FoodItem_OnClick;
        }

        private void FoodItem_OnClick(GameObject foodGo)
        {
            var foodItem = foodGo.GetComponent<FoodItem>();
            var food = Character.Instance.Backpack.GetFood(foodItem.FoodId);
            if (food == null)
            {
                return;
            }

            Character.Instance.Backpack.DropFood(foodItem.FoodId);
            FoodsManager.Instance.AddFood(food);
        }

        public void SetIcon(Sprite sprite)
        {
            _foodIcon.overrideSprite = sprite;
        }
    }
}