using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField]
    private GameObject _bulletPrefab;

    [SerializeField]
    private float _bulletSpeed;

    [SerializeField]
    private Transform _gunOffset;

    [SerializeField]
    private float _timeBetweenShots;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private Animator effect;

    /*[SerializeField]
    private AudioSource handgunShoot;*/


    private bool _fireContinuously;
    private bool _fireSingle;
    private float _lastFireTime;
    


    void Update()
    {
       animator.SetBool("isShoot", false);
       effect.SetBool("isShoot", false);
        if (_fireContinuously || _fireSingle)
        {
            float timeSinceLastFire = Time.time - _lastFireTime;

            if (timeSinceLastFire >= _timeBetweenShots)
            {
                FireBullet();
                _lastFireTime = Time.time;
                _fireSingle = false;
                AudioManager.Instance.PlaySFX("Handgun");
                effect.SetBool("isShoot", true);
                // handgunShoot.Play();
            }
            animator.SetBool("isShoot", true);
            effect.SetBool("isShoot", true);
        }
    }

    private void FireBullet()
    {
        GameObject bullet = Instantiate(_bulletPrefab, _gunOffset.position, transform.rotation);
        Rigidbody2D rigidbody = bullet.GetComponent<Rigidbody2D>();

        rigidbody.velocity = _bulletSpeed * transform.right;
    }


    private void OnFire(InputValue inputValue)
    {
        _fireContinuously = inputValue.isPressed;

        if (inputValue.isPressed)
        {
            effect.SetBool("isShoot", true);
            _fireSingle = true;
        }
    }
}
