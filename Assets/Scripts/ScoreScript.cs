using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {
    private Text text;
    private int lastScore;
    public int score;


    // Use this for initialization
    void Start () {
        text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        if (score != lastScore)
        {
            text.text = score.ToString();
        }
        lastScore = score;
	}
}
