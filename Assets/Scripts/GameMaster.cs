﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    [SerializeField]
    ScoreBoard scoreBoard;
    public PuzzleState PuzzleState {get; private set;}
    Score score;
    // Start is called before the first frame update
    void Start()
    {
        score = new Score();
        PuzzleState = PuzzleState.Opening;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddScore(int deleteNum, int chainNum){
        score.AddScore(deleteNum, chainNum);
        scoreBoard.SetScore(score.Val);
    }
}
