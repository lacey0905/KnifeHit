﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CLobbyManager : MonoBehaviour
{


    public void GameStart()
    {
        SceneManager.LoadScene("Play");
    }

    
}
