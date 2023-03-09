using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPCTalkingToPlayer : MonoBehaviour
{
    //delay for NPC speaking
    public int timeSpeaking;

    //NPC lines
    public string questItems;
    public string whatToSayWhenTheyGetItems;

    //text bubble
    public TextMeshProUGUI textBubble;
    public GameObject enableTextBubble;

    //NPC
    public GameObject NPC;


    // Start is called before the first frame update
    void Start()
    {
        enableTextBubble.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //First interaction
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //check if collision was player
        if(collision.gameObject.CompareTag("Player"))
        {
            //Move the text bubble to the NPC
            enableTextBubble.transform.position = Camera.main.WorldToScreenPoint(NPC.transform.position);

            //enable textBubble
            enableTextBubble.SetActive(true);


            //NPC says what they want
            textBubble.text = questItems;

            //leave text bubble
            StartCoroutine(speakDelay());
        }
    }

    IEnumerator speakDelay()
    {
        yield return new WaitForSeconds(timeSpeaking);
        enableTextBubble.SetActive(false);
    }
}
