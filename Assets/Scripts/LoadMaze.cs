using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class LoadMaze : MonoBehaviour
{
    public TextAsset jsonFile;
    public GameObject workspace;

    public UnityEngine.Object mazePrefab;
    public UnityEngine.Object startPrefab;
    public UnityEngine.Object endPrefab;
    public UnityEngine.Object fencePrefab;
    public UnityEngine.Object playerPrefab;

    private JSONData data = new JSONData();

    // Start is called before the first frame update
    void Start()
    {
        data = JsonUtility.FromJson<JSONData>(jsonFile.text);
        foreach (ObjectsBuilt obj in data.objects)
        {
            if (obj.prefabType == "maze")
            {
                Vector3 pos = new Vector3(obj.position.x/10.0f, obj.position.y/10.0f, obj.position.z/10.0f);
                Vector3 angles = new Vector3(obj.rotation.x, obj.rotation.y, obj.rotation.z);
                GameObject maze = (GameObject) Instantiate(mazePrefab, pos, Quaternion.Euler(angles));
                maze.transform.parent = workspace.transform;
            }
            else if (obj.prefabType == "fence")
            {
                Vector3 pos = new Vector3(obj.position.x/10.0f, obj.position.y/10.0f, obj.position.z/10.0f);
                Vector3 angles = new Vector3(obj.rotation.x, obj.rotation.y, obj.rotation.z);
                GameObject fence = (GameObject) Instantiate(fencePrefab, pos, Quaternion.Euler(angles));
                fence.transform.parent = workspace.transform;
            }
            else if (obj.prefabType == "start")
            {
                Vector3 pos = new Vector3(obj.position.x/10.0f, obj.position.y/10.0f, obj.position.z/10.0f);
                Vector3 angles = new Vector3(obj.rotation.x, obj.rotation.y, obj.rotation.z);
                GameObject start = (GameObject) Instantiate(startPrefab, pos, Quaternion.Euler(angles));
                start.transform.parent = workspace.transform;

                Vector3 startingPos = new Vector3(start.transform.position.x, 0.0f, start.transform.position.z);
                GameObject player = (GameObject) Instantiate(playerPrefab, startingPos, start.transform.rotation);
                player.transform.position += transform.TransformDirection(Vector3.forward * 0.15f);
                player.transform.parent = workspace.transform;
                for (int j = 0; j < player.transform.childCount; j++)
                {
                    player.transform.GetChild(j).gameObject.SetActive(false);
                }
            }
            else if (obj.prefabType == "end")
            {
                Vector3 pos = new Vector3(obj.position.x/10.0f, obj.position.y/10.0f, obj.position.z/10.0f);
                Vector3 angles = new Vector3(obj.rotation.x, obj.rotation.y, obj.rotation.z);
                GameObject end = (GameObject) Instantiate(endPrefab, pos, Quaternion.Euler(angles));
                end.transform.parent = workspace.transform;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

[System.Serializable]
public class JSONData{
    public List<ObjectsBuilt> objects = new List<ObjectsBuilt>();
}

[System.Serializable]
public class ObjectsBuilt
{
    public ObjectsBuilt(string name, Vector3 pos, Vector3 rot)
    {
        prefabType = name;
        position = new XYZ(pos);
        rotation = new XYZ(rot);
    }

    public string prefabType;
    public XYZ position;
    public XYZ rotation;
}

[System.Serializable]
public class XYZ
{
    public XYZ(Vector3 vect)
    {
        x = vect.x;
        y = vect.y;
        z = vect.z;
    }

    public float x;
    public float y;
    public float z;
}