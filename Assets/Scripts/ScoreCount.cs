using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreCount : MonoBehaviour
{
    public Text score;
    public Text highscore;
    //public Text timerDisplay;
    public float highscoreValue;
    public float scoreAmount;
    public float pointInSecond;

    private GameMaster gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        scoreAmount = 0f;
        pointInSecond = 1f;

    }

    // Update is called once per frame
    void Update()
    {
        string levelCheck = SceneManager.GetActiveScene().name.ToString();
        if (gm.asLost == false)
        {
            highscoreValue = PlayerPrefs.GetFloat(levelCheck);

            score.text =  scoreAmount.ToString("F0");
            scoreAmount += pointInSecond * Time.deltaTime;
            //Debug.Log(scoreAmount);
            highscore.text = "High Score: " + highscoreValue.ToString("F0");

            if (scoreAmount > highscoreValue)
            {
                PlayerPrefs.SetFloat(levelCheck, scoreAmount);
            }
            //timerDisplay.text = timer.ToString("F0");
        }

        //if (timer <= 0)
        //{
        //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        //}
        //else
        //{
        //    timer -= Time.deltaTime;
        //}
    }
}
