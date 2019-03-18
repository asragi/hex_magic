using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RTweet
{
    public void Tweet(string message){
        Application.OpenURL("http://twitter.com/intent/tweet?text=" + WWW.EscapeURL(message));
    }
}
