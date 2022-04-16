using UnityEngine;

public class Items : MonoBehaviour
{
    public delegate void DragEndedDalegate(Items dragAbles);

    public DragEndedDalegate dragEndedCallBack;
    public GameObject itemSlot;

    public bool isMoving;
    private float _startPosX;
    private float _startPosY;
    private float _score;
    private Vector2 _resetPos;
    private bool _isPositioned = false;
    private SpriteRenderer _sprite;

    private void Start()
    {
        _sprite = GetComponent<SpriteRenderer>();
        _resetPos = transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        var transform1 = transform;
        if (transform1.position.x > 7.5f)
        {
            transform1.position = new Vector2(7.5f, transform1.position.y);
        }
        else if (transform1.position.x < -4.2)
        {
            transform1.position = new Vector2(-4.2f, transform.position.y);
        }

        if (transform1.position.y > 3.0f)
        {
            transform1.position = new Vector2(transform.position.x, 3.0f);
        }
        else if (transform1.position.y < -3.5)
        {
            transform1.position = new Vector2(transform.position.x, -3.5f);
        }
    }

    private void OnMouseDrag()
    {
        if (GameManager.singleton.win == true) return;
        if (GameManager.singleton.lose == true) return;
        if (!isMoving) return;
        if (_isPositioned) return;
        Vector3 mousePos;
        mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        transform.position = new Vector2(mousePos.x, mousePos.y);
    }

    private void OnMouseDown()
    {
        if (GameManager.singleton.win == true) return;
        if (GameManager.singleton.lose == true) return;
        var mousePos = Camera.main!.ScreenToWorldPoint(Input.mousePosition);


        isMoving = true;

        var color = _sprite.color;
        color = new Color(color.r, color.g, color.b, 0.5f);
        _sprite.color = color;
    }

    private void OnMouseUp()
    {
        if (GameManager.singleton.win == true) return;
        if (GameManager.singleton.lose == true) return;
        if (Mathf.Abs(transform.position.x - itemSlot.transform.position.x) <= 1.0f &&
            Mathf.Abs(transform.position.y - itemSlot.transform.position.y) <= 1.0f)
        {
            var position = itemSlot.transform.position;
            transform.position = new Vector2(position.x, position.y);
            if (transform.position == itemSlot.transform.position)
            {
                GameManager.singleton.scores++;
                _isPositioned = true;
                GetComponent<BoxCollider2D>().enabled = false;
                Debug.Log("Scores = " + _score);
            }
        }

        isMoving = false;

        var color = _sprite.color;
        color = new Color(color.r, color.g, color.b, 1);
        _sprite.color = color;
        dragEndedCallBack(this);
    }
}