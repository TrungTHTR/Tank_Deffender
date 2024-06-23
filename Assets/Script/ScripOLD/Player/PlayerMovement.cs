using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    /*[SerializeField]
    private float _rotationSpeed;*/

    [SerializeField]
    private float _screenBorder;
    [SerializeField]
     public Animator animator;
    [SerializeField]
    public Animator animatorFeet;

    private Rigidbody2D _rigidbody;
    private Vector2 _movementInput;
    private Vector2 _smoothedMovementInput;
    private Vector2 _movementInputSmoothVelocity;
    private Camera _camera;
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _camera = Camera.main;
        animator.SetBool("isMove", false);
        animatorFeet.SetBool("isMove", false);
    }

    private void FixedUpdate()
    {
        SetPlayerVelocity();
        //RotateInDirectionOfInput();
        mouseRotation();
    }

    
    private void mouseRotation()
    {
        /*mousePos = _camera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = mousePos - transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) + Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ);*/

        SetPlayerVelocity();

        Vector3 mouse = Input.mousePosition;
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.localPosition);
        Vector2 offSet = new Vector2(mouse.x - screenPoint.x, mouse.y - screenPoint.y);
        
        float angle  = Mathf.Atan2(offSet.y, offSet.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void SetPlayerVelocity()
    {
        _smoothedMovementInput = Vector2.SmoothDamp(
                    _smoothedMovementInput,
                    _movementInput,
                    ref _movementInputSmoothVelocity,
                    0.1f);

        _rigidbody.velocity = _smoothedMovementInput * _speed;
        PreventPlayerGoingOffScreen();
        //animator.SetBool("isMove", true);
        //animatorFeet.SetBool("isMove", true);
    }

    private void PreventPlayerGoingOffScreen()
    {
        Vector2 screenPosition = _camera.WorldToScreenPoint(transform.position);

        if ((screenPosition.x < _screenBorder && _rigidbody.velocity.x < 0) ||
            (screenPosition.x > _camera.pixelWidth - _screenBorder && _rigidbody.velocity.x > 0))
        {
            _rigidbody.velocity = new Vector2(0, _rigidbody.velocity.y);
        }

        if ((screenPosition.y < _screenBorder && _rigidbody.velocity.y < 0) ||
            (screenPosition.y > _camera.pixelHeight - _screenBorder && _rigidbody.velocity.y > 0))
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, 0);
        }
    }

    private void RotateInDirectionOfInput()
    {
        if (_movementInput != Vector2.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(transform.forward, _smoothedMovementInput);
            //Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);

            _rigidbody.MoveRotation(targetRotation);
        }
    }

    private void OnMove(InputValue inputValue)
    {
            _movementInput = inputValue.Get<Vector2>(); 
        if(_movementInput != Vector2.zero)
        {
            animator.SetBool("isMove", true);
            animatorFeet.SetBool("isMove", true);
        }else
        {
            animator.SetBool("isMove", false);
            animatorFeet.SetBool("isMove", false);
        }
    }
}
