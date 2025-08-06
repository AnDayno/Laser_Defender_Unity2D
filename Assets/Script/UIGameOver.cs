using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIGameOver : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI gameOverScore;
    ScoreKeeper playerScore;

    void Awake()
    {
        playerScore = FindObjectOfType<ScoreKeeper>();
    }

    void Start()
    {     
        gameOverScore.text = "YOU SCORED:\n " + playerScore.GetCurrentScore().ToString("0000000");
    }
}
