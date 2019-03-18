using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    [SerializeField]
    ScoreBoard scoreBoard;
    [SerializeField]
    TimerScript timer;

    public PuzzleState PuzzleState {get; set;}
    Score score;
    // Start is called before the first frame update
    void Start()
    {
        score = new Score();
        PuzzleState = PuzzleState.Play;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            timer.GameStart();
        }
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
        timer.AddTime(20);
    }
}
