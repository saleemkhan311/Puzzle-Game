using System;
using System.Collections.Generic;
using UnityEngine;


public class Swapper : MonoBehaviour
{
    List<Pair> _instructions = new();
     class Pair
    {
        string pair1;
        string pair2;
        public Pair(string str1,string str2)
        {
            pair1 = str1;
            pair2 = str2;
        }

        public bool Compare(Pair pair)
        {
            return string.Equals(pair.pair1, pair1) && string.Equals(pair.pair2, pair2) || string.Equals(pair.pair2, pair1) && string.Equals(pair.pair1, pair2); 
        }
    }
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
        _instructions.Add(new Pair("item 3", "item 17"));
       
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
           
        }
        
        if (Input.GetMouseButtonUp(0))
        {
            if (selectedItem == null) return;
           
            if (swapItem != null)
            {
                (selectedItem.spot, swapItem.spot) = (swapItem.spot, selectedItem.spot);
                var pair = new Pair(selectedItem.name, swapItem.name);
                bool instructionMatch;
                foreach(Pair instruction in _instructions )
                {
                    if(instruction.Compare(pair))
                    {
                        Debug.Log("Instrcution Complete");
                    }
                }
                selectedItem.Rest();
                swapItem.Rest();
                GameManager.Singleton.moves++;
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