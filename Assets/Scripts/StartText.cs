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
    bool end;
    bool started;
    readonly Vector3 moveDiff = new Vector3(1200, 0, 0);
    protected override int AnimationFrame => 60;
    protected override int DurationAfterAnimation => 10;
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
        if (!started && !end && frame > AnimationFrame + DurationAfterAnimation){
            master.GameStart();
            started = true;
        }
        if (end && frame > AnimationFrame + DurationAfterAnimation) master.DisplayEndModal();
        base.Update();
    }

    public void OnEnd(){
        if(end) return;
        text.text = "FINISH";
        frame = 0;
        end = true;
        PopUp();
    }

    protected override float Func(int frame, int totalFrame)
    {
        int duration = totalFrame / 3;
        if (frame >= totalFrame) return 1;
        if (frame < duration)
        {
            return ((float)frame / duration) - 1;
        }
        if (frame >= totalFrame - duration)
        {
            return ((float)frame / duration) - 3 + 1;
        }
        return 0;
    }
}
