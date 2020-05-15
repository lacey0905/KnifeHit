using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CTargetController : MonoBehaviour
{

    public static CTargetController instance;

    Rigidbody rigidbody;
    Animator anim;

    public float speed;
    public GameObject circle;

    private void Awake()
    {
        CTargetController.instance = this;
        rigidbody = circle.GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    public void Shake()
    {
        anim.SetTrigger("Shake");
    }

    void Start()
    {
        
    }

    void FixedUpdate()
    {

        rigidbody.angularVelocity = new Vector3(0f, 0f, 1f) * speed;

        if (Input.GetMouseButton(0))
        {
            speed -= Time.deltaTime * 5f;
            
        }
        else if (Input.GetMouseButton(1))
        {
            speed += Time.deltaTime * 5f;
        }

        speed = Mathf.Clamp(speed, -3f, 3f);
    }
}
