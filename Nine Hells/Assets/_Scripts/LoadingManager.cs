using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingManager : MonoBehaviour
{

    public static LoadingManager instance;
    private int currentLevel = 0;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
            return;
        }

        //StartCoroutine(Load());
        if (SceneManager.GetActiveScene().name.Equals("SampleScene")) currentLevel = 0;
        else currentLevel = int.Parse(SceneManager.GetActiveScene().name.Replace("Hell ", ""));
    }

    IEnumerator Load()
    {

        yield return new WaitForSeconds(5);
        LoadScene("Hell 2");
    }

    public void ReloadScene()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);
    }

    public void LoadScene(int level)
    {
        if (level == 0) LoadScene("SampleScene");
        else LoadScene("Hell " + level);
    }

    public void LoadPreviousScene()
    {
        if (currentLevel <= 0) return;
        currentLevel--;

        LoadScene(currentLevel);
    }

    public void LoadNextScene()
    {
        if (currentLevel >= 9) return;
        currentLevel++;

        LoadScene("Hell " + currentLevel);
    }

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.LeftArrow))
        //{
        //    LoadPreviousScene();
        //}
        //if (Input.GetKeyDown(KeyCode.RightArrow))
        //{
        //    LoadNextScene();
        //}
    }

}
