using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    [SerializeField] Button b;

    private void Start()
    {
        b.onClick.AddListener(Next);
    }

    void Next()
    {
        if (SceneManager.GetActiveScene().ToString().Equals("Title") | SceneManager.GetActiveScene().ToString().Equals("GameOver")) ;
        {
            SceneManager.LoadScene("Game");
        } 
    }
}
