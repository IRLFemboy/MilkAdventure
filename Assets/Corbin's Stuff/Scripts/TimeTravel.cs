using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeTravel : MonoBehaviour
{
    public GameObject future;
    public GameObject past;
    public GameObject current;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.P) && !past.activeSelf && !future.activeSelf)
        {
            past.SetActive(true);
            current.SetActive(false);
            StartCoroutine(SwitchToCurrentTime());
        }
        if(Input.GetKeyDown(KeyCode.F) && !past.activeSelf && !future.activeSelf)
        {
            future.SetActive(true);
            current.SetActive(false);
            StartCoroutine(SwitchToCurrentTime());
        }


    }

    IEnumerator SwitchToCurrentTime()
    {
        yield return new WaitForSeconds(5);
        if(past.activeSelf)
        {
            past.SetActive(false);
            current.SetActive(true);
        }
        if(future.activeSelf)
        {
            current.SetActive(true);
            future.SetActive(false);
        }
    }
}
