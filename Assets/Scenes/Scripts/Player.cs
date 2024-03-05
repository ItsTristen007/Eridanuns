using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.TextCore.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    private float x = 0;
    private float y = -3.5f;
    private int adjustX = 0;
    private int adjustY = 0;
    [SerializeField] private int fireRate = 0;
    public AudioClip laserSound;
    public AudioClip backgroundMusic;

    [SerializeField] private int health = 400;
    

    [SerializeField] GameObject bullet;
    public Transform bulletPos;
    
    // Start is called before the first frame update
    void Start()
    {
        AudioSource.PlayClipAtPoint(backgroundMusic, Vector3.zero,0.5f);
        
        
    }

    // Update is called once per frame
    void Update()
    {

        fireRate += 1;
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            adjustX += -1;
        }
        
        if (Input.GetKey(KeyCode.RightArrow))
        {
            adjustX += 1;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            adjustY += 1;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            adjustY -= 1;
        }
        
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow)) adjustX = 0;
        if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.UpArrow)) adjustY = 0;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (fireRate > 80)
            {
                Shoot();
                fireRate = 0;
            }
        }

        if (health <= 100)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("Title");
        }
    }
    
    void Shoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }


    private void FixedUpdate()
    {
        if (adjustX > 0) x += 0.052f;
        if (adjustX > 50) x += 0.025f;
        if (adjustX > 70) x += 0.015f;
        if (adjustX > 125) x += 0.015f;
        if (adjustX < 0) x += -0.052f;
        if (adjustX < -50) x += -0.025f;
        if (adjustX < -70) x += -0.015f;
        if (adjustX < -125) x += -0.015f;
        
        if (adjustY > 0) y += 0.052f;
        if (adjustY > 50) y += 0.025f;
        if (adjustY > 70) y += 0.015f;
        if (adjustY > 125) y += 0.015f;
        if (adjustY < 0) y += -0.052f;
        if (adjustY < -50) y += -0.025f;
        if (adjustY < -70) y += -0.015f;
        if (adjustY < -125) y += -0.015f;

        if (x > 5.12) x = 5.12f;
        if (x < -5.12) x = -5.12f;
        if (y > 4.22) y = 4.22f;
        if (y < -4.22) y = -4.22f;
        
        transform.position = new Vector3(x, y, -1f);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            health -= 100;
        }
    }
}
