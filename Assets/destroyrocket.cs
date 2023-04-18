using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyrocket : MonoBehaviour
{
    public float t=4.0f;
    public GameObject explostion;

    void Start()
    {
        Destroy(gameObject, t);
    }
    private void OnTriggerEnter2D(Collider2D collision)

        {
            Destroy(gameObject);//销毁火箭弹
        Quaternion t = Quaternion.Euler(new Vector3(0, 0, Random.Range(0, 360)));
           Destroy(Instantiate(explostion, transform.position, t),0.33f);
        }
    // Update is called once per frame
        void Update()
    {
        
    }
}
