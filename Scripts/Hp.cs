using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Hp : MonoBehaviour
{
    public Slider HpSlider;
    public GameObject ClickEffect;
    public GameObject LvLUpEffect;
    public Sprite[] ImageBots;
    public Image ImagePublicBot; // Картинка которая показывается игроку
    public TMP_Text LvLText;
    public TMP_Text HpText;
    public TMP_Text MaxHpText;
    public TMP_Text PowerPlayerText;
    public TMP_Text PowerBotText;
    public GameObject PauseText;
    private float HpPlayer = 50f;
    private float PowerPlayer = 0.5f;
    private float PowerBot = 1f;
    private int lastIdImageBots;
    private bool pauseGame = false;

    void Start()
    {
        Invoke("Timer", 1f);
        GetComponent<SaveGame>().EndData();
        HpSlider.maxValue = 100 + (SaveGame.scoreLvL * 5);
        LvLText.text = "см твои мышцы: " + SaveGame.scoreLvL;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            ClickPause();
        }

        TextHUD();
        if (HpPlayer >= 95 + (SaveGame.scoreLvL * 5))
        {
            HpSlider.maxValue = 100 + (SaveGame.scoreLvL * 5);
            SaveGame.scoreLvL++;
            HpPlayer = 50;
            LvLUpEffect.SetActive(true);
            int i = Random.Range(0, ImageBots.Length);
            while (lastIdImageBots == i)
            {
                i = Random.Range(0, ImageBots.Length);
            }
            ImagePublicBot.sprite = ImageBots[i];
            lastIdImageBots = i;
            Invoke("CooldownLvLUpEffect", 0.4f);
            GetComponent<SaveGame>().StartData();
        }
        else if (HpPlayer < 1)
        {
            if (SaveGame.scoreLvL < 1) SaveGame.scoreLvL = 1;
            HpSlider.maxValue = 100 + (SaveGame.scoreLvL * 5);
            SaveGame.scoreLvL--;
            HpPlayer = 50;
            GetComponent<SaveGame>().StartData();
        }
    }

    void TextHUD()
    {
        HpSlider.value = HpPlayer;
        HpText.text = "" + HpPlayer;
        MaxHpText.text = "max: " + HpSlider.maxValue;
        PowerPlayerText.text = "Твоя сила: " + (PowerPlayer * SaveGame.scoreLvL).ToString("0.0") + "(" + SaveGame.powerClick.ToString("0.0") + ")";
        PowerBotText.text = "Сила Гига-Чада: " + (PowerBot * SaveGame.scoreLvL).ToString();
        LvLText.text = "см твои мышцы: " + SaveGame.scoreLvL;
    }

    public void Timer()
    {
        if (!pauseGame) HpPlayer -= PowerBot * SaveGame.scoreLvL;
        Invoke("Timer", 1f);
    }

    public void ClickPlayer()
    {
        if (!pauseGame)
        {
            HpPlayer += (PowerPlayer * SaveGame.scoreLvL) + SaveGame.powerClick;
            ClickEffect.SetActive(true);
            Invoke("CooldownClickEffect", 0.4f);
        }
    }

    public void CooldownClickEffect()
    {
        ClickEffect.SetActive(false);
    }
    public void CooldownLvLUpEffect()
    {
        LvLUpEffect.SetActive(false);
    }
    public void ClickPause()
    {
        pauseGame = !pauseGame;
        if (pauseGame) PauseText.SetActive(true);
        else PauseText.SetActive(false);
    }
}
