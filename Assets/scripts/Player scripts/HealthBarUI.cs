using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Image _healthBarForegraundImage;
    public void UpdateHealthBar(HealthConroler healthController)
    {
        _healthBarForegraundImage.fillAmount = healthController.RemainingHealthPercentage;
    }
}
