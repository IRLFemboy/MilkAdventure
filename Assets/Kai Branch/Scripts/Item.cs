using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item/Create")]
public class Item : ScriptableObject
{
    public int id; // When using the object/giving it to an NPC, the id is referenced to determine its use
    public string itemName; // What the item is called
    public Sprite icon; // What the item looks like
    public GameObject entity; // The object that gets dropped/picked up from the overworld
}
