using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CTargetController : MonoBehaviour
{

    public static CTargetController instance;

    Rigidbody rigidbody;
    Animator anim;

    public float speed;
    public GameObject circle;

    public Text count;

    int stageCount = 5;
    int curCount = 0;

    List<GameObject> Knifes = new List<GameObject>();

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
        curCount = stageCount;
        count.text = curCount.ToString();
    }

    public void AddCount()
    {
        curCount = curCount - 1;
        if(curCount <= 0)
        {
            for(int i=0; i<Knifes.Count; i++)
            {
                int select = Random.Range(0, 2);
                if(select > 0)
                {
                    StartCoroutine(RemoveKnife(Knifes[i]));
                }
            }
            curCount = stageCount * 2;
        }
        count.text = curCount.ToString();
    }

    IEnumerator RemoveKnife(GameObject knife)
    {
        Destroy(knife.GetComponent<BoxCollider2D>());
        knife.transform.parent = transform.parent;
        knife.GetComponent<Rigidbody2D>().angularVelocity = 0f;
        knife.GetComponent<Rigidbody2D>().gravityScale = 10f;
        knife.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-15f, 15f), Random.Range(-15f, 15f)), ForceMode2D.Impulse);
        yield return new WaitForSeconds(1.0f);
        Destroy(knife);
    }

    public void AddKnife(GameObject knife)
    {
        Knifes.Add(knife);
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
