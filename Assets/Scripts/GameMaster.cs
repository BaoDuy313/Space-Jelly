using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator transition;

    public float transitionTime = 1f;

    public GameObject restartPanel;

    public bool asLost;

    

    //public float timer;

    private void Start()
    {
       

    }

    private void Update()
    {
        
    }
    public void GameOver()
    {
        
        asLost = true;
        Invoke("Delay", 1.5f);
    }

    public void Delay()
    {
        Time.timeScale = 0f;
        restartPanel.SetActive(true);
    }

    public void GoToGameScene()
    {
        Time.timeScale = 1f;
        StartCoroutine(LoadLevel("LevelMenu"));
    }
    public void Restart()
    {
        Time.timeScale = 1f;
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().name));
    }
    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        StartCoroutine(LoadLevel("MainMenu"));
    }
    public void GoToLevel1()
    {
        Time.timeScale = 1f;
        StartCoroutine(LoadLevel("Level1"));
    }
    public void GoToLevel2()
    {
        Time.timeScale = 1f;
        StartCoroutine(LoadLevel("Level2"));
    }
    public void GoToLevel3()
    {
        Time.timeScale = 1f;
        StartCoroutine(LoadLevel("Level3"));
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void DeletePlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }
    IEnumerator LoadLevel(string lever)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(lever);
    }
}
