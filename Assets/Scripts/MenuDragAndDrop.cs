using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuDragAndDrop : MonoBehaviour
{
    bool moveAllowed;
    Collider2D col;

    public GameObject selectionEffect;
    //public GameObject deathEffect;

    //private GameMaster gm;

    private AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
        //gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        col = GetComponent<Collider2D>();
    }

    
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

            if(touch.phase == TouchPhase.Began)
            {
                Collider2D touchCollider = Physics2D.OverlapPoint(touchPosition);
                if(col == touchCollider)
                {
                    Instantiate(selectionEffect, transform.position, Quaternion.identity);
                    source.Play();
                    moveAllowed = true;
                }
            }

            if (touch.phase == TouchPhase.Moved)
            {
                if (moveAllowed)
                {
                    transform.position = new Vector2(touchPosition.x, touchPosition.y);
                }
            }

            if (touch.phase == TouchPhase.Ended)
            {
                moveAllowed = false;
            }
        }
    }
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.tag == "Jelly")
    //    {
    //        Instantiate(deathEffect, transform.position, Quaternion.identity);
    //        gm.GameOver();
    //        Destroy(gameObject);
    //    }
    //}
}
