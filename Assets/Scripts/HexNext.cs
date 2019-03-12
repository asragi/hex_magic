using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexNext : MonoBehaviour
{
    [SerializeField]
    HexPairObj hexPairNext;
    [SerializeField]
    HexPairObj hexPairNext2;
    HexColorPair next, next2;
    HexDeck deck;
    // Start is called before the first frame update
    public void Init()
    {
        deck = new HexDeck();
        deck.MakeDeck();
        next = new HexColorPair(deck.Pop(), deck.Pop());
        next2 = new HexColorPair(deck.Pop(), deck.Pop());
        Refresh();
    }

    private void Refresh(){
        hexPairNext.ChangeHex(next);
        hexPairNext2.ChangeHex(next2);
    }

    public HexColorPair Pop(){
        var tmp = next;
        next = next2;
        next2 = new HexColorPair(deck.Pop(), deck.Pop());
        Refresh();
        return tmp;
    }
}
