using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creat : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] enemies;
    public float starttime = 6.0f;
    public float timestep = 1.0f;
    void EnemyFun()
    {
        int index = Random.Range(0, enemies.Length);
        Instantiate(enemies[index], transform.position, transform.rotation);
    }
    void Start() 
    {
        InvokeRepeating("EnemyFun", starttime, timestep);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
