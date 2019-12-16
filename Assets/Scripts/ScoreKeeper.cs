using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    public int score;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
