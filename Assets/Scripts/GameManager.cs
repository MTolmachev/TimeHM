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
    [SerializeField] private TMP_Text drillNumbersText;
    [SerializeField] private TMP_Text hammerNumbersText;
    [SerializeField] private TMP_Text picklockNumbersText;
    [Space]
    [Header("Требуемые пины в замке")]
    [SerializeField, Range(1, 10)] private int firstPinRight;
    [SerializeField, Range(1, 10)] private int secondPinRight;
    [SerializeField, Range(1, 10)] private int thirdPinRight;
    [Space]
    [Header("Время")]
    [SerializeField] private int startingTime;
    [Space]
    [Header("Окна")]
    [SerializeField] private GameObject winScreen;
    [SerializeField] private GameObject loseScreen;
    [Space]
    [Header("Дрель")]
    [SerializeField, Range(-10, 10)] private int drillFirstPin;
    [SerializeField, Range(-10, 10)] private int drillSecondPin;
    [SerializeField, Range(-10, 10)] private int drillThirdPin;
    [Header("Молоток")]
    [SerializeField, Range(-10, 10)] private int hammerFirstPin;
    [SerializeField, Range(-10, 10)] private int hammerSecondPin;
    [SerializeField, Range(-10, 10)] private int hammerThirdPin;
    [Header("Отмычка")]
    [SerializeField, Range(-10, 10)] private int picklockFirstPin;
    [SerializeField, Range(-10, 10)] private int picklockSecondPin;
    [SerializeField, Range(-10, 10)] private int picklockThirdPin;

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

        drillNumbersText.text = $"{drillFirstPin} | {drillSecondPin} | {drillThirdPin}";
        hammerNumbersText.text = $"{hammerFirstPin} | {hammerSecondPin} | {hammerThirdPin}";
        picklockNumbersText.text = $"{picklockFirstPin} | {picklockSecondPin} | {picklockThirdPin}";
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
        UsingInstruments(drillFirstPin, drillSecondPin, drillThirdPin);
    }

    public void UsingHammer()
    {
        UsingInstruments(hammerFirstPin, hammerSecondPin, hammerThirdPin);
    }

    public void UsingPicklock()
    {
        UsingInstruments(picklockFirstPin, picklockSecondPin, picklockThirdPin);
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
