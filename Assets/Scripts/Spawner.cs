using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform spawnParent;
    [SerializeField] Transform slotsSpawnParent;
    [SerializeField] private GameObject itemSpotPrefab;
    [SerializeField] private GameObject itemPrefab;

    [SerializeField] private float initialX, initialY;
    [SerializeField] private float gapeX = 2f;
    [SerializeField] private float gapeY = 2.5f;

    private List<ItemSlot> _slots = new();


    private void Start()
    {
        // loading resources
        LoadLevel(1, 3, 6);
    }
    public void LoadLevel(int level, int row, int col)
    {
        for (var i = 0; i < row; i++)
        {
            for (var j = 0; j < col; j++)
            {
                var slot = Instantiate(itemSpotPrefab, slotsSpawnParent).GetComponent<ItemSlot>();
                var pos = new Vector3(initialX + j * gapeX, initialY + i * gapeY, 0f);
                /* Debug.Log(pos);*/
                slot.transform.localPosition = pos;
                _slots.Add(slot);
            }
        }

        var sprites = Resources.LoadAll($"Level{level}", typeof(Sprite));

        for (var i = 0; i < _slots.Count; i++)
        {
            var item = Instantiate(itemPrefab, spawnParent).GetComponent<Item>();
            if (item == null) return;
            item.Setup((Sprite) sprites[i % sprites.Length], _slots[i].transform);
            item.UpdateRenderer();
            // _slots[i].SetItem(item);
            item.name = $"item {i}";
            item.transform.position = _slots[i].transform.position;
        }
    }
}