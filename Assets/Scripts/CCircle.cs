using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCircle : MonoBehaviour
{
    Rigidbody2D rigidbody;
    Animator anim;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    public void HolderHit()
    {

    }

}
