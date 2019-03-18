using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndModal : MonoBehaviour
{
    [SerializeField]
    Text scoreText;
    // Start is called before the first frame update
    public void SetScore(int score){
        string InsertZero(int val, int _length){
            var result = val.ToString();
            int zeroNum = - result.Length + _length;
            string zeros = new string('0', zeroNum);
            return zeros + result;
        }
        var length = scoreText.text.Length;
        scoreText.text = InsertZero(score, length);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
