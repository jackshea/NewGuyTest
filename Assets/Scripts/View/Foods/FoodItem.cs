using UnityEngine;
using UnityEngine.UI;

namespace View.Foods
{
    public class FoodItem : MonoBehaviour
    {
        private Image _foodIcon;

        public void SetIcon(Sprite sprite)
        {
            _foodIcon = GetComponent<Image>();
            _foodIcon.overrideSprite = sprite;
        }
    }
}