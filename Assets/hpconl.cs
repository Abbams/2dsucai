using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hpconl : MonoBehaviour
{
    // Start is called before the first frame update
    public int HP = 2;//敌人的初始生命值
    SpriteRenderer sr;//敌人身体主体部分body的渲染组件
    public Sprite damagedImage;//敌人的受伤状态的图片
    public Sprite deadedImage;//敌人的死亡状态的图片
    bool dead = false;
    void Start()
    { 
        sr = transform.Find("body").GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void death()
    {
        SpriteRenderer[] srs=GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer s in srs)
        {
            s.enabled=false;

        }
        sr.enabled = true;
        sr.sprite = damagedImage;
        Collider2D[] cd=GetComponents<Collider2D>();
        foreach (Collider2D c in cd)
            c.isTrigger=true;
        GetComponent<enemymove>().enabled = false;
        Destroy(gameObject);

    }
    private void FixedUpdate()
    {
        if (HP == 1  )
            sr.sprite = damagedImage;
        else if (HP <= 0 && !dead)
        {
            death();

        }
    }
    public void hurt()
    {
        HP--;
    }
    void Update()
    {
       
    }
}
