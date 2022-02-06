using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [Header("Audio Sounds")]

    public float uIVolume;
    public AudioClip restartButtonSound;
    public AudioClip continueButtonSound;
    public AudioClip menuButtonSound;
    public AudioClip starSound;
    public string mainMenu = "FR_Intro";

    public AudioSource uIAudio;
    public static UIManager instance;

  
    public GameObject continueButton;

    

    private void Awake()
    {
        instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        
        uIAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    public void RestartButton()
    {
        uIAudio.PlayOneShot(restartButtonSound, uIVolume);
        Invoke("Restart", restartButtonSound.length);
    }

    public void ContinueButton()
    {
        uIAudio.PlayOneShot(continueButtonSound, uIVolume);
        Invoke("Continue", continueButtonSound.length);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Continue()
    {
            
            TheRocketController.instance.GameContinued();
            GameManager.instance.GameContinued();
            continueButton.SetActive(false);
        

        
    }

    public void Star()
    {
        uIAudio.PlayOneShot(starSound);
    }

    public void MenuButton()
    {
        uIAudio.PlayOneShot(menuButtonSound, uIVolume);
        Invoke("Menu", menuButtonSound.length);
    }

    public void Menu()
    {
        SceneManager.LoadScene(mainMenu);
    }
}
