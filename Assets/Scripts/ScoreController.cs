using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    private TextMeshProUGUI scoreText;
    private int score;
    private void Start() {
        scoreText = GetComponent<TextMeshProUGUI>();
        score = 0;
        RefreshUI();
    }
    public void IncrementScore(int score) {
        this.score += score;
        RefreshUI();
    }
    private void RefreshUI() {
        scoreText.text = "Score: " + score.ToString();
    }
}
