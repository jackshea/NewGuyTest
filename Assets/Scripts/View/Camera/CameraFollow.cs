using UnityEngine;

namespace View.Camera
{
    public class CameraFollow : MonoBehaviour
    {
        public Vector3 Offset;
        public Transform Target;

        private void Start()
        {
        }

        private void Update()
        {
            transform.position = Target.position + Offset;
            transform.LookAt(Target);
        }
    }
}