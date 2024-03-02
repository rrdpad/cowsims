using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private float damageAmount;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<RotateClass>())
        {
            var healthController = collision.gameObject.GetComponent<HealthConroler>();

            healthController.TakeDamage(damageAmount);
        }
    }
}
