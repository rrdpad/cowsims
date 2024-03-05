using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int money;
    public int[] purchasedWeapon;

    public PlayerData(RotateClass player)
    {
        money = player.scoreCount;

        purchasedWeapon = new int[3];
        purchasedWeapon[0] = player.purchasedWeapon[0];
        purchasedWeapon[1] = player.purchasedWeapon[1];
        purchasedWeapon[2] = player.purchasedWeapon[2];
    }
}
