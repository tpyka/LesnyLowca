using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    [SerializeField] bool helicopterExit = false;
    AudioPlayer audioPlayer;
    float delay = 3;
    private void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (helicopterExit == true)
        {
            Debug.Log("Laduje ekran koncowy");
            audioPlayer.PlayLevelFinishClip();
            SceneManager.LoadScene("EkranVictory");
        } 
        else
        {
            audioPlayer.PlayLevelFinishClip();
            StartCoroutine(WaitAndLoad(delay));
        }
        

 
    }

    IEnumerator WaitAndLoad(float delay)
    {
        yield return new WaitForSeconds(delay);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }



}
