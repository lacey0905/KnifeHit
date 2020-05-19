using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CGameManager : MonoBehaviour
{

    public static CGameManager instance;

    public CTargetController target;
    public Knife knifePrefab;

    public Queue<Knife> holdingKnifes = new Queue<Knife>();

    int maxKnifeHoldingCount = 24;
    int stageCount = 0;
    int currentCount = 0;

    Knife currentKnife;

    bool isEndGame = false;

    public Text Count;

    private void Awake()
    {
        CGameManager.instance = this;
    }

    void Start()
    {
        target.SetRollingVelocity(100f);
        SpawnKnife();

        stageCount = Random.Range(5, 15);
        Count.text = stageCount.ToString();

    }

    void Update()
    {
        if(!isEndGame)
        {
            if (Input.GetMouseButtonDown(0))
            {
                currentKnife.Shooting();
                SpawnKnife();
            }
        }
        else
        {
            target.SetRollingVelocity(0f);
        }

    }

    private void SpawnKnife()
    {
        Knife addKnife = Instantiate(knifePrefab, transform.position, Quaternion.identity) as Knife;
        currentKnife = addKnife;
    }

    IEnumerator RemoveKnife (GameObject knife)
    {
        Destroy(knife.GetComponent<BoxCollider2D>());
        knife.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        knife.transform.parent = transform.parent;
        knife.GetComponent<Rigidbody2D>().angularVelocity = 0f;
        knife.GetComponent<Rigidbody2D>().gravityScale = 10f;
        knife.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-15f, 15f), Random.Range(-15f, 15f)), ForceMode2D.Impulse);
        yield return new WaitForSeconds(1.0f);
        Destroy(knife);
    }

    public void HoldingKnife(Knife knife)
    {
        holdingKnifes.Enqueue(knife);
        target.AddHoldingKnife(knife);
        stageCount--;
        Count.text = stageCount.ToString();
        if (stageCount <= 0)
        {
            for (int i = 0; i < Random.Range(5, holdingKnifes.Count); i++)
            {
                StartCoroutine(RemoveKnife(holdingKnifes.Dequeue().gameObject));
            }
            stageCount = Random.Range(2, 10);
            Count.text = stageCount.ToString();
            target.SetRollingVelocity(Random.Range(-150f, 150f));
        }

        //currentCount--;
        //if (currentCount <= 0)
        //{
        //    for (int i = 0; i < Random.Range(3, stageCount); i++)
        //    {
        //        holdingKnifes[i].SetDestrory();
        //    }

        //    stageCount = Random.Range(5, 15);
        //    currentCount = stageCount;

        //}
    }

    public void EndGame()
    {
        isEndGame = true;
        StartCoroutine(EndGameScene());
    }

    IEnumerator EndGameScene()
    {
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("End");
    }

}
