using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public Text highscoreText;

    int score = 0;
    int highscore = 0;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = score.ToString() + " POINTS";
        highscoreText.text = "HIGHSCORE: " + highscore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
