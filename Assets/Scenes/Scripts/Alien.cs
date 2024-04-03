using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.Animations;
using UnityEngine;
using Random = UnityEngine.Random;

public class Alien : MonoBehaviour
{
    private float x;
    private float y = 5.3f;
    private Rigidbody2D rb;
    public AudioClip deadSound;
    
    [SerializeField] GameObject bullet;
    public GameObject game;
    public GameObject player;
    public GameObject healthDrop;
    public GameObject explosion;
    
    public Transform bulletPos;
    private int shootTimer = 0;
    public int shootRate = 0;

    private int damageCheck;

    private int level;

    [SerializeField] private int health = 200;

    private bool taser;
    float taserStart, taserTimer;

    
    [SerializeField] public float speed;

    private GameObject target;
    
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
                health = 200 + 50 * level;
                speed = 3;
                shootRate = 60 + 1 * level;
                break;
            case "Midi":
                health = 300 + 50 * level;
                speed = 2.5f;
                shootRate = 70 + 1 * level;
                break;
            case "Magna":
                health = 500 + 75 * level;
                speed = 2;
                shootRate = 80 + 1 * level;
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
        player = GameObject.FindGameObjectWithTag("Player");
        Player pl = player.GetComponent<Player>();
        
        
        if (health <= 0)
        {
            if (GameObject.FindGameObjectWithTag("healDropCheck") && Random.Range(0, 3) == 0) Instantiate(healthDrop, bulletPos.position, Quaternion.identity); else if (Random.Range(0, 6) == 0) Instantiate(healthDrop, bulletPos.position, Quaternion.identity);
            GameObject.Find("Plane").GetComponent<Game>().score += name == "Mini" ? (int)Mathf.Round( 100 + 100 * 0.1f * level) : name == "Midi" ? (int)Mathf.Round(200 + 200 * 0.1f * level) : (int)Mathf.Round( 400 + 400 * 0.1f * level);
            AudioSource.PlayClipAtPoint(deadSound, Vector3.zero);
            if (GameObject.FindGameObjectWithTag("healDropCheck") && pl.health <= pl.maxHealth - 50) pl.health += 50;
            Instantiate(explosion, bulletPos.position, Quaternion.identity);
            Destroy(gameObject);
        }

        

        Vector3 direction = player.transform.position - transform.position;
        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0,rot - 90);
        
        

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        damageCheck = GameObject.FindGameObjectsWithTag("damageCheck").Length;
        if (other.gameObject.CompareTag("Bullet"))
        {
            if (GameObject.FindGameObjectWithTag("taserCheck"))
            {
                taser = true;
                taserStart = Time.time;
                taserTimer = taserStart;
            }

            Destroy(other.gameObject);
            health -= 100 + 50 * damageCheck;
        }

        if (other.gameObject.CompareTag("bigBullet"))
        {
            if (GameObject.FindGameObjectWithTag("taserCheck"))
            {
                taser = true;
                taserStart = Time.time;
                taserTimer = taserStart;
            }

            health -= 100 + 50 * damageCheck;
        }

        if (other.gameObject.CompareTag("melee"))
        {
            if (GameObject.FindGameObjectWithTag("taserCheck"))
            {
                taser = true;
                taserStart = Time.time;
                taserTimer = taserStart;
            }
            health -= 100 + 50 * damageCheck;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("beam"))
        {
            health -= 7 + 2 * damageCheck;
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

    public void SetLevel(int level)
    {
        this.level = level;
    }
}
