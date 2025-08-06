using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    int currentScore = 0;
    [SerializeField]TextMeshProUGUI playerScore;
    void Update()
    {
        CurrentPlayerScore();
    }
    public int GetCurrentScore()
    {
        return currentScore;
    }

    public void AddScore(int score)
    {
        currentScore += score;
        Mathf.Clamp(currentScore, 0, int.MaxValue);
    }

    public void ResetScore()
    {
        currentScore = 0;
    }

    void CurrentPlayerScore()
    {
        if (playerScore !=null)
        {
            playerScore.text = "Score:" + currentScore.ToString();
        }
    }
}
