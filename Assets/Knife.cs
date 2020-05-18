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
        //if(transform.position.y >= 0f)
        //{
        //    if (isTrigger)
        //    {
        //        CTargetController.instance.AddCount();
        //        CTargetController.instance.AddKnife(this.gameObject);
        //        this.gameObject.tag = "InKnife";
        //        rigidbody.velocity = Vector2.zero;
        //        transform.position = new Vector3(0f, 0f, 0f);
        //        transform.parent = GameObject.Find("KnifeHolder").transform;
        //        CTargetController.instance.Shake();
        //        isTrigger = false;
        //    }
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "InKnife")
        {

            rigidbody.AddTorque(1000f);

            Destroy(GetComponent<BoxCollider2D>());

            rigidbody.velocity = Vector2.zero;

            Vector2 dir = new Vector2(Random.Range(-1f, 1f) * 20f, -1f);
            rigidbody.AddForce(dir, ForceMode2D.Impulse);

            rigidbody.gravityScale = 15f;
        }
    }


}
