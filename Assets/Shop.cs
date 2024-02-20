using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
public class Shop : MonoBehaviour
{
    public Button one, two, three;

    private string FilePath = "./weapons.txt";
    private int[] BoughtStatus;

    void Start()
    {
        if (File.Exists(FilePath))
        {
            BoughtStatus = SplitNumbers(FilePath);
        }
        else
        {
            var fileStream = new FileStream(@"weapons.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);
            fileStream.Close();
            File.WriteAllText(FilePath, "0 0 0");
        }
    }

    void Update()
    {
        if (BoughtStatus[0] == 1)
            one.interactable = false;
        else if (BoughtStatus[1] == 1)
            two.interactable = false;
        else if (BoughtStatus[2] == 1)
            three.interactable = false;
    }

    private int[] SplitNumbers(string file)
    {
        var splt = File.ReadAllText(file).Split(' ');
        return new int[] { int.Parse(splt[0]), int.Parse(splt[1]), int.Parse(splt[2]) };
    }

    public void BuyAk47()
    {
        BoughtStatus[0] = 1;
    }
}
