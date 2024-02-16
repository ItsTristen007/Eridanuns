using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBase : MonoBehaviour
{
    private float speed;
    private float x;
    private float y;

    private int dir = +1;

    public Sprite laser, md, mg;
    
    public void Activate()
    {
        SetCoords();

        switch (name)
        {
            case "laser":
                GetComponent<SpriteRenderer>().sprite = laser; dir = +1; break;
            case "blaster":
                GetComponent<SpriteRenderer>().sprite = laser; dir = -1; tag = "Enemy"; break;
        }
    }
    
    public void SetCoords()
    {
        this.transform.position = new Vector3(x, y, -1.0f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        y += 0.16f * dir;
        SetCoords();
    }

    private void Update()
    {
        if (y >= 6 || y <= -6) Destroy(this.gameObject);
    }

    public void SetX(float x)
    {
        this.x = x;
    }

    public float GetX()
    {
        return x;
    }

    public void SetY(float y)
    {
        this.y = y;
    }

    public float GetY()
    {
        return y;
    }
}
