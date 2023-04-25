using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyrocket : MonoBehaviour
{
    public float t=4.0f;
    public GameObject explostion;
    public AudioClip[] ac;
    void Start()
    {
        Destroy(gameObject, t);

    }
    private void OnTriggerEnter2D(Collider2D collision)

        {
        if (collision.gameObject.tag == "Enemy")
        {
            //Destroy(collision.gameObject);
            collision.gameObject.GetComponent<hpconl>().hurt();
            GameObject.Find("score").GetComponent<scoreconl>().addscore();
            int index = Random.Range(0, ac.Length);
            AudioSource.PlayClipAtPoint(ac[index], transform.position);

        }
        
        Quaternion q = Quaternion.Euler(0, 0, Random.Range(0, 360.0f));
        //实例化爆炸效果
        GameObject go = Instantiate(explostion, transform.position, q);
        Destroy(go, 0.333f);
        Destroy(gameObject);


    }
    // Update is called once per frame
        void Update()
    {
        
    }
}
