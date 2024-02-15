using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.TextCore.Text;
using UnityEngine;

public class Player : MonoBehaviour
{

    private float x = 0;
    private float y = -3.5f;
    private int adjustX = 0;
    private int adjustY = 0;
    private int fireRate = 0;
    public AudioClip laserSound;
    public AudioClip backgroundMusic; 
    

    [SerializeField] GameObject bullet;
    
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
                Create("laser", x, y+.8f);
                fireRate = 0;
            }
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
        AudioSource.PlayClipAtPoint(laserSound, Vector3.zero);
    }

    private void FixedUpdate()
    {
        if (adjustX > 0) x += 0.032f;
        if (adjustX > 50) x += 0.015f;
        if (adjustX > 70) x += 0.015f;
        if (adjustX > 125) x += 0.015f;
        if (adjustX < 0) x += -0.032f;
        if (adjustX < -50) x += -0.015f;
        if (adjustX < -70) x += -0.015f;
        if (adjustX < -125) x += -0.015f;
        
        if (adjustY > 0) y += 0.032f;
        if (adjustY > 50) y += 0.015f;
        if (adjustY > 70) y += 0.015f;
        if (adjustY > 125) y += 0.015f;
        if (adjustY < 0) y += -0.032f;
        if (adjustY < -50) y += -0.015f;
        if (adjustY < -70) y += -0.015f;
        if (adjustY < -125) y += -0.015f;

        if (x > 5.12) x = 5.12f;
        if (x < -5.12) x = -5.12f;
        if (y > 4.22) y = 4.22f;
        if (y < -4.22) y = -4.22f;
        
        transform.position = new Vector3(x, y, -1f);
    }
}
