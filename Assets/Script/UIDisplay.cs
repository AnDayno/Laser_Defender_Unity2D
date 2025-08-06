using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreUI;
    [SerializeField] Slider healthUI;

    ScoreKeeper playerScore;
    [SerializeField] Health playerHealth;
    private void Awake()
    {
        playerScore = FindObjectOfType<ScoreKeeper>();
    }

    private void Start()
    {
        healthUI.maxValue = playerHealth.GetHealth();
    }

    void Update()
    {
        UpdateUI();
    }

    void UpdateUI()
    {
            scoreUI.text = "Score:" + playerScore.GetCurrentScore().ToString("0000000");
            healthUI.value = playerHealth.GetHealth();
    }
}
