using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour
{
    public Material Material1;
    public Material Material2;
    public Material Material3;

    public Material mazeMat;
    public Material startMat;
    public Material endMat1;
    public Material endMat2;
    public Material endMat3;
    public Material fenceMat;
    public Material floorMat;

    private GameObject[] mazeBlocks;
    private GameObject[] fences;
    private GameObject start;
    private GameObject end;
    private GameObject floor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMaterial1ButtonPress()
    {
        mazeBlocks = GameObject.FindGameObjectsWithTag("maze");
        fences = GameObject.FindGameObjectsWithTag("fence");
        start = GameObject.FindWithTag("start");
        end = GameObject.FindWithTag("end");
        floor = GameObject.FindWithTag("floor");

        foreach (GameObject maze in mazeBlocks)
        {
            maze.GetComponent<Renderer>().material = Material1;
        }

        foreach (GameObject fence in fences)
        {
            for (int j = 0; j < fence.transform.childCount; j++)
            {
                fence.transform.GetChild(j).GetComponent<Renderer>().material = Material1;
            }
        }

        for (int j = 0; j < start.transform.childCount; j++)
        {
            start.transform.GetChild(j).GetComponent<Renderer>().material = Material1;
        }

        for (int j = 0; j < end.transform.childCount; j++)
        {
            end.transform.GetChild(j).GetComponent<Renderer>().material = Material1;
        }

        floor.GetComponent<Renderer>().material = Material1;
    }

    public void OnMaterial2ButtonPress()
    {
        mazeBlocks = GameObject.FindGameObjectsWithTag("maze");
        fences = GameObject.FindGameObjectsWithTag("fence");
        start = GameObject.FindWithTag("start");
        end = GameObject.FindWithTag("end");
        floor = GameObject.FindWithTag("floor");

        foreach (GameObject maze in mazeBlocks)
        {
            maze.GetComponent<Renderer>().material = Material2;
        }

        foreach (GameObject fence in fences)
        {
            for (int j = 0; j < fence.transform.childCount; j++)
            {
                fence.transform.GetChild(j).GetComponent<Renderer>().material = Material2;
            }
        }

        for (int j = 0; j < start.transform.childCount; j++)
        {
            start.transform.GetChild(j).GetComponent<Renderer>().material = Material2;
        }

        for (int j = 0; j < end.transform.childCount; j++)
        {
            end.transform.GetChild(j).GetComponent<Renderer>().material = Material2;
        }

        floor.GetComponent<Renderer>().material = Material2;
    }

    public void OnMaterial3ButtonPress()
    {
        mazeBlocks = GameObject.FindGameObjectsWithTag("maze");
        fences = GameObject.FindGameObjectsWithTag("fence");
        start = GameObject.FindWithTag("start");
        end = GameObject.FindWithTag("end");
        floor = GameObject.FindWithTag("floor");

        foreach (GameObject maze in mazeBlocks)
        {
            maze.GetComponent<Renderer>().material = Material3;
        }

        foreach (GameObject fence in fences)
        {
            for (int j = 0; j < fence.transform.childCount; j++)
            {
                fence.transform.GetChild(j).GetComponent<Renderer>().material = Material3;
            }
        }

        for (int j = 0; j < start.transform.childCount; j++)
        {
            start.transform.GetChild(j).GetComponent<Renderer>().material = Material3;
        }

        for (int j = 0; j < end.transform.childCount; j++)
        {
            end.transform.GetChild(j).GetComponent<Renderer>().material = Material3;
        }

        floor.GetComponent<Renderer>().material = Material3;
    }

    public void OnMaterial4ButtonPress()
    {
        mazeBlocks = GameObject.FindGameObjectsWithTag("maze");
        fences = GameObject.FindGameObjectsWithTag("fence");
        start = GameObject.FindWithTag("start");
        end = GameObject.FindWithTag("end");
        floor = GameObject.FindWithTag("floor");

        foreach (GameObject maze in mazeBlocks)
        {
            maze.GetComponent<Renderer>().material = mazeMat;
        }

        foreach (GameObject fence in fences)
        {
            for (int j = 0; j < fence.transform.childCount; j++)
            {
                fence.transform.GetChild(j).GetComponent<Renderer>().material = fenceMat;
            }
        }

        for (int j = 0; j < start.transform.childCount; j++)
        {
            start.transform.GetChild(j).GetComponent<Renderer>().material = startMat;
        }

        end.transform.GetChild(0).GetComponent<Renderer>().material = endMat1;
        for (int j = 1; j < 3; j++)
        {
            end.transform.GetChild(j).GetComponent<Renderer>().material = endMat2;
        }
        for (int j = 3; j < end.transform.childCount; j++)
        {
            end.transform.GetChild(j).GetComponent<Renderer>().material = endMat3;
        }

        floor.GetComponent<Renderer>().material = floorMat;
    }
}
