using System.Collections;
using System.Collections.Generic;

public enum MissionType{
    Chain,
    Same,
    Score,
    size
}

public abstract class MissionBase
{
    public bool OnUse{get; private set;}

    public MissionBase(){}
    public void Activate() => OnUse = true;
    public void Inactivate() => OnUse = false;
    public abstract void DecideMission(int lv);
    public abstract string GetText();
    public abstract bool CheckClear(ScoreStruct getScore);
}
