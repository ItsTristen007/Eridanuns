using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee : MonoBehaviour
{
    private float x;
    private float y;
    // Start is called before the first frame update
    void Start()
    {
        // First, I get the current x and z positions as to make sure I don't change them later
        x = gameObject.transform.position.x;
        y = gameObject.transform.position.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Then I use the Math.Sin function to get a sine wave based of the current time since game start
        // and apply some transformations to make the motion something that fits better for the purpose
        transform.position = new Vector2(x,y+(float)Mathf.Sin(Time.time)/4);
    }
}
