using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Tutorial" && Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("Tutorial 2");
        }
        if (SceneManager.GetActiveScene().name == "Tutorial 2" && Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("Tutorial 3");
        }
        if (SceneManager.GetActiveScene().name == "Tutorial 3" && Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("Tutorial 4");
        }
        if (SceneManager.GetActiveScene().name == "Tutorial 4" && Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("Tutorial 5");
        }
        if (SceneManager.GetActiveScene().name == "Tutorial 5" && Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("Game");
        }
    }
}
