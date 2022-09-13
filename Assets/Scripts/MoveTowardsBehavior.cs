using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsBehavior : MonoBehaviour
{
    public Transform ortherSlime;

    public float minSpeed;
    public float maxSpeed;

    float speed;

    public float secondsToMaxDifficulty;

    void Start()
    {
        
    }

    void Update()
    {
        if (ortherSlime)
        {
            Vector3 temp = transform.localScale;

            speed = Mathf.Lerp(minSpeed, maxSpeed, GetDiffcultyPercent());
            transform.position = Vector2.MoveTowards(transform.position, ortherSlime.position, speed * Time.deltaTime);
            if (transform.position.x > ortherSlime.position.x)
            {
                temp.x = -1f;
            }
            else
            {
                temp.x = 1f;
            }
            transform.localScale = temp;
        }
        
    }
    float GetDiffcultyPercent()
    {
        return Mathf.Clamp01(Time.timeSinceLevelLoad / secondsToMaxDifficulty);
    }
}
