using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingAsteroid1 : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed;

    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = new Vector3(-moveSpeed, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   
     private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Asteroid")
        {
            Destroy(this.gameObject);
            Destroy(other.gameObject);
            Instantiate(TheRocketController.instance.rocketExplosion, transform.position, Quaternion.identity);
            Instantiate(TheRocketController.instance.rocketExplosion, other.gameObject.transform.position, Quaternion.identity);
        }
       
    }
 
}
