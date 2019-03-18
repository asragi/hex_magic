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

    public PuzzleState PuzzleState {get; set;}
    Score score;
    // Start is called before the first frame update
    void Start()
    {
        trans.Shrink();
        score = new Score();
    }

    public void GameStart()
    {
        timer.GameStart();
        PuzzleState = PuzzleState.Play;
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
