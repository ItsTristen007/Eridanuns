using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour
{
    private float timer;


    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(GameObject.Find("Player(Clone)").gameObject.transform.position.x-0.09f, GameObject.Find("Player(Clone)").gameObject.transform.position.y+0.775f);
        
        timer += Time.deltaTime;

        if (timer >= 0.48f) Destroy(this.gameObject);
    }
}
