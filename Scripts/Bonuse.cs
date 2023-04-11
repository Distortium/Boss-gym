using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class Bonuse : MonoBehaviour
{
    public YandexGame sdk;

    void Start()
    {
        Sdk();
    }

    public void AdButton()
    {
        sdk._RewardedShow(1);
    }
    public void AdButtonCul()
    {
        SaveGame.scoreLvL += 5;
        GetComponent<SaveGame>().StartData();
        GetComponent<SaveGame>().EndData();
    }

    public void AdButtonPlusPower()
    {
        sdk._RewardedShow(2);
    }
    public void AdButtonCulPlusPower()
    {
        SaveGame.powerClick += 0.1f;
        GetComponent<SaveGame>().StartData();
        GetComponent<SaveGame>().EndData();
    }

    public void Sdk()
    {
        YandexGame.FullscreenShow();
        Invoke("Sdk", 60);
    }
}
