using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootconcl : MonoBehaviour
{
    // Start is called before the first frame update
    private float time;
    public GameObject Rocket;
    public float speed;
    public Transform shootpostion;
    private Animator anim;
    contanrol contanroler;
    void Start()
    {
        contanroler = transform.root.GetComponent<contanrol>();
        time = Time.timeSinceLevelLoad;
        anim = transform.root.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.timeSinceLevelLoad > time + 1)
        {
            time = Time.timeSinceLevelLoad;
            GameObject go;
            Rigidbody2D rb;
            if (contanroler.facingright)
            {
                anim.SetTrigger("Shoot");
                 go=
                (GameObject)Instantiate(Rocket, shootpostion.position,
                Quaternion.identity);
                rb=go.GetComponent<Rigidbody2D>();
                rb.velocity=new Vector2(speed, 0); 
            }
            else
            {

                anim.SetTrigger("Shoot");
                go =
                (GameObject)Instantiate(Rocket, shootpostion.position,
                Quaternion.Euler(new Vector3(0, 0, 180)));
                 rb=go.GetComponent<Rigidbody2D>();
                rb.velocity=new Vector2(-speed, 0);
                
            }
           


        }
    }
}
