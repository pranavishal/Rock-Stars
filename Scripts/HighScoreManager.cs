using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HighScoreManager : MonoBehaviour
{
    public int highScoreValue;

    public static HighScoreManager instance;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        highScoreValue = PlayerPrefs.GetInt("High Score");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetHighScore(int currentScore)
    {
        
        if(currentScore > highScoreValue)
        {
            highScoreValue = currentScore;
            PlayerPrefs.SetInt("High Score", highScoreValue);
        }

        GameUICanvas.instance.highScore.text = "High Score: " + highScoreValue.ToString();
    }
}
