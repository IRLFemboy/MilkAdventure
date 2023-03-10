using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDex : MonoBehaviour
{
    // Variables

    public static ItemDex Instance;
    public GameObject player;
    public PlayerController playerCon;
    
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        player = GameObject.FindGameObjectWithTag("Player");
        playerCon = player.GetComponent<PlayerController>();
    }

    // ALL CODE for ALL THE ITEMS will go in the method below.
    public void UseItem(int id)
    {
        // Label the item being used right above the if statement checking for its ID.
        // If it's a one-time thing (for some reason) make sure to ItemManager.Instance.RemoveItem(playerCon.selectedItem);
        // If it's a quest item, do NOT give it an Id of 0.
        if (id == 0)
        {

        }
        // Ex: Moldy Bred
        if (id == 30323331)
        {
            Debug.Log("Bro, you can't eat that, that's too sus!");
            ItemManager.Instance.RemoveItem(playerCon.selectedItem);
        }
    }
}
