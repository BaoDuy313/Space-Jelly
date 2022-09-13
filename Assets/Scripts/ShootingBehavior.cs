using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingBehavior : MonoBehaviour
{
    public Transform shotPos;

    public GameObject projecttile;

    private float timeBtwShot;
    public float startTimeBtwShot;

    public float startTimeBtwShotMax;

    public float secondsToMaxDifficulty;
    void Start()
    {
        timeBtwShot = 3;
    }

    void Update()
    {
        if (timeBtwShot <= 0)
        {
            Instantiate(projecttile, shotPos.position, Quaternion.identity);

            timeBtwShot = Mathf.Lerp(startTimeBtwShotMax,startTimeBtwShot,GetDiffcultyPercent());
        }
        else
        {
            timeBtwShot -= Time.deltaTime;
        }
    }
    float GetDiffcultyPercent()
    {
        return Mathf.Clamp01(Time.timeSinceLevelLoad / secondsToMaxDifficulty);
    }
}
