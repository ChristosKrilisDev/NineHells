using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void Play()
    {
        LoadingManager.instance.LoadScene("Hell 1");
    }

    public void ExitApplication()
    {
        Application.Quit();
    }
}
