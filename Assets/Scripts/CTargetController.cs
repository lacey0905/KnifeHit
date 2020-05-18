using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CTargetController : MonoBehaviour
{

    public CHolder holder;

    private float direction;
    public float breakPower;

    Rigidbody2D rigidbody;


    private void Awake()
    {
        rigidbody = holder.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {





        //rollingDirection = rollingDirection + Time.deltaTime * rollingSpeed;
        //holder.Rolling(Mathf.Clamp(rollingSpeed, -maxRollingSpeed, maxRollingSpeed));
    }

    public void RollingBreak()
    {
        if(direction > 0)
        {
            float newVelocity = rigidbody.angularVelocity - breakPower * direction * Time.deltaTime;
        }

        
    }





    //public void SetRollingDirection(float dir)
    //{
    //    float direction = Mathf.Clamp(dir, -1f, 1f);
    //    rollingDirection *= dir;
    //}

    //public void SetRollingSpeed(float speed)
    //{
    //    rollingSpeed = speed;
    //}



    //IEnumerator RemoveKnife(GameObject knife)
    //{
    //    Destroy(knife.GetComponent<BoxCollider2D>());
    //    knife.transform.parent = transform.parent;
    //    knife.GetComponent<Rigidbody2D>().angularVelocity = 0f;
    //    knife.GetComponent<Rigidbody2D>().gravityScale = 10f;
    //    knife.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-15f, 15f), Random.Range(-15f, 15f)), ForceMode2D.Impulse);
    //    yield return new WaitForSeconds(1.0f);
    //    Destroy(knife);
    //}

    //public void AddKnife(GameObject knife)
    //{
    //    Knifes.Add(knife);
    //}

}
