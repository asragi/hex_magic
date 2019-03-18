using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleTransition : MonoBehaviour
{
    [SerializeField]
    RectTransform target;
    public int Size = 50;
    public bool StartWithBlackOut = false;
    public int TransitionFrame = 50;
    Vector3 targetVector;
    bool enlarge, shrink;
    int frame;
    Action<string> actionOnEnd;
    string scene;
    // Start is called before the first frame update
    void Start()
    {
        var initSize = StartWithBlackOut ? Size : 0;
        target.localScale = new Vector3(initSize, initSize, initSize);
        targetVector = new Vector3(Size, Size, Size);
    }

    // Update is called once per frame
    void Update()
    {
        void ActionOnEnd(Action<string> act, string arg)
        {
            if (act == null) return;
            act(arg);
        }

        if (!enlarge && !shrink) return;
        frame++;
        if (frame >= TransitionFrame)
        {
            ActionOnEnd(actionOnEnd, scene);
        }
        if (enlarge)
        {
            target.localScale = targetVector * Func(frame, TransitionFrame);
            return;
        }
        target.localScale = targetVector * (1 - Func(frame, TransitionFrame));
    }

    public void Enlarge(Action<string> action=null, string sceneName="") => StartTransition(true, action, sceneName);
    public void Shrink(Action<string> action=null, string sceneName = "") => StartTransition(false, action, sceneName);

    private float Func(int frame, int lastFrame)
    {
        var x = frame / (float)lastFrame;
        return - x * x + 2 * x;
    }

    private void StartTransition(bool _enlarge, Action<string> action, string sceneName)
        => (enlarge, shrink, frame, actionOnEnd, scene) = (_enlarge, !_enlarge, 0, action, sceneName);
}
