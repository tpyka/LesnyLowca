using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    [SerializeField] float sceneLoadDelay = 3f;

    public void LoadEkranKoncowy()
    {

        StartCoroutine(WaitAndLoad("DeathMenu", sceneLoadDelay));
    }

    public void LoadPoTNT()
    {
        StartCoroutine(WaitAndLoad("Level 3", sceneLoadDelay));
    }

    public void LoadPoBoss()
    {

        StartCoroutine(WaitAndLoad("Level 6", sceneLoadDelay));
    }

    public void LoadGame()
    { 
        SceneManager.LoadScene("Level 1");
    }

    IEnumerator WaitAndLoad(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void LoadLevel2()
    {
        SceneManager.LoadScene("Level 2");
    }

    public void LoadLevel3()
    {
        SceneManager.LoadScene("Level 3");
    }

    public void LoadLevel4()
    {
        SceneManager.LoadScene("Level 4");
    }

    public void LoadLevel5()
    {
        SceneManager.LoadScene("Level 5");
    }

    public void LoadLevel6()
    {
        SceneManager.LoadScene("Level 6");
    }
}
