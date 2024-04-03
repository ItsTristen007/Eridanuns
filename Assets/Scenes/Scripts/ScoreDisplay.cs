using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    
    [SerializeField] private TextMeshProUGUI highScore;

    [SerializeField] Button b2;
    [SerializeField] Button b3;
    [SerializeField] Button b4;
    public static int score;
    // Start is called before the first frame update
    void Start()
    {
        
        b2.onClick.AddListener(HighScore);
        b3.onClick.AddListener(Back);
       
        
        if ( score > PlayerPrefs.GetInt("Highscore"))
        {
            PlayerPrefs.SetInt("Highscore", score);
        }
        
        
    }

    void HighScore()
    {
        GameObject.FindGameObjectWithTag("Play").SetActive(false);
        b2.gameObject.SetActive(false);
        b3.gameObject.SetActive(true);
        highScore.gameObject.SetActive(true);
        highScore.text = "Your score was: " + score.ToString() + ". The All-Time High Score is : " + PlayerPrefs.GetInt("Highscore").ToString();
    }

    void Back()
    {
        
        b3.gameObject.SetActive(false);
        b2.gameObject.SetActive(true);
        highScore.gameObject.SetActive(false);
        b4.gameObject.SetActive(true);
    }

   

    
}
