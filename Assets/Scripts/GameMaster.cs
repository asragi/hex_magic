using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    [SerializeField]
    ScoreBoard scoreBoard;
    [SerializeField]
    TimerScript timer;
    [SerializeField]
    ScaleTransition trans;
    [SerializeField]
    StartText startText;
    [SerializeField]
    Cursor cursor;
    [SerializeField]
    EndModal endModal;

    public PuzzleState PuzzleState {get; set;}
    Score score;
    public int Score => score.Val;
    // Start is called before the first frame update
    void Start()
    {
        trans.Shrink();
        score = new Score();
    }

    void Update(){
        if (timer.End){
            PuzzleState = PuzzleState.End;
            startText.OnEnd();
            cursor.Disable();
        }
    }

    public void GameStart()
    {
        timer.GameStart();
        PuzzleState = PuzzleState.Play;
    }

    public void DisplayEndModal(){
        endModal.gameObject.SetActive(true);
        endModal.SetScore(Score);
    }

    public int AddScore(int deleteNum, int chainNum){
        var val = score.AddScore(deleteNum, chainNum);
        scoreBoard.SetScore(score.Val);
        return val;
    }

    public void StopTimer() => timer.StopTimer();
    public void StartTimer() => timer.StartTimer();

    public void AddTime()
    {
        timer.AddTime(15);
    }
}
