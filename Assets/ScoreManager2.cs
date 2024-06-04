using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager2 : MonoBehaviour
{
    public Text scoreText; // UI에 표시되는 점수를 업데이트하기 위한 Text UI 요소

    private int score = 0; // 현재의 점수

    // UI에 현재 점수를 표시하는 함수
    private void UpdateScoreUI()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    // 점수를 업데이트하고 UI에 반영하는 함수
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        UpdateScoreUI();
    }
}