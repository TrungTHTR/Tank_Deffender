using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibilityControllerEnemy : MonoBehaviour
{
    private EnemyHealth _healthController;
    private void Awake()
    {
        _healthController = GetComponent<EnemyHealth>();
    }

    public void StartInvincibility(float invincibilityDuration)
    {
        StartCoroutine(InvincibilityCoroutine(invincibilityDuration));
    }

    private IEnumerator InvincibilityCoroutine(float invincibilityDuration)
    {
        _healthController.IsInvincible = true;
        yield return new WaitForSeconds(invincibilityDuration);
        _healthController.IsInvincible = false;
    }
}
