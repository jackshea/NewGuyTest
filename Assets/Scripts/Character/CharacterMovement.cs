using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 角色移动
public class CharacterMovement : MonoBehaviour
{
    // 移动速度
    public float Speed = 10f;

    // 输入方向
    private Vector2 _inputDir = Vector2.zero;

    private CharacterController _characterController;
    private float SpeedScale = 1;
    private Animator _animator;

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        UpdateInputDir();

        // 计算朝向
        if (_inputDir != Vector2.zero)
        {
            var angle = Mathf.Atan2(_inputDir.y, _inputDir.x);
            var eulerAngles = transform.localEulerAngles;
            eulerAngles.y = -angle * Mathf.Rad2Deg;
            transform.localEulerAngles = eulerAngles;
            SpeedScale = 1;
        }

        // 根据朝向位移
        if (SpeedScale != 0)
        {
            var moveDir = transform.TransformDirection(Vector3.forward).normalized;
            _characterController.SimpleMove(moveDir * Speed * SpeedScale);
            SpeedScale = 0;
        }
        else
        {
            _characterController.SimpleMove(Vector3.zero);// 应用重力
        }

        _animator.SetBool("IsWalk", _inputDir != Vector2.zero);
    }

    /// 更新输入方向
    private void UpdateInputDir()
    {
        _inputDir = Vector2.zero;
        if (Input.GetKey(KeyCode.W))
        {
            _inputDir.y = 1;
        }

        if (Input.GetKey(KeyCode.S))
        {
            _inputDir.y = -1;
        }

        if (Input.GetKey(KeyCode.A))
        {
            _inputDir.x = -1;
        }

        if (Input.GetKey(KeyCode.D))
        {
            _inputDir.x = 1;
        }
    }
}
