using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuPlayButton : MonoBehaviour
{
    public string firstLevel = "FirstLevel";
    public AudioClip clickSound;
    public AudioSource theSource;
    // Start is called before the first frame update
    void Start()
    {
        theSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Click()
    {
        theSource.PlayOneShot(clickSound);
        SceneManager.LoadScene(firstLevel);
    }
}
