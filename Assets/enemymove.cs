using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemymove : MonoBehaviour
{
    // Start is called before the first frame update
    public float movespeed = 5.0f;
    Rigidbody2D rb;
    public GameObject frontCheck;
    bool front = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            Flip();
        }

    }
    private void FixedUpdate() {
        rb.velocity = new Vector2(rb.transform.localScale.x * movespeed, -5);
    }
    // Update is called once per frame
    void Update()
    {
        front = Physics2D.Linecast(transform.position,
frontCheck., LayerMask.GetMask("Obstacle");
    }
    void Flip()//自定义转向函数，实现小豆人转向
               //facingright !facingright;
    {
        Vector3 scale=transform.localScale;
        scale.x *= -1;
        transform.localScale=scale; 
    }
}
