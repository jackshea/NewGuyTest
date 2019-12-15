using UnityEngine;

// 角色移动
namespace View.Character
{
    public class CharacterMovement : MonoBehaviour
    {
        private Animator _animator;
        private CharacterController _characterController;

        // 输入方向
        private Vector2 _inputDir = Vector2.zero;

        private float _speedScale = 1;

        // 移动速度
        public float Speed = 10f;

        private void Start()
        {
            _characterController = GetComponent<CharacterController>();
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            UpdateInputDir();

            // 计算朝向
            if (_inputDir != Vector2.zero)
            {
                var angle = Mathf.Atan2(_inputDir.y, _inputDir.x);
                var eulerAngles = transform.localEulerAngles;
                eulerAngles.y = -angle * Mathf.Rad2Deg;
                transform.localEulerAngles = eulerAngles;
                _speedScale = 1;
            }

            // 根据朝向位移
            if (_speedScale != 0)
            {
                var moveDir = transform.TransformDirection(Vector3.forward).normalized;
                _characterController.SimpleMove(moveDir * Speed * _speedScale);
                _speedScale = 0;
            }
            else
            {
                _characterController.SimpleMove(Vector3.zero); // 应用重力
            }

            // 播放动画
            _animator.SetBool("IsWalk", _inputDir != Vector2.zero);
        }

        /// 更新输入方向
        private void UpdateInputDir()
        {
            _inputDir = Vector2.zero;
            if (Input.GetKey(KeyCode.W)) _inputDir.y = 1;

            if (Input.GetKey(KeyCode.S)) _inputDir.y = -1;

            if (Input.GetKey(KeyCode.A)) _inputDir.x = -1;

            if (Input.GetKey(KeyCode.D)) _inputDir.x = 1;
        }
    }
}