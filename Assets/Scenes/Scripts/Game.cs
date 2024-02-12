using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private GameObject alien;
    
    // Start is called before the first frame update
    void Start()
    {
        Create("Mini", -3, 6);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void Create(string name, int x, int y)
    {
        GameObject obj = Instantiate(alien, new Vector3(0, 0, -1), Quaternion.identity);
        Alien ali = obj.GetComponent<Alien>();
        ali.name = name;
        ali.SetX(x);
        ali.SetY(y);
        ali.Activate();
    }
}
