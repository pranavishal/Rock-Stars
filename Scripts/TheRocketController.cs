using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheRocketController : MonoBehaviour
{
    public Rigidbody2D rocketRB;
    public float velocity = 6f;
    public float moveSpeed = 10f;
   
    public Animator anim;
    public GameObject fuel;
    public GameObject rocketExplosion;
    public int fuelLeft = 500;
    public int fuelAddition;
    public float phase1, phase2;
    int maxFuelCapacity = 500;
 

    public static TheRocketController instance;

    // Start is called before the first frame update

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        GameUICanvas.instance.fuelAmount.text = "Fuel Left: " + fuelLeft.ToString();
        rocketRB.gravityScale = 0;
        anim.SetBool("isFlying", true);
        GameUICanvas.instance.healthRemaining.text = "Health Left: " + GameManager.instance.lives.ToString();
        
        
    }

    // Update is called once per frame
    void Update()
    {
       

        if (GameManager.instance.hasGameStarted)

        {
            Time.timeScale = 1;
            rocketRB.gravityScale = 3;

            rocketRB.velocity = new Vector2(moveSpeed, rocketRB.velocity.y);
            anim.SetBool("isFlying", false);
        
            if (Input.GetMouseButton(0) && fuelLeft > 0)
            {
                fuelLeft--;
                GameUICanvas.instance.fuelAmount.text = "Fuel Left: " + fuelLeft.ToString();

                rocketRB.velocity = new Vector2(moveSpeed, velocity);
               
                anim.SetBool("isFlying", true);
                fuel.SetActive(true);

            }
            else if (Input.GetMouseButtonUp(0))
            {
                rocketRB.velocity *= new Vector2(1f, 0.0f);
                anim.SetBool("isFlying", false);
                fuel.SetActive(false);
                


            }

        }

        if (!GameManager.instance.hasGameStarted)
        {
            Time.timeScale = 0;
            
        }

        if(rocketRB.transform.position.x >= phase1  && rocketRB.transform.position.x < phase2)
        {
            moveSpeed = 31;
        }

        if(rocketRB.transform.position.x >= phase2)
        {
            moveSpeed = 36;
        }

         






}

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Asteroid")
        {

            GameManager.instance.lives--;
            GameUICanvas.instance.healthRemaining.text = "Health Left: " + GameManager.instance.lives.ToString();

            if (GameManager.instance.lives <= 0)
            {
                GameManager.instance.Died();
                this.gameObject.SetActive(false);
                Instantiate(rocketExplosion, transform.position, Quaternion.identity);
            }

            if(GameManager.instance.lives > 0)
            {
                Destroy(other.gameObject);
                Instantiate(rocketExplosion, other.gameObject.transform.position, Quaternion.identity);
            }

            
            

        }

      
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Star")
        {
            UIManager.instance.Star();
            fuelLeft += fuelAddition;
            if(fuelLeft >= maxFuelCapacity)
            {
                fuelLeft = maxFuelCapacity;
            }
            Destroy(other.gameObject);
            GameUICanvas.instance.fuelAmount.text = "Fuel Left: " + fuelLeft.ToString();
        }
    }

    public void GameContinued()
    {
        rocketRB.transform.position = new Vector3(rocketRB.transform.position.x, 0f, rocketRB.transform.position.z);
        rocketRB.transform.rotation = Quaternion.Euler(rocketRB.transform.rotation.x, rocketRB.transform.rotation.y, 10.17f);
        fuelLeft = maxFuelCapacity;
        GameUICanvas.instance.fuelAmount.text = "Fuel Left: " + fuelLeft.ToString();
        this.gameObject.SetActive(true);
    }

   
}
        
           
        

        
    
