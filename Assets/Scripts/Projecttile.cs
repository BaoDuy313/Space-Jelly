using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projecttile : MonoBehaviour
{
    private GameObject[] jellys;

    private Vector2 target;

     float speed;

    public float minSpeed;
    public float maxSpeed;

    

    public float secondsToMaxDifficulty;

    private GameMaster gm;

    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        jellys = GameObject.FindGameObjectsWithTag("Jelly");

        int rand = Random.Range(0, jellys.Length);
        try
        {
            target = jellys[rand].transform.position;
        }
        catch { }
    }
    private void Update()
    {
        speed = Mathf.Lerp(minSpeed, maxSpeed, GetDiffcultyPercent());
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, target) < 0.2f)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Jelly"))
        {
            Destroy(other.gameObject, 0.1f);
            Destroy(gameObject, 0.1f);
            gm.GameOver();
        }
    }
    float GetDiffcultyPercent()
    {
        return Mathf.Clamp01(Time.timeSinceLevelLoad / secondsToMaxDifficulty);
    }
}
