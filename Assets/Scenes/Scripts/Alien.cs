using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{
    private float x;
    private float y;
    private Rigidbody2D rb;
    public AudioClip deadSound;
    

    public Sprite mn, md, mg;
    
    public void Activate()
    {
        rb = GetComponent<Rigidbody2D>();
        SetCoords();

        switch (name)
        {
            case "Mini":
                GetComponent<SpriteRenderer>().sprite = mn; break;
            case "Midi":
                GetComponent<SpriteRenderer>().sprite = md; break;
            case "Magna":
                GetComponent<SpriteRenderer>().sprite = mg; break;
        }
    }
    
    public void SetCoords()
    {
        this.transform.position = new Vector3(x, y, -1.0f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        y -= 0.04f;
        x += 0.048f;
        SetCoords();
    }

    private void Update()
    {
        if(x > 6 || x < -6 || y > 6) Destroy(gameObject);

       
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            AudioSource.PlayClipAtPoint(deadSound, Vector3.zero);
            Destroy(other.gameObject);
            Destroy(gameObject);
            
        }
    }

    public void SetX(int x)
    {
        this.x = x;
    }

    public float GetX()
    {
        return x;
    }

    public void SetY(int y)
    {
        this.y = y;
    }

    public float GetY()
    {
        return y;
    }
}
