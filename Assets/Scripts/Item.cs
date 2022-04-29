using UnityEngine;

public class Item : MonoBehaviour
{

    private Sprite _sprite;
    public Transform spot;
    
    public void Setup(Sprite sprite, Transform spotTransform)
    {
        _sprite = sprite;
        spot = spotTransform;
    }

    public void UpdateRenderer()
    {
        GetComponent<SpriteRenderer>().sprite = _sprite;
    }

    public void Rest()
    {
        transform.position = spot.position;
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if(Swapper.Singleton.selectedItem == null) return;
        if (string.Equals(Swapper.Singleton.selectedItem.name, col.name)) return;
        Debug.Log($"On Trigger Enter {col.name}");
        if(Input.GetMouseButtonUp(0))
            Swapper.Singleton.swapItem = col.GetComponent<Item>();
    }


   
}