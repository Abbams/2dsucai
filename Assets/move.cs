using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5f;
    public float rotateSpeed = 200f;
    private Vector3 mousePos;
    private Vector3 targetPos;
    private Vector3 moveDir;
    private Quaternion targetRot;
    private void Start()
    {
            Destroy(gameObject, 3.0f);

         mousePos = Input.mousePosition;
        mousePos.z = -Camera.main.transform.position.z;
         targetPos = Camera.main.ScreenToWorldPoint(mousePos);

         moveDir = targetPos - transform.position;
        moveDir.z = 0f;
        moveDir.Normalize();

        transform.position += moveDir * speed * Time.deltaTime;

        float angle = Mathf.Atan2(moveDir.y, moveDir.x) * Mathf.Rad2Deg - 90f;
        Quaternion targetRot = Quaternion.Euler(new Vector3(0f, 0f, angle));
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRot, rotateSpeed * Time.deltaTime);



    }
   
    private void Update()
    {
        
    }
    void FixedUpdate()
    {
        
       
        
        transform.position += moveDir * speed * Time.deltaTime;

        
    }
}
