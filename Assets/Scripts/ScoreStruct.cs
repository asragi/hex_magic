using System.Collections;
using System.Collections.Generic;

public struct ScoreStruct
{
    public int DeleteNum;
    public int ChainNum;
    public int GainScore;
    public ScoreStruct(int deleteNum, int chainNum, int gainScore){
        (DeleteNum, ChainNum, GainScore) = (deleteNum, chainNum, gainScore);
    }
}
