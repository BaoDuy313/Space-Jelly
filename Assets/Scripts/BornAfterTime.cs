using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BornAfterTime : MonoBehaviour
{
    public GameObject jelly;
    public Transform bornPos;
    public GameObject blackhole;

    public float time;
    int numberBorn;
    public int maxBorn;

    private ScoreCount sc;

    public Animator transition;
    void Start()
    {
        sc = GameObject.FindGameObjectWithTag("GM").GetComponent<ScoreCount>();
        numberBorn = 0;
        blackhole.SetActive(false);
    }


    void Update()
    {
        if (numberBorn <= maxBorn)
        {
            jellyBorn();
            
        }
    }
    void jellyBorn()
    {
        
        if (sc.scoreAmount > time)
        {
            Debug.Log("start");
            blackhole.SetActive(true);
            transition.SetTrigger("start");
            Invoke("born", 2.5f);

           
            time += time;
            numberBorn += 1;
        }
    }
    public void born()
    {
        Debug.Log("born");
        Instantiate(jelly, bornPos.position, Quaternion.identity);
        Invoke("BH", 2f);
    }
    public void BH()
    {
        blackhole.SetActive(false);
    }
}
