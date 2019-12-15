using Core.Foods;
using UnityEngine;

namespace View.Foods
{
    public class FoodView : MonoBehaviour
    {
        public Food Food { get; set; }

        public void Update()
        {
            transform.Rotate(Vector3.up, 60 * Time.deltaTime);
        }
    }
}