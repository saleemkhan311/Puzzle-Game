using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    public delegate void DragEndedDalegate(Items dragAbles);
    public DragEndedDalegate dragEndedCallBack;
    public       GameObject itemSlot;
    
    public bool isMoving;
    float startPosX;
    float startPosY;
    float score;
    Vector2 resetPos;
    bool isPositioned = false;
    SpriteRenderer sprite;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        resetPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
       
        if (transform.position.x > 7.5f)
        {
            transform.position = new Vector2(7.5f, transform.position.y);
        }
        else if (transform.position.x < -4.2)
        {
            transform.position = new Vector2(-4.2f, transform.position.y);
        }

        if (transform.position.y > 3.0f)
        {
            transform.position = new Vector2(transform.position.x, 3.0f);
        }
        else if (transform.position.y < -3.5)
        {
            transform.position = new Vector2(transform.position.x, -3.5f);
        }
        

    }
    private void OnMouseDrag()
    {
        if(GameManager.singleton.win != true )
        {
           if(GameManager.singleton.lose != true)
            {
                if (isMoving)
                {
                    if (!isPositioned)
                    {
                        Vector3 mousePos;
                        mousePos = Input.mousePosition;
                        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
                        transform.position = new Vector2(mousePos.x, mousePos.y);
                    }
                }
            }
        }
    }
    private void OnMouseDown()
    {
       if(GameManager.singleton.win != true )
        {

           if(GameManager.singleton.lose != true)
            {
                Vector3 mousePos;
                mousePos = Input.mousePosition;
                mousePos = Camera.main.ScreenToWorldPoint(mousePos);


                isMoving = true;

                sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 0.5f);
            }
        }
    }

    private void OnMouseUp()
    {

       if(GameManager.singleton.win != true )
        {
            if(GameManager.singleton.lose != true)
            {
                if (Mathf.Abs(transform.position.x - itemSlot.transform.position.x) <= 1.0f && Mathf.Abs(transform.position.y - itemSlot.transform.position.y) <= 1.0f)
                {
                    transform.position = new Vector2(itemSlot.transform.position.x, itemSlot.transform.position.y);
                    if (transform.position == itemSlot.transform.position)
                    {
                        GameManager.singleton.scores++;
                        isPositioned = true;
                        GetComponent<BoxCollider2D>().enabled = false;
                        Debug.Log("Scores = " + score);
                    }


                }

                isMoving = false;

                sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 1);
                dragEndedCallBack(this);
            }
        }
    }
    
    
}
