using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private TMP_Text firstPinText;
    [SerializeField] private TMP_Text secondPinText;
    [SerializeField] private TMP_Text thirdPinText;
    
    [SerializeField] private int firstPinRight;
    [SerializeField] private int secondPinRight;
    [SerializeField] private int thirdPinRight;
    [SerializeField] private int startingTime;

    private float currentTime;
    private int firstPinCurrent;
    private int secondPinCurrent;
    private int thirdPinCurrent;

    private void Start()
    {
        timerText.text = startingTime.ToString();
        currentTime = startingTime;

        firstPinCurrent = Random.Range(1, 11);
        secondPinCurrent = Random.Range(1, 11);
        thirdPinCurrent = Random.Range(1, 11);

        firstPinText.text = firstPinCurrent.ToString();
        secondPinText.text = secondPinCurrent.ToString();
        thirdPinText.text = thirdPinCurrent.ToString();
    }

    private void Update()
    {
        Timer();
    }


    private void Timer()
    {
        timerText.text = MathF.Round(currentTime).ToString();
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
        }
    }

    public void UsingDrill()
    {
        UsingInstruments(1, -1, 0);
    }

    public void UsingHummer()
    {
        UsingInstruments(-1, +2, -1);
    }

    public void UsingPicklock()
    {
        UsingInstruments(-1, 1, 1);
    }


    private void UsingInstruments(int firstPin, int secondPin, int thirdPin)
    {
        if (Convert.ToInt32(firstPinText.text) > 0 && Convert.ToInt32(firstPinText.text) < 10 &&
            Convert.ToInt32(secondPinText.text) > 0 && Convert.ToInt32(secondPinText.text) < 10 &&
            Convert.ToInt32(thirdPinText.text) > 0 && Convert.ToInt32(thirdPinText.text) < 10)
        {
            firstPinText.text = (Convert.ToInt32(firstPinText.text) + firstPin).ToString();
            secondPinText.text = (Convert.ToInt32(secondPinText.text) + secondPin).ToString();
            thirdPinText.text = (Convert.ToInt32(thirdPinText.text) + thirdPin).ToString();
        }
    }

    

}
