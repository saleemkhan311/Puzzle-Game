using System.Collections;
using System.Collections.Generic;
using UnityEngine;
  
public class Collision : MonoBehaviour
{
  Vector2 tempPos;
   
    
   public Vector2 resetPos;
    private void Start()
    {
        resetPos = this.transform.position;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        tempPos = resetPos;
        collision.transform.position = resetPos;
    }

   
}
