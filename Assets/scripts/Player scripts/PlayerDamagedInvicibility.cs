using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamagedInvicibility : MonoBehaviour
{
    [SerializeField] private float invincibilityDuration;

    private InvincibillityController invincibillityController;
    public void Awake()
    {
        invincibillityController = GetComponent<InvincibillityController>();
    }

    public void StartInvincibility()
    {
        invincibillityController.StartInvicibility(invincibilityDuration);
    }
}
