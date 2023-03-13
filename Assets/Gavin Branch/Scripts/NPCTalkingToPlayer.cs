using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPCTalkingToPlayer : MonoBehaviour
{
    //delay for NPC speaking
    public int timeSpeaking;

    //NPC lines
    public int questItemID;
    public string AskForItems;
    public string WhenTheyGetItems;
    private bool hasTalkedBefore;


    //text bubble
    public TextMeshProUGUI textBubble;
    public GameObject enableTextBubble;

    //NPC
    public GameObject NPC;


    //player
    private int PlayerItemID;
    private GameObject Player;


    // Start is called before the first frame update
    void Start()
    {
        enableTextBubble.SetActive(false);


        //find the player
        Player = GameObject.Find("Father");

    }

    // Update is called once per frame
    void Update()
    {

    }


    //First interaction
    private void OnCollisionEnter2D(Collision2D collision)
    {

        //check if player is holding an item
        if (Player.gameObject.GetComponent<PlayerController>().selectedItem != null)
        {
            //get the id of the held item
            PlayerItemID = Player.gameObject.GetComponent<PlayerController>().selectedItem.id;
        }


        //check if collision was player
        if (collision.gameObject.CompareTag("Player"))
        {
            
            //check if player has the item the NPC they want and they have talked to NPC before
            if (PlayerItemID == questItemID && hasTalkedBefore)
            {
                OnGetItem();
            }
            else
            {
                AskForItem();
            }
        }
       



    }

    IEnumerator speakDelay()
    {
        yield return new WaitForSeconds(timeSpeaking);
        enableTextBubble.SetActive(false);
    }

    public void OnGetItem()
    {
        ItemManager.Instance.RemoveItem(Player.gameObject.GetComponent<PlayerController>().selectedItem);

        //enable textBubble
        enableTextBubble.SetActive(true);


        //NPC says line after getting items
        textBubble.text = WhenTheyGetItems;

        //wait then destroy NPC
        Destroy(gameObject, 4f);
    }

    public void AskForItem()
    {
        //player has talked to NPC
        hasTalkedBefore = true;

        //Move the text bubble to the NPC
        enableTextBubble.transform.position = Camera.main.WorldToScreenPoint(NPC.transform.position);

        //enable textBubble
        enableTextBubble.SetActive(true);


        //NPC says what they want
        textBubble.text = AskForItems;

        //leave text bubble
        StartCoroutine(speakDelay());
    }

}
