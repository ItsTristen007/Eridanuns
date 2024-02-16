using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Alien : MonoBehaviour
{
    private float x;
    private float y;
    private float mX;
    private float mY;
    private Rigidbody2D rb;
    public AudioClip deadSound;
    
    [SerializeField] GameObject bullet;
    private int shootTimer = 0;

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
        y -= mY;
        x += mX;
        SetCoords();

        shootTimer++;
        if (shootTimer > 50 && Random.Range(1, 3) == 1)
        {
            Create("blaster", x, y -.8f);
            shootTimer = 0;
        }
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
    
    public void Create(string name, float x, float y)
    {
        GameObject obj = Instantiate(bullet, new Vector3(0, 0, -1), Quaternion.identity);
        BulletBase bul = obj.GetComponent<BulletBase>();
        bul.name = name;
        bul.SetX(x);
        bul.SetY(y);
        bul.Activate();
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
    
    public void SetmX(float mX)
    {
        this.mX = mX;
    }

    public float GetmX()
    {
        return mX;
    }

    public void SetmY(float mY)
    {
        this.mY = mY;
    }

    public float GetmY()
    {
        return mY;
    }
}
