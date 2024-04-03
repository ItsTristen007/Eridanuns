using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleBuddy : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;
    private int shootTimer = 0;
    public int shootRate = 0;

    // Update is called once per frame
    void FixedUpdate()
    {
        shootTimer++;
        if (shootTimer > shootRate)
        {
            Shoot();
            shootTimer = 0;
        }
    }

    void Update()
    {
        transform.position = new Vector2(GameObject.Find("Player(Clone)").gameObject.transform.position.x-1.434f, GameObject.Find("Player(Clone)").gameObject.transform.position.y-0.295f);
    }
    
    void Shoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }
}
