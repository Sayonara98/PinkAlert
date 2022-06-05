using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int _score;

    [SerializeField] private Text scoreText;
    [SerializeField] private Text highScoreText;

    private int _highScore = 0;

    private void Start()
    {
        _highScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + _score;
        highScoreText.text = "High Score: " + _highScore;
        if (_highScore < _score)
        {
            _highScore = _score;
            PlayerPrefs.SetInt("HighScore", _highScore);
        }
    }

    public int getHighScore()
    {
        return _highScore;
    }
}
