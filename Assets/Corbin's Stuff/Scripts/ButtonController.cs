using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    [Header("What it do")]
    public bool ItemSpawner;
    public bool DoorOpener;

    [Header("Item to spawn or door to open")]
    public GameObject spawnItem;
    public GameObject door;

    [Header("Door specific stuff")]
    public Animator doorAnim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(Input.GetKeyDown(KeyCode.F) && collision.gameObject.CompareTag("Player") && ItemSpawner)
        {
            
            spawnItem.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.F) && collision.gameObject.CompareTag("Player") && DoorOpener)
        {
            OpenDoor();
        }
    }

    void OpenDoor()
    {
        BoxCollider2D doorCollider = door.GetComponent<BoxCollider2D>();
        doorCollider.enabled = false;
        doorAnim.SetBool("openDoor", true);
    }
}
