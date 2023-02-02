using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    [Header("Текстовые поля")]
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private TMP_Text firstPinText;
    [SerializeField] private TMP_Text secondPinText;
    [SerializeField] private TMP_Text thirdPinText;
    [Space]
    [Header("Требуемые пины в замке")]
    [SerializeField] private int firstPinRight;
    [SerializeField] private int secondPinRight;
    [SerializeField] private int thirdPinRight;
    [Space]
    [Header("Время")]
    [SerializeField] private int startingTime;
    [Space]
    [Header("Окна")]
    [SerializeField] private GameObject winScreen;
    [SerializeField] private GameObject loseScreen;

    private float currentTime;

    private int firstPinCurrent;
    private int secondPinCurrent;
    private int thirdPinCurrent;

    private bool enableTimer;

    private void Start()
    {
        timerText.text = startingTime.ToString();
        currentTime = startingTime;

        firstPinCurrent = Random.Range(1,11);
        secondPinCurrent = Random.Range(1, 11);
        thirdPinCurrent = Random.Range(1, 11);

        firstPinText.text = firstPinCurrent.ToString();
        secondPinText.text = secondPinCurrent.ToString();
        thirdPinText.text = thirdPinCurrent.ToString();

        enableTimer = true;
    }

    private void Update()
    {
        if(enableTimer) StartTimer();
    }

    #region Timer
    private void StartTimer()
    {
        timerText.text = MathF.Round(currentTime).ToString();
        if (currentTime > 0) currentTime -= Time.deltaTime;
        else LoseGame();
    }

    private void StopTimer()
    {
        enableTimer = false;
    }
    #endregion
    #region Win/Lose
    private void LoseGame()
    {
        StopTimer();
        loseScreen.SetActive(true);    
    }
  
    private void WinGame()
    {
        if (firstPinCurrent == firstPinRight &&
            secondPinCurrent == secondPinRight &&
            thirdPinCurrent == thirdPinRight)
        {
            winScreen.SetActive(true);
            StopTimer();
        }
    }
    #endregion
    #region OnCklick functions
    public void UsingDrill()
    {
        UsingInstruments(1, -1, 0);
    }

    public void UsingHummer()
    {
        UsingInstruments(-1, 2, -1);
    }

    public void UsingPicklock()
    {
        UsingInstruments(-1, 1, 1);
    }

    private void UsingInstruments(int firstPin, int secondPin, int thirdPin)
    {
        firstPinCurrent += firstPin;
        secondPinCurrent += secondPin;
        thirdPinCurrent += thirdPin;

        if (firstPinCurrent >= 0 && firstPinCurrent <= 10 &&
            secondPinCurrent >= 0 && secondPinCurrent <= 10 &&
            thirdPinCurrent >= 0 && thirdPinCurrent <= 10)
        {
            firstPinText.text = firstPinCurrent.ToString();
            secondPinText.text = secondPinCurrent.ToString();
            thirdPinText.text = thirdPinCurrent.ToString();
        }
        else
        {
            firstPinCurrent -= firstPin;
            secondPinCurrent -= secondPin;
            thirdPinCurrent -= thirdPin;
        }
        WinGame();
    }

    #endregion


    public void RestartGame()
    {
        winScreen.SetActive(false);
        loseScreen.SetActive(false);
        currentTime = startingTime;
        enableTimer = true;

        firstPinCurrent = Random.Range(1, 11);
        secondPinCurrent = Random.Range(1, 11);
        thirdPinCurrent = Random.Range(1, 11);

        firstPinText.text = firstPinCurrent.ToString();
        secondPinText.text = secondPinCurrent.ToString();
        thirdPinText.text = thirdPinCurrent.ToString();

    }

}
