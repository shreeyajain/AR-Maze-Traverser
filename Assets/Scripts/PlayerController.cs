using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private GameObject player;
    private Vector3 playerInitPos;
    private Quaternion playerInitRot;

    private bool started;
    private GameObject canvas;

    public Text timeText;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        started = false;
        timer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        Touch touch = new Touch();
        Vector3 touchPosition;

        if (started)
        {
            // Keep track of the timer
            IncreaseTimer();
            int seconds = (int)Math.Round(timer, 0);
            if (seconds%60 < 10)
                timeText.text = "Time " + seconds/60 + ":0" + seconds%60;
            else
                timeText.text = "Time " + seconds/60 + ":" + seconds%60;

            if (Input.touchCount > 0)
            {
                touch = Input.GetTouch(0);
                touchPosition = touch.position;

                if (touch.phase == TouchPhase.Began)
                {
                    Debug.Log("Touch detected");
                    Ray ray = Camera.current.ScreenPointToRay(touchPosition);
                    RaycastHit hit;

                    if (Physics.Raycast(ray, out hit))
                    {
                        if (hit.transform.gameObject.CompareTag("Player"))
                        {
                            Debug.Log("Player object was touched");
                            Vector3 cameraForward = Camera.current.transform.forward;
                            player.transform.eulerAngles = new Vector3(0.0f, Camera.current.transform.eulerAngles.y, 0.0f);
                            player.GetComponent<Rigidbody>().AddForce(cameraForward * 100.0f);
                        }
                        else if (hit.transform.gameObject.CompareTag("end"))
                        {
                            started = false;
                            // Set canvas active again but do not show any of the previous UI buttons
                            canvas.SetActive(true);
                            canvas.transform.GetChild(0).gameObject.SetActive(false);
                            canvas.transform.GetChild(1).gameObject.SetActive(false);
                            canvas.transform.GetChild(2).gameObject.SetActive(false);
                            canvas.transform.GetChild(3).gameObject.SetActive(false);
                            canvas.transform.GetChild(4).gameObject.SetActive(true);
                            canvas.transform.GetChild(5).gameObject.SetActive(true);
                        }
                    }
                } 
            }
        }        
    }

    public void OnStartButtonPress()
    {
        Debug.Log("Start button pressed");
        for (int j = 0; j < player.transform.childCount; j++)
        {
            player.transform.GetChild(j).gameObject.SetActive(true);
        }
        playerInitPos = player.transform.position;
        playerInitRot = player.transform.rotation;

        started = true;
        canvas = GameObject.Find("Canvas");
        canvas.transform.GetChild(0).gameObject.SetActive(false);
        canvas.transform.GetChild(1).gameObject.SetActive(false);
        canvas.transform.GetChild(2).gameObject.SetActive(false);
        canvas.transform.GetChild(3).gameObject.SetActive(false);
        canvas.transform.GetChild(4).gameObject.SetActive(false);
        canvas.transform.GetChild(5).gameObject.SetActive(true);
    }

    public void OnReloadButtonPress()
    {
        Debug.Log("Reload button pressed");
        StartCoroutine(LoadLevel(0));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(levelIndex);
    }

    public void OnRestartButtonPress()
    {
        Debug.Log("Restart button pressed");
        player.transform.position = playerInitPos;
        player.transform.rotation = playerInitRot;

        started = true;
        timer = 0.0f;
        canvas.transform.GetChild(4).gameObject.SetActive(false);
    }

    // Custom function to increase game time
    public void IncreaseTimer()
    {
        timer += Time.deltaTime;
    }
}
