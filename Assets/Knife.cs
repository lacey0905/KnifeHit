using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{

    public float knifeShootingSpeed;

    Animation anim;
    Rigidbody2D rigidbody;

    bool isHolding = false;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animation>();
        anim.Play("KnifeSpawn");
    }

    public void Shooting()
    {
        rigidbody.AddForce(Vector2.up * knifeShootingSpeed, ForceMode2D.Impulse);
    }

    public bool IsHolding()
    {
        return isHolding;
    }

    public void SetDestrory()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!isHolding)
        {
            if (collision.gameObject.tag == "Target")
            {
                GameObject.Find("Holder").GetComponent<CHolder>().HolderHit();
                this.gameObject.tag = "Holding";
                rigidbody.bodyType = RigidbodyType2D.Kinematic;
                isHolding = true;
                rigidbody.velocity = Vector2.zero;
                transform.position = new Vector3(0f, 0f, 3f);
                CGameManager.instance.HoldingKnife(this);
            }
            else if (collision.gameObject.tag == "Holding")
            {
                rigidbody.AddTorque(1000f);
                Destroy(GetComponent<BoxCollider2D>());
                rigidbody.velocity = Vector2.zero;
                Vector2 dir = new Vector2(Random.Range(-1f, 1f) * 20f, -1f);
                rigidbody.AddForce(dir, ForceMode2D.Impulse);
                rigidbody.gravityScale = 15f;
                CGameManager.instance.EndGame();
            }
        }
    }

}
