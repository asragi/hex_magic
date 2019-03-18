using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwiMessageGen
{
    string gameTitle;
    string url;

    public TwiMessageGen(){
        gameTitle = Global.GameTitle;
        url = Global.url.ToString();
    }

    public string GetMessage(int score){
        return $"{gameTitle}で{score}点獲得！ {url}";
    }
}
