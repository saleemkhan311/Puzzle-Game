using System;
using System.Collections.Generic;
using UnityEngine;

public class SnapController : Collision
{
    public List<Transform> snapePoints;
    public List<Items> dragAbles;
    private float snapeRange = 1.0f;

    private Item selectedItem;

    public int moves;

    private void Start()
    {
        foreach (var items in dragAbles)
        {
            items.dragEndedCallBack = OnDrageEnded;
        }

        Debug.Log(resetPos);
    }

    private void OnDrageEnded(Items items)
    {
        Transform closestSnapePoint = null;
        var closestDistance = -1f;

        foreach (var snapePoint in snapePoints)
        {
            var currentDistance = Vector2.Distance(items.transform.position, snapePoint.transform.position);
            if (closestSnapePoint == null || currentDistance < closestDistance)
            {
                closestSnapePoint = snapePoint;
                closestDistance = currentDistance;
            }
        }

        if (closestSnapePoint != null && closestDistance <= snapeRange)
        {
            items.transform.position = closestSnapePoint.position;
            moves++;
        }
    }
}