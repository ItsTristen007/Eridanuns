using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    private float x = 0;
    private float y = -3.5f;
    private int adjustX = 0;
    private int adjustY = 0;
    private int fireTimer = 0;
    public AudioClip laserSound;
    public AudioClip backgroundMusic;

    public Image healthBar;

    public int fireRate = 0;
    public int maxHealth = 400;
    public int health = 400;
    public float speed;

    public bool shotSpreadA, bigBulletA;


    [SerializeField] GameObject bullet, bigBullet;
    public Transform bulletPos;
    [SerializeField] Image stats;
    
    // Start is called before the first frame update
    void Start()
    {
        AudioSource.PlayClipAtPoint(backgroundMusic, Vector3.zero,0.5f);
        
        
    }

    // Update is called once per frame
    void Update()
    {

        fireTimer += 1;
        
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

        if (Input.GetKey(KeyCode.Space))
        {
            if (fireTimer >= fireRate)
            {
                Shoot();
                fireTimer = 0;
            }
        }
        
        if (adjustX > 0) x += 0.052f * speed;
        /*if (adjustX > 50) x += 0.025f * speed;
        if (adjustX > 70) x += 0.015f * speed;
        if (adjustX > 125) x += 0.015f * speed;*/
        if (adjustX < 0) x += -0.052f * speed;
        /*if (adjustX < -50) x += -0.025f * speed;
        if (adjustX < -70) x += -0.015f * speed;
        if (adjustX < -125) x += -0.015f * speed;*/
        
        if (adjustY > 0) y += 0.052f * speed;
        /*if (adjustY > 50) y += 0.025f * speed;
        if (adjustY > 70) y += 0.015f * speed;
        if (adjustY > 125) y += 0.015f * speed;*/
        if (adjustY < 0) y += -0.052f * speed;
        /*if (adjustY < -50) y += -0.025f * speed;
        if (adjustY < -70) y += -0.015f * speed;
        if (adjustY < -125) y += -0.015f * speed;*/

        if (x > 5.12) x = 5.12f;
        if (x < -5.12) x = -5.12f;
        if (y > 4.22) y = 4.22f;
        if (y < -4.22) y = -4.22f;

        if (health <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("Title");
        }

        if (Input.GetKeyUp(KeyCode.Tab))
        {
            stats.enabled = !stats.enabled;  
        }
    }
    
    void Shoot()
    {
        if (!bigBulletA)
        {
            Instantiate(bullet, bulletPos.position + Vector3.up / 1.5f, Quaternion.identity);

            if (shotSpreadA)
            {
                Instantiate(bullet, bulletPos.position + Vector3.right / 4f + Vector3.up / 2f, Quaternion.identity);
                Instantiate(bullet, bulletPos.position + Vector3.left / 4f + Vector3.up / 2f, Quaternion.identity);
            }
        }

        if (bigBulletA)
        {
            Instantiate(bigBullet, bulletPos.position + Vector3.up / 1.5f, Quaternion.identity);

            if (shotSpreadA)
            {
                Instantiate(bigBullet, bulletPos.position + Vector3.right / 4f + Vector3.up / 2f, Quaternion.identity);
                Instantiate(bigBullet, bulletPos.position + Vector3.left / 4f + Vector3.up / 2f, Quaternion.identity);
            }
        }
    }


    private void FixedUpdate()
    {
        
        
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
