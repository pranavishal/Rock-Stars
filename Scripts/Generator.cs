using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public GameObject[] items;
    public float minGenTime;
    public float maxGenTime;
    public bool isInPhase1;
    public bool isInPhase2;
   
   

    public GameObject rocketReference;
    public Rigidbody2D rocketVelocity;

    private bool generatorActive = false;
    
    // Start is called before the first frame update
    void Start()
    {
        rocketVelocity = rocketReference.GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(rocketVelocity.velocity.x > 0 && !generatorActive)
        {
            generatorActive = true;
            Generate();
        }

        if (GameManager.instance.hasDied)
        {
            generatorActive = false;
        }

        if(TheRocketController.instance.rocketRB.transform.position.x >= TheRocketController.instance.phase1 && 
            TheRocketController.instance.rocketRB.transform.position.x < TheRocketController.instance.phase2)
        {
            isInPhase1 = true;
        }

        else if(TheRocketController.instance.rocketRB.transform.position.x > TheRocketController.instance.phase2)
        {
            isInPhase1 = false;
            isInPhase2 = true;
        }
    }

    public void Generate()
    {
        if (!isInPhase1 && !isInPhase2)
        {
            if (generatorActive)
            {
                Vector3 positionToGenerate = new Vector3(transform.position.x, Random.Range(-7.5f, 9), transform.position.z);
                Instantiate(items[Random.Range(0, items.Length - 2)], positionToGenerate, Quaternion.identity);
                Invoke("Generate", Random.Range(minGenTime, maxGenTime));
            }
        }

        else if (isInPhase1)
        {
            if (generatorActive)
            {
                float phase1MinGenTime = (minGenTime - 0.05 > 0f) ? minGenTime / 1.25f : minGenTime - 0.05f;
                float phase1MaxGenTime = (maxGenTime - 0.05 > 0f) ? maxGenTime / 1.25f : maxGenTime - 0.05f;

                



                Vector3 positionToGenerate = new Vector3(transform.position.x, Random.Range(-7.5f, 9), transform.position.z);
                Instantiate(items[Random.Range(0, items.Length - 1)], positionToGenerate, Quaternion.identity);
                Invoke("Generate", Random.Range(phase1MinGenTime, phase1MaxGenTime));
            }
            
            }

        else if (isInPhase2)
        {

            if (generatorActive)
            {
                float phase1MinGenTime = (minGenTime - 0.2 > 0f) ? minGenTime / 1.5f : minGenTime - 0.2f;
                float phase1MaxGenTime = (maxGenTime - 0.2 > 0f) ? maxGenTime / 1.5f : maxGenTime - 0.2f;

                Vector3 positionToGenerate = new Vector3(transform.position.x, Random.Range(-7.5f, 9), transform.position.z);
                Instantiate(items[Random.Range(0, items.Length - 1)], positionToGenerate, Quaternion.identity);
                Invoke("Generate", Random.Range(phase1MinGenTime, phase1MaxGenTime));
            }
            
        }
        }



        
    


    

    
}
