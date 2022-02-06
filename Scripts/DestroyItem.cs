using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyItem : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


   


    private void OnCollisionEnter2D(Collision2D other)
    {
       
            if (other.gameObject.tag == "Player")
            {
                other.gameObject.SetActive(false);
                GameManager.instance.Died();
            }

            else
            {
                

                Destroy(other.gameObject);

            }
        

       
       
       
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
       
            if (other.tag == "Star")
            {
                Destroy(other.gameObject);
            }
        
       
    }


}
