using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CGameManager : MonoBehaviour
{

    public static CGameManager instance;

    public CTargetController target;
    public Knife knifePrefab;

    List<Knife> holdingKnifes = new List<Knife>();

    Knife currentKnife;

    bool isEndGame = false;

    private void Awake()
    {
        CGameManager.instance = this;
    }

    void Start()
    {
        target.SetRollingVelocity(100f);
        SpawnKnife();
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

    public void HoldingKnife(Knife knife)
    {
        holdingKnifes.Add(knife);
        target.AddHoldingKnife(knife);
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
