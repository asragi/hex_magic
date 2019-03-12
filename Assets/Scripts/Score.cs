using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score
{
    ScoreCalc calc;
    public int Val {get; private set;}
    public Score(){
        calc = new ScoreCalc();
    }

    public void AddScore(int deleteNum, int chainNum){
        var add = calc.Score(deleteNum, chainNum);
        Val += add;
        Debug.Log($"Score{Val}:{add}");

    }
}
