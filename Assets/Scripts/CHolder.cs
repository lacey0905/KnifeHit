using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CHolder : MonoBehaviour
{

    Rigidbody2D rigidbody;
    Animator anim;
    
    //private float currentTorque;
    //private float direction = 0f;

    //public float rollingTorque;
    //public float limit;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    public void HolderHit()
    {

    }

    //public void SetDirection(float dir)
    //{
    //    direction = Mathf.Clamp(dir, -1f, 1f);
    //}

    //public void SetDirectRolling()
    //{
    //    rigidbody.angularVelocity = limit;
    //}

   

    private void FixedUpdate()
    {
        //rigidbody.AddTorque(rollingTorque * direction);
        //currentTorque = rigidbody.angularVelocity;
        //rigidbody.angularVelocity = Mathf.Clamp(currentTorque, -limit, limit);
    }

}