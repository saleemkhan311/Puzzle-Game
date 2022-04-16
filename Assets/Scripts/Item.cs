using UnityEngine;

public class Item : MonoBehaviour
{
    public delegate void DragEndedDalegate(Item dragAbles);

    public DragEndedDalegate dragEndedCallBack;

    private Sprite _sprite;

    private bool _isMoving;

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

    private void OnMouseDrag()
    {
        if (!_isMoving) return;
        var mousePos = Camera.main!.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(mousePos.x, mousePos.y);
    }

    private void OnMouseDown()
    {
        if (GameManager.Singleton.win == true) return;
        if (GameManager.Singleton.lose == true) return;
        _isMoving = true;
    }

    private void OnMouseUp()
    {
        _isMoving = false;
        if (newSpot == null) return;
        
        // dragEndedCallBack(this);
    }
}