using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartText : MoveUIBase
{
    [SerializeField]
    GameMaster master;
    Text text;
    int frame;
    readonly Vector3 moveDiff = new Vector3(2000, 0, 0);
    protected override int AnimationFrame => 90;
    protected override int DurationAfterAnimation => 30;
    protected override Vector3 PositionDiff => moveDiff;
    protected override Color AlphaColor { get => text.color; set => text.color = value; }

    // Start is called before the first frame update
    protected override void Start()
    {
        text = GetComponent<Text>();
        base.Start();
        PopUp();
    }

    protected override void Update()
    {
        frame++;
        if (frame > AnimationFrame + DurationAfterAnimation) master.GameStart();
        base.Update();
    }

    protected override float Func(int frame, int totalFrame)
    {
        int duration = frame / totalFrame;
        if (frame >= totalFrame) return 1;
        if (frame < duration)
        {
            return ((float)frame / duration) - 1;
        }
        if (frame >= totalFrame - duration)
        {
            return ((float)frame / duration) - totalFrame + 1;
        }
        return 0;
    }
}
