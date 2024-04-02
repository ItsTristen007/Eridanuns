using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Game : MonoBehaviour
{
    [SerializeField] private GameObject mini, midi, magna, boss, taserCheck, healDropCheck;
    public Button card1, card2, card3;
    public Sprite healthUp, timeCut, speedUp, heal, healthDrop, bigBullet, shotSpread, healPlus, shield, taser, timeCutPlus;
    public bool healthUpA, timeCutA, speedUpA, healA, healthDropA, bigBulletA, shotSpreadA, healPlusA, shieldA, taserA, timeCutPlusA;
    public Image progressBar;
    public Image healthBar;
    public GameObject player;

    private int check = 0;
    
    private float spawnTimer = 0;
    private float levelTimer = 0;
    private float levelOffset = 5;
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
            
            if (spawnTimer >= spawnInterval && levelTimer < levelLength - levelOffset)
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

        if (levelOver && check == 0)
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
            check = 1;
        }
    }

    int hua, sua, tca, ha, hda, bba, ssa, hpa, sa, ta, tcpa;
    private void LevelStart()
    {
        
        card1.gameObject.SetActive(false);
        card2.gameObject.SetActive(false);
        card3.gameObject.SetActive(false);
        
        GameObject p = GameObject.Find("Player(Clone)");
        Player play = p.GetComponent<Player>();
        
        if (healA && play.health < play.maxHealth) play.health += 100;
        if (healthUpA && hua == 0) { play.health += 200; play.maxHealth += 200; hua = 1; }
        if (speedUpA && sua == 0) { play.speed += 1f; play.fireRate -= 10; sua = 1; }
        if (timeCutA && tca == 0) { levelLength -= 2; levelOffset -= 1; tca = 1; }
        if (healthDropA && hda == 0) { Instantiate(healDropCheck, new Vector3(300, 300, -1), Quaternion.identity); hda = 1; }
        if (bigBulletA && bba == 0) { }
        if (shotSpreadA && ssa == 0) { play.shotSpreadA = true; ssa = 1; }
        if (healPlusA && play.health < play.maxHealth) play.health += 100;
        if (healPlusA && play.health < play.maxHealth) play.health += 100;
        if (shieldA && sa == 0) { }
        if (taserA && ta == 0) { Instantiate(taserCheck, new Vector3(300, 300, -1), Quaternion.identity); ta = 1; }
        if (timeCutPlusA && tcpa == 0) { levelLength -= 4; levelOffset -= 1; tcpa = 1; }
        
        
        levelOver = false;
        check = 0;
    }

    public void SelectCard()
    {
        switch (EventSystem.current.currentSelectedGameObject.name)
        {
            case "healthUp": healthUpA = true; break;
            case "timeCut": timeCutA = true; break;
            case "speedUp": speedUpA = true; break;
            case "heal": healA = true; break;
            case "healthDrop": healthDropA = true; break;
            case "bigBullet": bigBulletA = true; break;
            case "shotSpread": shotSpreadA = true; break;
            case "taser": taserA = true; break;
            case "timeCutPlus": timeCutPlusA = true; break;
        }
        LevelStart();
    }

    private void Cards()
    {
        
        int res = Random.Range(0, 11);
        switch (res)
        {
            case 0: card1.GetComponent<Image>().sprite = healthUp; card1.gameObject.name = "healthUp"; break;
            case 1: card1.GetComponent<Image>().sprite = timeCut; card1.gameObject.name = "timeCut"; break;
            case 2: card1.GetComponent<Image>().sprite = speedUp; card1.gameObject.name = "speedUp"; break;
            case 3: card1.GetComponent<Image>().sprite = heal; card1.gameObject.name = "heal"; break;
            case 4: card1.GetComponent<Image>().sprite = healthDrop; card1.gameObject.name = "healthDrop"; break;
            case 5: card1.GetComponent<Image>().sprite = bigBullet; card1.gameObject.name = "bigBullet"; break;
            case 6: card1.GetComponent<Image>().sprite = shotSpread; card1.gameObject.name = "shotSpread"; break;
            case 7: card1.GetComponent<Image>().sprite = healPlus; card1.gameObject.name = "healPlus"; break;
            case 8: card1.GetComponent<Image>().sprite = shield; card1.gameObject.name = "shield"; break;
            case 9: card1.GetComponent<Image>().sprite = taser; card1.gameObject.name = "taser"; break;
            case 10: card1.GetComponent<Image>().sprite = timeCutPlus; card1.gameObject.name = "timeCutPlus"; break;
        }
        
        int res2 = Random.Range(0, 11);
        while (res2 == res) res2 = Random.Range(0, 11);
        switch (res2)
        {
            case 0: card2.GetComponent<Image>().sprite = healthUp; card2.gameObject.name = "healthUp"; break;
            case 1: card2.GetComponent<Image>().sprite = timeCut; card2.gameObject.name = "timeCut"; break;
            case 2: card2.GetComponent<Image>().sprite = speedUp; card2.gameObject.name = "speedUp"; break;
            case 3: card2.GetComponent<Image>().sprite = heal; card2.gameObject.name = "heal"; break;
            case 4: card2.GetComponent<Image>().sprite = healthDrop; card2.gameObject.name = "healthDrop"; break;
            case 5: card2.GetComponent<Image>().sprite = bigBullet; card2.gameObject.name = "bigBullet"; break;
            case 6: card2.GetComponent<Image>().sprite = shotSpread; card2.gameObject.name = "shotSpread"; break;
            case 7: card2.GetComponent<Image>().sprite = healPlus; card2.gameObject.name = "healPlus"; break;
            case 8: card2.GetComponent<Image>().sprite = shield; card2.gameObject.name = "shield"; break;
            case 9: card2.GetComponent<Image>().sprite = taser; card2.gameObject.name = "taser"; break;
            case 10: card2.GetComponent<Image>().sprite = timeCutPlus; card2.gameObject.name = "timeCutPlus"; break;
        }
        int res3 = Random.Range(0, 11);
        while (res3 == res || res3 == res2) res3 = Random.Range(0, 11);
        switch (res3)
        {
            case 0: card3.GetComponent<Image>().sprite = healthUp; card3.gameObject.name = "healthUp"; break;
            case 1: card3.GetComponent<Image>().sprite = timeCut; card3.gameObject.name = "timeCut"; break;
            case 2: card3.GetComponent<Image>().sprite = speedUp; card3.gameObject.name = "speedUp"; break;
            case 3: card3.GetComponent<Image>().sprite = heal; card3.gameObject.name = "heal"; break;
            case 4: card3.GetComponent<Image>().sprite = healthDrop; card3.gameObject.name = "healthDrop"; break;
            case 5: card3.GetComponent<Image>().sprite = bigBullet; card3.gameObject.name = "bigBullet"; break;
            case 6: card3.GetComponent<Image>().sprite = shotSpread; card3.gameObject.name = "shotSpread"; break;
            case 7: card3.GetComponent<Image>().sprite = healPlus; card3.gameObject.name = "healPlus"; break;
            case 8: card3.GetComponent<Image>().sprite = shield; card3.gameObject.name = "shield"; break;
            case 9: card3.GetComponent<Image>().sprite = taser; card3.gameObject.name = "taser"; break;
            case 10: card3.GetComponent<Image>().sprite = timeCutPlus; card3.gameObject.name = "timeCutPlus"; break;
        }
        
        card1.gameObject.SetActive(true);
        card2.gameObject.SetActive(true);
        card3.gameObject.SetActive(true);
    }
    
    public void SpawnEnemy(string name)
    {
        GameObject obj = Instantiate(mini, new Vector3(0, 0, -1), Quaternion.identity);;
        switch (name)
        {
            case "mini": obj = Instantiate(mini, new Vector3(0, 0, -1), Quaternion.identity); break;
            case "midi": obj = Instantiate(mini, new Vector3(0, 0, -1), Quaternion.identity); break;
            case "magna": obj = Instantiate(mini, new Vector3(0, 0, -1), Quaternion.identity); break;
        }
        
        Alien ali = obj.GetComponent<Alien>();
        ali.name = name;
        ali.Activate();
    }
}
