using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    // Variables

    public static ItemManager Instance;
    public List<Item> Items = new List<Item>();
    public Item heldItem;
    public float itemLimit = 7;

    public Transform ItemContent;
    public GameObject inventoryItem;
    public Sprite slot;
    public Sprite selectSlot;

    private void Awake()
    {
        Instance = this;
    }

    public void AddItem(Item item)
    {
        Items.Add(item);
        OpenInventory();
    }

    public void RemoveItem(Item item)
    {
        Items.Remove(item);
        OpenInventory();
    }

    public void OpenInventory()
    {
        bool itemSelected = false;
        foreach (Transform item in ItemContent)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in Items)
        {
            GameObject obj = Instantiate(inventoryItem, ItemContent);
            var itemName = obj.transform.Find("Item Name").GetComponent<TextMeshProUGUI>();
            var itemBorder = obj.transform.Find("Item Border").GetComponent<Image>();
            var itemIcon = obj.transform.Find("Item Icon").GetComponent<Image>();

            itemName.text = item.itemName;
            itemIcon.sprite = item.icon;
            itemBorder.sprite = slot;
            if (item == heldItem && !itemSelected)
            {
                itemBorder.sprite = selectSlot;
                itemSelected = true;
            }
        }
        itemSelected = false;
    }
}
