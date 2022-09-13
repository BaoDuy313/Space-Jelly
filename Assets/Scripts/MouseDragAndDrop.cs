using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDragAndDrop : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject selectionEffect;
    private AudioSource source;
    private Camera _cam;
    private Vector3 _dragOffset;
    [SerializeField] private float _speed = 50;
    void Awake()
    {
        source = GetComponent<AudioSource>();
        _cam = Camera.main;
    }
    void OnMouseDown()
    {
        _dragOffset = transform.position - GetMousePos();
        Instantiate(selectionEffect, transform.position, Quaternion.identity);
        source.Play();
    }
    // Update is called once per frame

    void OnMouseDrag()
    {
        transform.position = Vector3.MoveTowards(transform.position, GetMousePos() + _dragOffset, _speed * Time.deltaTime);
    }
    Vector3 GetMousePos()
    {
        var mousePos = _cam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
    }
}
