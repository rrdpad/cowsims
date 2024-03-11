using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    public TextMeshProUGUI weaponName;
    public int weaponSwitch = 0;

    int[] boughtStatus;

    // Start is called before the first frame update
    void Start()
    {
        weaponName = GameObject.Find("currentWeapon").GetComponent<TextMeshProUGUI>();

        boughtStatus = new int[3];
        var data = SaveSystem.LoadPlayer();
        boughtStatus[0] = data.purchasedWeapon[0];
        boughtStatus[1] = data.purchasedWeapon[1];
        boughtStatus[2] = data.purchasedWeapon[2];
    }

    // Update is called once per frame
    void Update()
    {
        int currentWeapon = weaponSwitch;

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            weaponSwitch = 0;
            weaponName.text = "Оружие: пистолеты";
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2 & boughtStatus[0] == 1)
        {
            weaponSwitch = 1;
            weaponName.text = "Оружие: АК-47";
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 3 & boughtStatus[1] == 1)
        {
            weaponSwitch = 2;
            weaponName.text = "Оружие: УЗИ";
        }

        if (Input.GetKeyDown(KeyCode.Alpha4) && transform.childCount >= 4 & boughtStatus[2] == 1)
        {
            weaponSwitch = 3;
            weaponName.text = "Оружие: МП-5";
        }

        if (currentWeapon != weaponSwitch)
        {
            SelectWeapon();
        }
    }

    void SelectWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == weaponSwitch)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);
            i++;
        }
    }

    private int[] SplitNumbers(string file)
    {
        var splt = File.ReadAllText(file).Split(' ');
        return new int[] { int.Parse(splt[0]), int.Parse(splt[1]), int.Parse(splt[2]) };
    }
}
