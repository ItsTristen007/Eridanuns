using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.CompareTag("Shield")) transform.position = new Vector2(GameObject.Find("Player(Clone)").gameObject.transform.position.x, GameObject.Find("Player(Clone)").gameObject.transform.position.y-0.1f);
        if (gameObject.CompareTag("beam")) transform.position = new Vector2(GameObject.Find("Player(Clone)").gameObject.transform.position.x, GameObject.Find("Player(Clone)").gameObject.transform.position.y+1f);
        if (gameObject.CompareTag("bigBullet"))
        {
            transform.position = new Vector2(GameObject.Find("Player(Clone)").gameObject.transform.position.x, GameObject.Find("Player(Clone)").gameObject.transform.position.y);
            transform.rotation = Quaternion.Euler(0,0,Time.time*360);
        }
        
    }
}
