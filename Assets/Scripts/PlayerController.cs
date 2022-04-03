using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameObject player;
    public Vector3 playerInitPos;
    public Quaternion playerInitRot;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnStartButtonPress()
    {
        for (int j = 0; j < player.transform.childCount; j++)
        {
            player.transform.GetChild(j).gameObject.SetActive(true);
        }
        playerInitPos = player.transform.position;
        playerInitRot = player.transform.rotation;
    }
}
