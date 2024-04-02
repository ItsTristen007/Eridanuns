using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class Alien : MonoBehaviour
{
    private float x;
    private float y = 5.3f;
    private Rigidbody2D rb;
    public AudioClip deadSound;
    
    [SerializeField] GameObject bullet;
    public Transform bulletPos;
    private int shootTimer = 0;
    public int shootRate = 0;

    [SerializeField] private int health = 200;

    private bool taser;
    float taserStart, taserTimer;

    public GameObject player;
    [SerializeField] public float speed;

    private GameObject target;

    public Sprite mn, md, mg;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        x = (Random.Range(0, 1201)/100f)-6;
        SetCoords();

        if (x >= 0) target = GameObject.FindGameObjectsWithTag("WestWaypoint")[Random.Range(0,4)];
        if (x < 0) target = GameObject.FindGameObjectsWithTag("EastWaypoint")[Random.Range(0,4)];
    }

    public void Activate()
    {
        switch (name)
        {
            case "Mini":
                health = 200;
                speed = 3;
                shootRate = 60;
                break;
            case "Midi":
                health = 300;
                speed = 2.5f;
                shootRate = 70;
                break;
            case "Magna":
                health = 400;
                speed = 2;
                shootRate = 80;
                break;
        }
    }
    
    public void SetCoords()
    {
        transform.position = new Vector3(x, y, -1.0f);
    }

    void Shoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        shootTimer++;
        if (shootTimer > shootRate)
        {
            Shoot();
            shootTimer = 0;
        }

        if (!taser)
        {
            Vector3 direction = target.transform.position - transform.position;
            rb.velocity = new Vector2(direction.x, direction.y).normalized * speed;
        }

        if (taser)
        {
            rb.velocity = new Vector2(0,0);
        }

        
        
        if (taser) taserTimer += Time.deltaTime;
        if (taserTimer >= taserStart + 0.15f) taser = false;
    }

    private void Update()
    {

        if (health <= 0)
        {
            if (GameObject.FindGameObjectWithTag("healDropCheck") && Random.Range(0, 4) == 0) ;
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
            if (GameObject.FindGameObjectWithTag("taserCheck"))
            {
                taser = true;
                taserStart = Time.time;
                taserTimer = taserStart;
            }
            Destroy(other.gameObject);
            health -= 100;
        }
        if (other.gameObject.CompareTag("bigBullet"))
        {
            if (GameObject.FindGameObjectWithTag("taserCheck"))
            {
                taser = true;
                taserStart = Time.time;
                taserTimer = taserStart;
            }
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

    public float GetMX()
    {
        return x;
    }

    public float GetMY()
    {
        return y;
    }
}
