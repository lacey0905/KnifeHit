using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CHolder : MonoBehaviour
{

    Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void HolderHit()
    {
        anim.SetTrigger("Hit");
    }

}