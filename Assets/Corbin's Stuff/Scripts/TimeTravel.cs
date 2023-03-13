using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeTravel : MonoBehaviour
{
    public GameObject future;
    public GameObject past;
    public GameObject current;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.P) && !past.activeSelf)
        {
            past.SetActive(true);
            future.SetActive(false);
            current.SetActive(false);

        }

        if(Input.GetKeyDown(KeyCode.C) && !future.activeSelf)
        {
            future.SetActive(true);
            past.SetActive(false);
            current.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.G) && (future.activeSelf || past.activeSelf))
        {
            future.SetActive(false);
            past.SetActive(false);
            current.SetActive(true);
        }
    }
}
