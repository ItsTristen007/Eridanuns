using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    [SerializeField] private GameObject alien;

    private int spawnTimer = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        spawnTimer++;
        if(spawnTimer == 30) Create("Mini", -3, 6, 0.036f, 0.03f);
        if(spawnTimer == 90) Create("Mini", 3, 6, -0.036f, 0.03f);
        if(spawnTimer == 150) Create("Mini", -1, 6, 0.03f, 0.035f);

        if (spawnTimer == 1500) SceneManager.LoadScene("StartScreen");
    }

    public void Create(string name, int x, int y, float mX, float mY)
    {
        GameObject obj = Instantiate(alien, new Vector3(0, 0, -1), Quaternion.identity);
        Alien ali = obj.GetComponent<Alien>();
        ali.name = name;
        ali.SetX(x);
        ali.SetY(y);
        ali.SetmX(mX);
        ali.SetmY(mY);
        ali.Activate();
    }
}
