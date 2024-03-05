using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Alien : MonoBehaviour
{
    private float x;
    private float y;
    private Rigidbody2D rb;
    public AudioClip deadSound;
    
    [SerializeField] GameObject bullet;
    public Transform bulletPos;
    [SerializeField] private int shootTimer = 0;

    [SerializeField] private int health = 200;

    private float mX;
    private float mY;

    public GameObject player;
    [SerializeField] public float speed;

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

    void Shoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
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
            Shoot();
            shootTimer = 0;
        }
    }

    private void Update()
    {

        if (health <= 0)
        {
            AudioSource.PlayClipAtPoint(deadSound, Vector3.zero);
            Destroy(gameObject);
        }

        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = player.transform.position - transform.position;
        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0,rot - 90);

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
