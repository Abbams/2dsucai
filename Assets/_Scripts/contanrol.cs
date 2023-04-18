using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class contanrol : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 10.0f;//添加公有接口，增强小豆人运动效果
    Rigidbody2D rb;//获取小豆人身上的2D刚体；
    Animator anim;
    public float maxspeed = 30.0f;
    public float moveForce = 100.0f;
    public GameObject Rocket;
    public bool facingright=false;
    public Transform groundCheck;//着地检测对象的transform
    bool grounded;//着地检测标记
    bool jump = false;
    private float time;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        facingright = true;
        groundCheck = transform.Find("groundCheck").transform;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(h, v);
        //rb.velocity = movement*speed;
        anim.SetFloat("Speed", Mathf.Abs(h));//
        //更改动画控制器中的动画 参数Speed，让其大于0.1，执行Run动画
        //动画控制器.SetFloat("Speed",rb.velocity.x);
        //加入当前小豆人没有达到最大速度，添加水平推力
        if (h * rb.velocity.x < maxspeed)
            //rb.AddForce(new Vector2(1,0)*h*moveForce);
            rb.AddForce(Vector2.right * h * moveForce);
        if (Mathf.Abs(rb.velocity.x) > maxspeed)
            rb.velocity = new Vector2(Mathf.Sign(rb.velocity.x) * maxspeed,
                                      rb.velocity.y);

        //当facingright为真，h<0,让小豆人翻转
        if (facingright && h < 0) Flip();
        //当facingright为假，h>0，让小豆人翻转
        else if (!facingright && h > 0) Flip();
        if (jump)
        {
            //执行跳跃动画
            anim.SetTrigger("Jump");
            //添加向上的力量，脱离地面
            rb.AddForce(new Vector2(0, 1) * 500.0f);
            //重置跳跃标记
            jump = false;
        }
    }
    
    void Flip()
    {
        facingright = !facingright;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
    void Update()
    {
        grounded = Physics2D.Linecast(transform.position,
        groundCheck.position,
        LayerMask.GetMask("Ground"));
        if (grounded && Input.GetButtonDown("Jump"))//满足跃条件
        {
            jump = true;
        }
        

    }
}

