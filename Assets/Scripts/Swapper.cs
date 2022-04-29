using System;
using UnityEngine;

public class Swapper : MonoBehaviour
{

    private static Swapper _singleton;

    public static Swapper Singleton
    {
        get => _singleton;
        private set
        {
            if (_singleton == null)
            {
                _singleton = value;
                return;
            }

            Destroy(value.gameObject);
        }
    }
    
    public Item selectedItem;
    public Item swapItem;

    private void Awake()
    {
        Singleton = this;
    }

    private void Update()
    {
        if (Camera.main == null) return;
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (selectedItem != null)
        {
            selectedItem.transform.position = mousePos;
        }
        else if (Input.GetMouseButtonDown(0))
        {
            var targetObject = Physics2D.OverlapPoint(mousePos);
            if (!targetObject) return;
            var item = targetObject.transform.gameObject.GetComponent<Item>();
            if (item == null) return;
            selectedItem = item;
            Debug.Log($"Item selected {item.name}");
        }
        
        if (Input.GetMouseButtonUp(0))
        {
            if (selectedItem == null) return;
            Debug.Log($"Dropping the Item {selectedItem.name}");
            if (swapItem != null)
            {
                (selectedItem.spot, swapItem.spot) = (swapItem.spot, selectedItem.spot);
                selectedItem.Rest();
                swapItem.Rest();
                selectedItem = null;
            }
            else
            {
                selectedItem.Rest();
                selectedItem = null;
            }
        }
    }
}