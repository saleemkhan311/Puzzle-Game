using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapController  : Collision
{
    public List<Transform> snapePoints;
    public List<Items> DragAbles;
    float snapeRange = 1.0f;
    
    
    public int Moves;
    void Start()
    {
       
        foreach (Items items in DragAbles )
        {
            items.dragEndedCallBack = OnDrageEnded;
        }

        Debug.Log(resetPos);
    }

    void OnDrageEnded(Items items)
    {

        
        Transform closestSnapePoint = null;
        float closestDistance = -1; 

        foreach(Transform snapePoint in snapePoints)
        {
           float currentDistance = Vector2.Distance(items.transform.position, snapePoint.transform.position);
            if(closestSnapePoint == null || currentDistance< closestDistance )
            {
                closestSnapePoint = snapePoint;
                closestDistance = currentDistance;
                
            }
        }

        if(closestSnapePoint != null && closestDistance <= snapeRange)
        {
            items.transform.position = closestSnapePoint.position;
           
            Moves++;
           

        }
    }

    
}
