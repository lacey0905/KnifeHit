using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CKnifeController : MonoBehaviour
{

    public GameObject knife;

    void Start()
    {
        

    }

    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.A))
        {

            Instantiate(knife, transform.position, Quaternion.identity);

        }


    }
}
