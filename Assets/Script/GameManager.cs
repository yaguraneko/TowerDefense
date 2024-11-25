using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Button StartWave, SpeedUp, ResetBtn;
    [SerializeField] TextMeshProUGUI CurrentWave, Money, hleath;
    [SerializeField] GameObject GameOver;

    void Start()
    {
        GlobalData.MoneyText = Money;
        GlobalData.GameOver = GameOver;

        SpeedUp.onClick.AddListener(() =>{Time.timeScale = (Time.timeScale == 1) ? 3 : 1;});
        StartWave.onClick.AddListener(CallWave);
        ResetBtn.onClick.AddListener(ResetGame);
    }

    // Update is called once per frame
    void Update()
    {
        if (GlobalData.AliveSlimes == 0)
            StartWave.interactable = true;
    }
    void CallWave()
    {
        if (GlobalData.lose)
            GlobalData.wave--;
        GlobalData.lose = false;
        GlobalData.wave++;
        GlobalData.NextWave();
        CurrentWave.SetText($"Wave\n{GlobalData.wave}");
        StartWave.interactable = false;
    }

    void ResetGame()
    {
        GameOver.SetActive(false);
        GlobalData.wave = 0;
        GlobalData.Money = 100;
        GlobalData.PlayerHP = 200;
        GlobalData.AliveSlimes = 0;
        GlobalData.lose = false;
        hleath.SetText("200");
        Money.SetText("$100");
    }
}
