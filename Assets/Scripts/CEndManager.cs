using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CEndManager : MonoBehaviour
{
    
    public void Home()
    {
        SceneManager.LoadScene("Lobby");    
    }

    public void replay()
    {
        SceneManager.LoadScene("Play");
    }

}
