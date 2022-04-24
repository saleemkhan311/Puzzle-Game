using UnityEngine;

public class Item : MonoBehaviour
{
    
    private Sprite _sprite;

    private bool _isMoving;
    Vector2 InitialPos;
    public Transform spot;
    public Transform newSpot;
    
    public void Setup(Sprite sprite, Transform spotTransform)
    {
        _sprite = sprite;
        spot = spotTransform;
    }

    public void UpdateRenderer()
    {
        GetComponent<SpriteRenderer>().sprite = _sprite;
    }

    private void Start()
    {
        InitialPos = transform.position;
    }
    private void Update()
    {
        if (_isMoving == true)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(mousePos.x, mousePos.y);
        }
    }
    private void OnMouseDrag()
    {
       
        
        _isMoving = true;
    }

    private void OnMouseDown()
    {
        if (GameManager.Singleton.win == true) return;
        if (GameManager.Singleton.lose == true) return;
        Debug.Log("Drag");
        _isMoving = true;
    }

    private void OnMouseUp()
    {

        float distance = Vector2.Distance(transform.position, spot.position);
        if (distance < 0.5f)
        {
            transform.position = spot.position;
            InitialPos = transform.position;
        }
        //else { transform.position = InitialPos; }
        

        _isMoving = false;
        if (newSpot == null) return;
        
        
    }
}