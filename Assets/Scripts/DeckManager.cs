using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    [SerializeField]
    GameObject cursorObj;
    Cursor cursor;
    HexDeck deck;
    HexColorPair nowPair;
    RPoint[] targetPoints = new RPoint[]{
        new RPoint(1, 1),
        new RPoint(0, 2),
        new RPoint(-1, 1),
        new RPoint(-1, -1),
        new RPoint(0, -2),
        new RPoint(1, -1)
    };
    int index = 0;
    public RPoint Target {get; private set;}

    // Start is called before the first frame update
    void Start()
    {
        deck = new HexDeck();
        cursor = cursorObj.GetComponent<Cursor>();
        deck.MakeDeck();
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.Space)){
            ChangeTarget();
        }
    }

    public void Pop(){
        nowPair = new HexColorPair(deck.Pop(), deck.Pop());
        cursor.SetImages(nowPair);
    }

    public void ChangeTarget(bool right=true){
        index = right ? index - 1 : index + 1;
        index = (index + targetPoints.Length) % targetPoints.Length;
        Target = targetPoints[index];
        cursor.SetTargetPoint(Target);
    }
}
