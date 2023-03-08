using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountDown : MonoBehaviour
{
    private TextMeshProUGUI CountDownText;
    private float timeLeft;
    public float timeLeftRounded;
    public int maxTime;
    // Start is called before the first frame update
    void Start()
    {
        //get the textmeshpro
        CountDownText = gameObject.GetComponent<TextMeshProUGUI>();


        //set timeleft to eqaul maxTime
        timeLeft = maxTime;
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;

        //round to two decimals
        timeLeftRounded = Mathf.Round(timeLeft * 100) * .01f;
        CountDownText.text = "Time Left: " + timeLeftRounded;
    }
}
