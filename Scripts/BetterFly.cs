using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterFly : MonoBehaviour
{
    // Start is called before the first frame update
    public float fallMultiplier = 2.5f;
    public Rigidbody2D rb;
    // Update is called once per frame
    void Update()
    {
        if(rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity * (fallMultiplier - 1) * Time.deltaTime;
        }
    }
}
