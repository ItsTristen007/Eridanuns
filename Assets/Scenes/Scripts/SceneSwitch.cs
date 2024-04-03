using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    [SerializeField] Button b;

    public AudioClip buttonSound;
    

    private void Start()
    {
        b.onClick.AddListener(Next);
        
    }

    void Next()
    {
        if (SceneManager.GetActiveScene().name == "Title")
        {
            SceneManager.LoadScene("Tutorial");
        } 
        if (SceneManager.GetActiveScene().name == "GameOver")
        {
            SceneManager.LoadScene("Game");
        }

        
        
    }

    public void Audio()
    {
        AudioSource.PlayClipAtPoint(buttonSound, Vector3.zero,1f);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
