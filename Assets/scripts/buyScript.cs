using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class buyScript : MonoBehaviour
{
    public Button ak, mp5, uzi;

    public int money;
    public int[] purchasedWeapon;

    private TextMeshProUGUI moneyLabel;

    void Start()
    {
        moneyLabel = GameObject.FindGameObjectWithTag("Score").GetComponent<TextMeshProUGUI>();

        purchasedWeapon = new int[3];
        var temp = GetComponent<RotateClass>().purchasedWeapon;

        money = GetComponent<RotateClass>().scoreCount;
        var data = SaveSystem.LoadPlayer();
        money = data.money;
        purchasedWeapon[0] = data.purchasedWeapon[0];
        purchasedWeapon[1] = data.purchasedWeapon[1];
        purchasedWeapon[2] = data.purchasedWeapon[2];
        UpdateStatus();
        moneyLabel.text = $"Кашель: {money}";

        print(money);
    }


    //TODO: исправить цены
    public void BuyAK()
    {
        if (purchasedWeapon[0] == 0 && money >= 1)
        {
            purchasedWeapon[0] = 1;
            money--;
        }
        UpdateStatus();
    }
    public void BuyUZI()
    {
        if (purchasedWeapon[1] == 0 && money >= 1)
        {
            purchasedWeapon[1] = 1;
            money--;
        }
        UpdateStatus();
    }
    public void BuyMP5()
    {
        if (purchasedWeapon[2] == 0 && money >= 1)
        {
            purchasedWeapon[2] = 1;
            money--;
        }
        UpdateStatus();
    }

    private void UpdateStatus()
    {
        ak.interactable = purchasedWeapon[0] == 0;
        uzi.interactable = purchasedWeapon[1] == 0;
        mp5.interactable = purchasedWeapon[2] == 0;

        var player = GetComponent<RotateClass>();
        player.scoreCount = money;
        player.purchasedWeapon = purchasedWeapon;
        SaveSystem.SavePlayer(player);

        moneyLabel.text = $"Кашель: {money}";
    }

    public void ToMenu() => SceneManager.LoadScene(0);
    public void ToGame() => SceneManager.LoadScene(2);
}
