using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUICanvas : MonoBehaviour
{
    public GameObject tapToStart;
    public GameObject tapToContinue;
    public static GameUICanvas instance;
    public Rigidbody2D theRocket;
    public Text fuelAmount;
    public Text distanceCovered;
    public Text healthRemaining;
    public Text highScore;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        distanceCovered.text = "Distance: " + Mathf.RoundToInt(theRocket.transform.position.x).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        distanceCovered.text = "Distance: " + Mathf.RoundToInt(theRocket.transform.position.x).ToString();

    }

    public void GameStarted()
    {
        tapToStart.SetActive(false);
        tapToContinue.SetActive(false);
    }

    public void GameContinued()
    {
        tapToContinue.SetActive(true);

    }

   
}
