using System;
using UnityEngine;

public class Collision : MonoBehaviour
{
    private Vector2 _tempPos;


    public Vector2 resetPos;

    private void Start()
    {
        resetPos = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _tempPos = resetPos;
        collision.transform.position = resetPos;
    }

    private void OnTriggerExit(Collider other)
    {
        
    }
}