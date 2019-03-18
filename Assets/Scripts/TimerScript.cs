using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    const int InitTimeSeconds = 30;
    const int FrameRate = 50;
    [SerializeField]
    Text intText;
    [SerializeField]
    Text floatText;
    public bool Started {get; set;}
    int leftFrame;
    int leftSeconds;
    int leftMilsec;

    // Start is called before the first frame update
    void Start()
    {
        leftFrame = FrameRate * InitTimeSeconds;
    }

    public void GameStart()
    {
        Started = true;
    }

    private void UpdateTimeDisplay(){
        string GetTimeDisp(int milsec){
            if (milsec < 10) return $".00{milsec}";
            if (milsec < 100) return $".0{milsec}";
            return $".{milsec}";
        }
        leftSeconds = leftFrame / FrameRate;
        leftMilsec = (int)((leftFrame % FrameRate) * (1.0 / FrameRate) * 1000);
        intText.text = leftSeconds.ToString();
        floatText.text = GetTimeDisp(leftMilsec);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        void UpdateTime(){
            void CheckEnd(){
                if (leftFrame <= 0){
                    leftFrame = 0;
                    OnEnd();
                }
            }

            if(!Started) return;
            leftFrame--;
            CheckEnd();
            UpdateTimeDisplay();
        }
        UpdateTime();
    }

    public void AddTime(int sec){
        leftFrame += sec * FrameRate;
    }

    private void OnEnd(){

    }
}
