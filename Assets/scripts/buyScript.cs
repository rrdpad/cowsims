using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class buyScript : MonoBehaviour
{
    public Button ak, mp5, uzi;

    const string filePath = @"./weapons.txt";
    int[] boughtStatus;

    void Start()
    {
        if (File.Exists(filePath))
            boughtStatus = SplitNumbers(filePath);
        updateStatus();
    }



    public void buyAK()
    {
        if (boughtStatus[0] == 0)
            boughtStatus[0] = 1;
        updateStatus();
    }
    public void buyUZI()
    {
        if (boughtStatus[1] == 0)
            boughtStatus[1] = 1;
        updateStatus();
    }
    public void buyMP5()
    {
        if (boughtStatus[2] == 0)
            boughtStatus[2] = 1;
        updateStatus();
    }

    private void updateStatus()
    {
        if (boughtStatus[0] == 1)
            ak.interactable = false;
        if (boughtStatus[1] == 1)
            uzi.interactable = false;
        if (boughtStatus[2] == 1)
            mp5.interactable = false;

        File.WriteAllText(filePath, $"{boughtStatus[0]} {boughtStatus[1]} {boughtStatus[2]}");
    }

    private int[] SplitNumbers(string file)
    {
        var splt = File.ReadAllText(file).Split(' ');
        return new int[] { int.Parse(splt[0]), int.Parse(splt[1]), int.Parse(splt[2]) };
    }
}
