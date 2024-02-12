using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{

    private float y;
    // Start is called before the first frame update
    void Start()
    {
        if (name.Equals("Background1")) y = 28.1f;
        if (name.Equals("Background2")) y = 110.6f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        y -= 0.13f;
        transform.position = new Vector3(0, y, 0.0f);
        if (y <= -54.3f)
        {
            y = 110.6f;
        }
    }
}
