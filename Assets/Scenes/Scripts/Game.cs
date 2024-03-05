using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private GameObject alien;
    public GameObject player;

    private int spawnTimer = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject obj = Instantiate(player, new Vector3(0, -2.75f, -1), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        spawnTimer++;
        if (spawnTimer == 30) Create("Mini", -3, 6,0.048f,0.04f);
        if (spawnTimer == 100) Create("Mini", 2, 6,0.048f,-0.04f);
        if (spawnTimer == 180) Create("Mini", -1, 6,0.038f,0.045f);
    }

    public void Create(string name, int x, int y, float mX, float mY)
    {
        GameObject obj = Instantiate(alien, new Vector3(0, 0, -1), Quaternion.identity);
        Alien ali = obj.GetComponent<Alien>();
        ali.name = name;
        ali.SetX(x);
        ali.SetY(y);
        ali.SetMX(mX);
        ali.SetMY(mY);
        ali.Activate();
    }
}
