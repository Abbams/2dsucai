using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swanfly : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject go;
    public float mintime;
    public float rmaxtime;
    public float leftX;
    public float rightX;
    public float miny;
    public float maxy;
    public float minspeed;
    public float maxspeed;

    IEnumerator swanfun()
    {
        yield return new WaitForSeconds(Random.Range(mintime,rmaxtime));
    }
    void Start()
    {
        StartCoroutine("swanfun");
    }
   
    // Update is called once per frame
    void Update()
    {
        
    }
}
