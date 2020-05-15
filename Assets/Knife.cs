using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{

    public float speed;
    Rigidbody2D rigidbody;

    bool isTrigger = true;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.AddForce(Vector2.up * speed, ForceMode2D.Impulse);
    }

    void FixedUpdate()
    {
        if(transform.position.y >= 0f)
        {
            if (isTrigger)
            {
                rigidbody.velocity = Vector2.zero;
                transform.position = new Vector3(0f, 0f, -0.7f);
                transform.parent = GameObject.Find("KnifeHolder").transform;
                CTargetController.instance.Shake();
                isTrigger = false;
            }
        }
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if(collision.tag == "Respawn")
    //    {
            
    //    }
    //}


}
