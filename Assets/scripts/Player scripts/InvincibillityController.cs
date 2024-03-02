using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibillityController : MonoBehaviour
{
    private HealthConroler healthConroler;

    private void Awake()
    {
        healthConroler = GetComponent<HealthConroler>();
    }

    public void StartInvicibility(float invincibilityDuration)
    {
        StartCoroutine(InvicibilityCoroutine(invincibilityDuration));
    }

    private IEnumerator InvicibilityCoroutine(float invincibilityDuration)
    {
        healthConroler.IsInvincible = true;
        yield return new WaitForSeconds(invincibilityDuration);
        healthConroler.IsInvincible = false;
    }
}
