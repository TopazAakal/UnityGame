using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creator : MonoBehaviour
{
    public GameObject enemy;
    public int min = -25;
    public int max = 25;
    public GameObject coin;

    void makeCoins()
    {
        int x = Random.Range(min, max);
        int z = Random.Range(min, max);

        GameObject obj = Instantiate(coin);
        obj.name = "coin";
        obj.transform.position =  (new Vector3(x,0.5f, z));
    }

    void createEnemies()
    {
        int x= Random.Range(min, max);
        int z= Random.Range(min, max);
        GameObject obj = Instantiate(enemy);
        obj.name = "enemy";
        obj.transform.position = new Vector3(x, 0.5f, z);
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            makeCoins();
        }
        InvokeRepeating("createEnemies", 1, 10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
