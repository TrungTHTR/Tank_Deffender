using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField]
    private GameObject _bulletPrefab;

    [SerializeField]
    private float _bulletSpeed;

    [SerializeField]
    private Transform _gunOffset;

    [SerializeField]
    private float fireRate;

    
    [SerializeField]
    private Animator effect;


    private PlayerAwarenessController _playerAwarenessController;
    private float _lastFireTime;

    // Start is called before the first frame update
    void Awake()
    {
        _playerAwarenessController = GetComponent<PlayerAwarenessController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        HandlePlayerTargeting();
    }
    private void HandlePlayerTargeting()
    {
        if (_playerAwarenessController.AwareOfPlayer) //if AwareOfPlayer true
        {
            if (_lastFireTime < Time.time)
            {
                effect.SetBool("isShoot", false);
                _lastFireTime = Time.time+fireRate;
                FireBullet();
            }               
        }
    }
    private void FireBullet()
    {
        effect.SetBool("isShoot", true);
        GameObject bullet = Instantiate(_bulletPrefab, _gunOffset.position, transform.rotation);
        Rigidbody2D rigidbody = bullet.GetComponent<Rigidbody2D>();
        rigidbody.velocity = _bulletSpeed * transform.up;
    }
}
