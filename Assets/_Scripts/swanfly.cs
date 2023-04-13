using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swanfly : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject go;
    public float mintime;
    public float maxtime;
    public float leftX;
    public float rightX;
    public float miny;
    public float maxy;
    public float minspeed;
    public float maxspeed;

    IEnumerator SwanFun()
    {
        float waittime = Random.Range(mintime, maxtime);
        yield return new WaitForSeconds(waittime);
        bool facingleft = Random.Range(0, 2) == 0;
        float posX = facingleft ? rightX : leftX;
        float posY = Random.Range(miny, maxy);
        Vector3 swanposition = new Vector3(posX, posY, transform.position.z);
        GameObject swan =
            Instantiate(go, swanposition, Quaternion.identity);
        Rigidbody2D rb = swan.GetComponent<Rigidbody2D>();
        if (!facingleft)
        {
            Vector3 scale = rb.transform.localScale;
            scale.x *= -1.0f;
            rb.transform.localScale = scale;
        }
        float speed = Random.Range(minspeed, maxspeed);
        speed *= facingleft ? -1.0f : 1.0f;
        rb.velocity = new Vector2(speed, 0);
        StartCoroutine(SwanFun());//持续生成天鹅
        while (rb != null)
        {
            if (facingleft)
            {
                if (rb.transform.position.x < leftX - 0.5f)
                    Destroy(rb.gameObject);
            }
            else
            {
                if (rb.transform.position.x > rightX + 0.5f)
                    Destroy(rb.gameObject);
            }
            yield return null;
        }

    }
    void Start()
    {
        StartCoroutine(SwanFun());
    }
   
    // Update is called once per frame
    void Update()
    {
        
    }
}
