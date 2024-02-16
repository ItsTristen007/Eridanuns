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
    
    [SerializeField] GameObject bullet;
    private int shootTimer = 0;

    private int health = 200;

    private float mX;
    private float mY;

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
    
    public void Create(string name, float x, float y)
    {
        GameObject obj = Instantiate(bullet, new Vector3(0, 0, -1), Quaternion.identity);
        BulletBase bul = obj.GetComponent<BulletBase>();
        bul.name = name;
        bul.SetX(x);
        bul.SetY(y);
        bul.Activate();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        y -= mX;
        x += mY;
        SetCoords();

        shootTimer++;
        if (shootTimer > 50)
        {
            Create("blaster", x, y-.8f);
            shootTimer = 0;
        }
    }

    private void Update()
    {
        if(x > 6 || x < -6 || y > 7 || y < -7) Destroy(gameObject);

        if (health <= 0)
        {
            AudioSource.PlayClipAtPoint(deadSound, Vector3.zero);
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            health -= 100;
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
    
    public void SetMX(float mX)
    {
        this.mX = mX;
    }

    public float GetMX()
    {
        return x;
    }

    public void SetMY(float mY)
    {
        this.mY = mY;
    }

    public float GetMY()
    {
        return y;
    }
}
