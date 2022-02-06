using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool hasGameStarted = false;
    public int lives;
    public bool hasDied = false;
    int maxLives = 2;

    public GameObject gameOverScreen;

    public GameObject[] asteroids;
    public GameObject[] stars;
    public GameObject[] explosions;
    
    // Start is called before the first frame update

    private void Awake()
    {
        instance = this;

    }

    void Start()
    {
        lives = maxLives;
        GameUICanvas.instance.healthRemaining.text = "Health Left: " + lives.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            hasGameStarted = true;
            GameUICanvas.instance.GameStarted();
        }
    }

    public void Died()
    {
        int score = Mathf.RoundToInt(GameUICanvas.instance.theRocket.transform.position.x);
        HighScoreManager.instance.GetHighScore(score);
        GameUICanvas.instance.healthRemaining.text = "Exploded!";
        hasDied = true;
        gameOverScreen.SetActive(true);
    }

   
    public void GameContinued()
    {
        asteroids = GameObject.FindGameObjectsWithTag("Asteroid");
        stars = GameObject.FindGameObjectsWithTag("Star");
        explosions = GameObject.FindGameObjectsWithTag("Explosion");

        for (int i = 0; i < asteroids.Length; i++)
        {
            Destroy(asteroids[i]);
        }

        for(int i = 0; i < stars.Length; i++)
        {
            Destroy(stars[i]);
        }

        for(int i = 0; i < explosions.Length; i++)
        {
            Destroy(explosions[i]);
        }

        hasGameStarted = false;
        GameUICanvas.instance.GameContinued();
        lives = maxLives;
        GameUICanvas.instance.healthRemaining.text = "Health Left: " + lives.ToString();
        
        gameOverScreen.SetActive(false);
        hasDied = false;

    }


}
