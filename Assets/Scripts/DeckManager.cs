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
    // Start is called before the first frame update
    void Start()
    {
        deck = new HexDeck();
        cursor = cursorObj.GetComponent<Cursor>();
        deck.MakeDeck();
    }

    public void Pop(){
        nowPair = new HexColorPair(deck.Pop(), deck.Pop());
        cursor.SetImages(nowPair);
    }
}
