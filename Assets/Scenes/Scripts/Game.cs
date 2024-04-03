using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class Game : MonoBehaviour
{
    [SerializeField] private GameObject mini, midi, magna; 
    public GameObject taserCheck, healDropCheck, beamReal, buddy, vampCheck, damageCheck, meteors;
    public Button card1, card2, card3;
    public Sprite healthUp, timeCut, speedUp, heal, healthDrop, damage, bigBullet, shotSpread, healPlus, shield, taser, timeCutPlus, melee, vamp, meteor, beam, friend;
    public bool healthUpA, timeCutA, speedUpA, healA, healthDropA, damageA, bigBulletA, shotSpreadA, healPlusA, shieldA, taserA, timeCutPlusA, meleeA, vampA, meteorA, beamA, friendA;
    public Image progressBar;
    public Image healthBar;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI levelText;
    public GameObject player;
    public Button Exit;


    private int check = 0;

    public int score;
    
    private float spawnTimer = 0;
    private int level;
    private float levelTimer = 0;
    private float levelOffset = 6;
    private float levelLength = 30;
    private float spawnInterval = 1.5f;
    private bool levelOver = false;
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject obj = Instantiate(player, new Vector3(0, -2.75f, -1), Quaternion.identity);
        Exit.enabled = false;
        
       
        Exit.onClick.AddListener(Back);
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = $"Score: {score:0000000000}";
        levelText.text = $"Level: {level+1:00}";
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 0) { Time.timeScale = 1; Exit.gameObject.SetActive(false); }
            else
            {
                Time.timeScale = 0; Exit.enabled = true;
                Exit.gameObject.SetActive(true);
            }
        }
    }

    
    void Back()
    {
        SceneManager.LoadScene("Title");
        
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
                switch (Random.Range(0, 7))
                {
                    case 0: case 1: case 2: case 3: SpawnEnemy("Mini"); spawnInterval = 1.5f - 0.07f * level; break;
                    case 4: case 5: SpawnEnemy("Midi"); spawnInterval = 2f - 0.07f * level; break;
                    case 6: SpawnEnemy("Magna"); spawnInterval = 2.5f - 0.07f * level; break;
                }
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

    int hua, sua, tca, ha, loop, hda, da, bba, ssa, hpa, sa, ta, tcpa, ma, va, mta, ba, fa;
    private void LevelStart()
    {
        
        card1.gameObject.SetActive(false);
        card2.gameObject.SetActive(false);
        card3.gameObject.SetActive(false);
        
        GameObject p = GameObject.Find("Player(Clone)");
        Player play = p.GetComponent<Player>();
        loop = ha;
        if (healthUpA){ play.maxHealth = 400 + 100 *  hua; healthUpA = false;}
        while(loop > 0) { if (healA && play.health < play.maxHealth) { play.health += 100; } loop -= 1; }
        if (speedUpA && sua == 0) { play.speed += 0.4f; play.fireRate -= 7; sua = 1; }
        if (timeCutA && tca == 0) { levelLength -= 2; tca = 1; }
        if (healthDropA && hda == 0) { Instantiate(healDropCheck, new Vector3(300, 300, -1), Quaternion.identity); hda = 1; }
        if (bigBulletA && bba == 0) { play.bigBulletA = true; bba = 1; }
        if (shotSpreadA && ssa == 0) { play.shotSpreadA = true; ssa = 1; }
        if (healPlusA && play.health < play.maxHealth) play.health += 100; hpa = 1;
        if (healPlusA && play.health < play.maxHealth) play.health += 100;
        if (shieldA && sa == 0) { play.shieldA = true; sa = 1; }
        if (taserA && ta == 0) { Instantiate(taserCheck, new Vector3(300, 300, -1), Quaternion.identity); ta = 1; }
        if (timeCutPlusA && tcpa == 0) { levelLength -= 4; levelOffset -= 1; tcpa = 1; }
        if (beamA && ba == 0) { Instantiate(beamReal, play.bulletPos.position, Quaternion.identity); ba = 1; }
        if (friendA && fa == 0) { Instantiate(buddy, play.bulletPos.position, Quaternion.identity); fa = 1; }
        if (vampA && va == 0) { Instantiate(vampCheck, new Vector3(300, 300, -1), Quaternion.identity); va = 1; }
        if (meteorA && mta == 0) { Instantiate(meteors, play.bulletPos.position, Quaternion.identity); mta = 1; }
        if (meleeA && ma == 0) { play.meleeA = true; ma = 1; }

        level++;
        levelOver = false;
        check = 0;
    }

    public void SelectCard()
    {
        switch (EventSystem.current.currentSelectedGameObject.name)
        {
            case "healthUp": healthUpA = true; hua += 1; break;
            case "timeCut": timeCutA = true; break;
            case "speedUp": speedUpA = true; break;
            case "heal": healA = true; ha += 1; break;
            case "healthDrop": healthDropA = true; break;
            case "damage": Instantiate(healDropCheck, new Vector3(300, 300, -1), Quaternion.identity); break;
            case "bigBullet": bigBulletA = true; break;
            case "shotSpread": shotSpreadA = true; break;
            case "healPlus": healPlusA = true; break;
            case "shield": shieldA = true; break;
            case "taser": taserA = true; break;
            case "timeCutPlus": timeCutPlusA = true; break;
            case "melee": meleeA = true; break;
            case "vamp": vampA = true; break;
            case "meteor": meteorA = true; break;
            case "beam": beamA = true; break;
            case "friend": friendA = true; break;
        }
        LevelStart();
    }
    int res, res2, res3;
    private void Cards()
    {
        bool unique = false;
        
        while (!unique)
        {
            res = Random.Range(0, 47);
            switch (res)
            {
                case 0: case 11: case 12: case 27: card1.GetComponent<Image>().sprite = healthUp; card1.gameObject.name = "healthUp"; unique = true; break;
                case 1: case 13: case 14: case 28: card1.GetComponent<Image>().sprite = timeCut; card1.gameObject.name = "timeCut"; if (tca == 0) unique = true; break;
                case 2: case 15: case 16: case 29: card1.GetComponent<Image>().sprite = speedUp; card1.gameObject.name = "speedUp"; if (sua == 0) unique = true; break;
                case 3: case 17: case 18: case 30: card1.GetComponent<Image>().sprite = heal; card1.gameObject.name = "heal"; unique = true; break;
                case 4: case 19: case 20: case 31:card1.GetComponent<Image>().sprite = healthDrop; card1.gameObject.name = "healthDrop"; if (hda == 0) unique = true; break;
                case 43: case 44: case 45: case 46: card1.GetComponent<Image>().sprite = damage; card1.gameObject.name = "damage"; unique = true; break;
                case 5: case 21: case 32: card1.GetComponent<Image>().sprite = bigBullet; card1.gameObject.name = "bigBullet"; if (bba == 0) unique = true; break;
                case 6: case 22: case 33: card1.GetComponent<Image>().sprite = shotSpread; card1.gameObject.name = "shotSpread"; if (ssa == 0) unique = true; break;
                case 7: case 23: case 34: card1.GetComponent<Image>().sprite = healPlus; card1.gameObject.name = "healPlus"; if (hpa == 0) unique = true; break;
                case 8: case 24: case 35: card1.GetComponent<Image>().sprite = shield; card1.gameObject.name = "shield"; if (sa == 0) unique = true; break;
                case 9: case 25: case 36: card1.GetComponent<Image>().sprite = taser; card1.gameObject.name = "taser"; if (ta == 0) unique = true; break;
                case 10: case 26: case 37: card1.GetComponent<Image>().sprite = timeCutPlus; card1.gameObject.name = "timeCutPlus"; if (tca == 0) unique = true; break;
                case 38: card1.GetComponent<Image>().sprite = melee; card1.gameObject.name = "melee"; if (ma == 0) unique = true; break;
                case 39: card1.GetComponent<Image>().sprite = vamp; card1.gameObject.name = "vamp"; if (va == 0) unique = true; break;
                case 40: card1.GetComponent<Image>().sprite = meteor; card1.gameObject.name = "meteor"; if (mta == 0) unique = true; break;
                case 41: card1.GetComponent<Image>().sprite = beam; card1.gameObject.name = "beam"; if (ba == 0) unique = true; break;
                case 42: card1.GetComponent<Image>().sprite = friend; card1.gameObject.name = "friend"; if (fa == 0) unique = true; break;
            }
        }
        unique = false;
        
        while (!unique)
        {
            res2 = Random.Range(0, 47);
            while (res2 == res) res2 = Random.Range(0, 47);
            switch (res2)
            {
                case 0: case 11: case 12: case 27: card2.GetComponent<Image>().sprite = healthUp; card2.gameObject.name = "healthUp"; unique = true; break;
                case 1: case 13: case 14: case 28: card2.GetComponent<Image>().sprite = timeCut; card2.gameObject.name = "timeCut"; if (tca == 0) unique = true; break;
                case 2: case 15: case 16: case 29: card2.GetComponent<Image>().sprite = speedUp; card2.gameObject.name = "speedUp"; if (sua == 0) unique = true; break;
                case 3: case 17: case 18: case 30: card2.GetComponent<Image>().sprite = heal; card2.gameObject.name = "heal"; unique = true; break;
                case 4: case 19: case 20: case 31:card2.GetComponent<Image>().sprite = healthDrop; card2.gameObject.name = "healthDrop"; if (hda == 0) unique = true; break;
                case 43: case 44: case 45: case 46: card2.GetComponent<Image>().sprite = damage; card2.gameObject.name = "damage"; unique = true; break;
                case 5: case 21: case 32: card2.GetComponent<Image>().sprite = bigBullet; card2.gameObject.name = "bigBullet"; if (bba == 0) unique = true; break;
                case 6: case 22: case 33: card2.GetComponent<Image>().sprite = shotSpread; card2.gameObject.name = "shotSpread"; if (ssa == 0) unique = true; break;
                case 7: case 23: case 34: card2.GetComponent<Image>().sprite = healPlus; card2.gameObject.name = "healPlus"; if (hpa == 0) unique = true; break;
                case 8: case 24: case 35: card2.GetComponent<Image>().sprite = shield; card2.gameObject.name = "shield"; if (sa == 0) unique = true; break;
                case 9: case 25: case 36: card2.GetComponent<Image>().sprite = taser; card2.gameObject.name = "taser"; if (ta == 0) unique = true; break;
                case 10: case 26: case 37: card2.GetComponent<Image>().sprite = timeCutPlus; card2.gameObject.name = "timeCutPlus"; if (tca == 0) unique = true; break;
                case 38: card2.GetComponent<Image>().sprite = melee; card2.gameObject.name = "melee"; if (ma == 0) unique = true; break;
                case 39: card2.GetComponent<Image>().sprite = vamp; card2.gameObject.name = "vamp"; if (va == 0) unique = true; break;
                case 40: card2.GetComponent<Image>().sprite = meteor; card2.gameObject.name = "meteor"; if (mta == 0) unique = true; break;
                case 41: card2.GetComponent<Image>().sprite = beam; card2.gameObject.name = "beam"; if (ba == 0) unique = true; break;
                case 42: card2.GetComponent<Image>().sprite = friend; card2.gameObject.name = "friend"; if (fa == 0) unique = true; break;
            }
        }
        unique = false;

        while (!unique)
        {
            res3 = Random.Range(0, 47);
            while (res3 == res || res3 == res2) res3 = Random.Range(0, 47);
            switch (res3)
            {
                case 0: case 11: case 12: case 27: card3.GetComponent<Image>().sprite = healthUp; card3.gameObject.name = "healthUp"; unique = true; break;
                case 1: case 13: case 14: case 28: card3.GetComponent<Image>().sprite = timeCut; card3.gameObject.name = "timeCut"; if (tca == 0) unique = true; break;
                case 2: case 15: case 16: case 29: card3.GetComponent<Image>().sprite = speedUp; card3.gameObject.name = "speedUp"; if (sua == 0) unique = true; break;
                case 3: case 17: case 18: case 30: card3.GetComponent<Image>().sprite = heal; card3.gameObject.name = "heal"; unique = true; break;
                case 4: case 19: case 20: case 31: card3.GetComponent<Image>().sprite = healthDrop; card3.gameObject.name = "healthDrop"; if (hda == 0) unique = true; break;
                case 43: case 44: case 45: case 46: card3.GetComponent<Image>().sprite = damage; card3.gameObject.name = "damage"; unique = true; break;
                case 5: case 21: case 32: card3.GetComponent<Image>().sprite = bigBullet; card3.gameObject.name = "bigBullet"; if (bba == 0) unique = true; break;
                case 6: case 22: case 33: card3.GetComponent<Image>().sprite = shotSpread; card3.gameObject.name = "shotSpread"; if (ssa == 0) unique = true; break;
                case 7: case 23: case 34: card3.GetComponent<Image>().sprite = healPlus; card3.gameObject.name = "healPlus"; if (hpa == 0) unique = true; break;
                case 8: case 24: case 35: card3.GetComponent<Image>().sprite = shield; card3.gameObject.name = "shield"; if (sa == 0) unique = true; break;
                case 9: case 25: case 36: card3.GetComponent<Image>().sprite = taser; card3.gameObject.name = "taser"; if (ta == 0) unique = true; break;
                case 10: case 26: case 37: card3.GetComponent<Image>().sprite = timeCutPlus; card3.gameObject.name = "timeCutPlus"; if (tca == 0) unique = true; break;
                case 38: card3.GetComponent<Image>().sprite = melee; card3.gameObject.name = "melee"; if (ma == 0) unique = true; break;
                case 39: card3.GetComponent<Image>().sprite = vamp; card3.gameObject.name = "vamp"; if (va == 0) unique = true; break;
                case 40: card3.GetComponent<Image>().sprite = meteor; card3.gameObject.name = "meteor"; if (mta == 0) unique = true; break;
                case 41: card3.GetComponent<Image>().sprite = beam; card3.gameObject.name = "beam"; if (ba == 0) unique = true; break;
                case 42: card3.GetComponent<Image>().sprite = friend; card3.gameObject.name = "friend"; if (fa == 0) unique = true; break;
            }
        }
        
        card1.gameObject.SetActive(true);
        card2.gameObject.SetActive(true);
        card3.gameObject.SetActive(true);
    }
    
    public void SpawnEnemy(string name)
    {
        GameObject obj;
        switch (name)
        {
            case "Mini": obj = Instantiate(mini, new Vector3(-1110, -1110, -1), Quaternion.identity); break;
            case "Midi": obj = Instantiate(midi, new Vector3(-1110, -1110, -1), Quaternion.identity); break;
            case "Magna": obj = Instantiate(magna, new Vector3(-1110, -1110, -1), Quaternion.identity); break;
            default: obj = Instantiate(mini, new Vector3(-1110, -1110, -1), Quaternion.identity); break;
        }
        
        Alien ali = obj.GetComponent<Alien>();
        ali.name = name;
        ali.SetLevel(level);
        ali.Activate();
    }
}
