using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    [SerializeField] private GameObject alien;
    public Button card1, card2, card3;
    public Sprite healthUp, timeCut, speedUp;
    public bool healthUpActive, timeCutActive, speedUpActive;
    public Image progressBar;
    public Image healthBar;
    public GameObject player;

    private float spawnTimer = 0;
    private float levelTimer = 0;
    private float levelLength = 25;
    private float spawnInterval = 1.5f;
    private bool levelOver = false;
    
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
        if (!levelOver)
        {
            spawnTimer += Time.deltaTime;
            levelTimer += Time.deltaTime;
            
            GameObject p = GameObject.Find("Player(Clone)");
            Player play = p.GetComponent<Player>();
            healthBar.fillAmount = (float)play.health / (float)play.maxHealth;
            
            if (spawnTimer >= spawnInterval && levelTimer < levelLength - 5)
            {
                SpawnEnemy("Mini");
                spawnTimer = 0;
            }

            progressBar.fillAmount = levelTimer / levelLength;

            if (levelTimer >= levelLength)
            {
                levelTimer = 0;
                levelOver = true;
            }
        }

        if (levelOver)
        {
            GameObject[] aliens = GameObject.FindGameObjectsWithTag("Alien");
            for (int i = 0; i < aliens.Length; i++)
            {
                Destroy(aliens[i]);
            }
            GameObject[] bullets = GameObject.FindGameObjectsWithTag("Enemy");
            for (int i = 0; i < bullets.Length; i++)
            {
                Destroy(bullets[i]);
            }
            Cards();
        }
    }

    int hua = 0, sua = 0, tca = 0;
    private void LevelStart()
    {
        
        card1.gameObject.SetActive(false);
        card2.gameObject.SetActive(false);
        card3.gameObject.SetActive(false);
        GameObject p = GameObject.Find("Player(Clone)");
        Player play = p.GetComponent<Player>();
        if (play.health < play.maxHealth) play.health += 100;
        if (healthUpActive && hua == 0) { play.health += 200; play.maxHealth += 200; hua = 1; }
        if (speedUpActive && sua == 0) { play.speed += 0.5f; sua = 1; }
        if (timeCutActive && tca == 0) { levelLength -= 3; tca = 1; }
        levelOver = false;
    }

    public void SelectCard1()
    {
        healthUpActive = true;
        LevelStart();
    }
    public void SelectCard2()
    {
        timeCutActive = true;
        LevelStart();
    }
    public void SelectCard3()
    {
        speedUpActive = true;
        LevelStart();
    }

    private void Cards()
    {
        card1.GetComponent<Image>().sprite = healthUp;
        card1.gameObject.name = "healthUp";
        card2.GetComponent<Image>().sprite = timeCut;
        card2.gameObject.name = "timeCut";
        card3.GetComponent<Image>().sprite = speedUp;
        card3.gameObject.name = "speedUp";
        card1.gameObject.SetActive(true);
        card2.gameObject.SetActive(true);
        card3.gameObject.SetActive(true);
    }
    public void SpawnEnemy(string name)
    {
        GameObject obj = Instantiate(alien, new Vector3(0, 0, -1), Quaternion.identity);
        Alien ali = obj.GetComponent<Alien>();
        ali.name = name;
        ali.Activate();
    }
}
