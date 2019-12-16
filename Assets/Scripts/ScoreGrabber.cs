using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreGrabber : MonoBehaviour
{
    public Text scoreText;

    private ScoreKeeper scoreKeeper;

    void Start()
    {
        scoreKeeper = GameObject.FindWithTag("ScoreKeeper").GetComponent<ScoreKeeper>();
        scoreText.text = "Score: " + scoreKeeper.score;
    }
}
