using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    Text textScore;
    int score;

    void Awake()
    {
        textScore = GetComponent<Text>();
    }

    public void AddPoints(int points)
    {
        if(points > 0)
        {
            score += points;
            textScore.text = $"Score: {score}";
        }
    }
}
