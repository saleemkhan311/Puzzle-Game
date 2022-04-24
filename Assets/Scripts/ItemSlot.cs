using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour
{
    private Item _item;

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        if (eventData.pointerDrag == null) return;
        // swap the _item into slots..
        var item = eventData.pointerDrag.GetComponent<Item>();
        if (item == null) return;

        var slot = item.spot;
        _item.transform.position = slot.transform.position * Time.deltaTime;
    }

    public void SetItem(Item item)
    {
        _item = item;
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        
        var item = col.GetComponent<Item>();
        if (item == null) return;
        if (item == _item) return;
        var slot = item.spot;
        if(Input.GetMouseButtonUp(0))
        {
            
            
            item.newSpot = transform;
            _item.transform.position = slot.position;
            item.transform.Translate(slot.position);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        var item = other.GetComponent<Item>();
        if (item == null) return;
        if (item == _item) return;
        item.newSpot = null;
        _item.transform.position = transform.position;
    }
}