using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthDrop : MonoBehaviour
{
    private Rigidbody2D rb;

    public float force = 4;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        rb.velocity = Vector3.down * force;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
