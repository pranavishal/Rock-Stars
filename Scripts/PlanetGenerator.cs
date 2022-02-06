using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] planets;
    public float minGenTime;
    public float maxGenTime;

    public GameObject rocketReference;
    public Rigidbody2D rocketVelocity;

    public bool generatorActive = false;
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
    }

    public void Generate()
    {
        if (generatorActive)
        {
            Vector3 positionToGenerate = new Vector3(transform.position.x, Random.Range(-7.5f, 9), 0f);
            Instantiate(planets[Random.Range(0, planets.Length)], positionToGenerate, Quaternion.identity);

            Invoke("Generate", Random.Range(minGenTime, maxGenTime));

        }
    }
}
