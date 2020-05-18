using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CKnifeController : MonoBehaviour
{

    public GameObject knife;
    public float delay;
    float coolTime = 0f;
    bool isCool = false;

    void Start()
    {
        

    }

    void Update()
    {

        if(!isCool)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                Instantiate(knife, transform.position, Quaternion.identity);
                isCool = true;
            }
        }
        else
        {
            coolTime += Time.deltaTime;
            if(coolTime >= delay)
            {
                isCool = false;
                coolTime = 0f;
            }
        }
        

    }
}
