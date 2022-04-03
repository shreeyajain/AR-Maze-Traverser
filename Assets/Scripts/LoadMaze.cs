using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class LoadMaze : MonoBehaviour
{
    public TextAsset jsonFile;

    public UnityEngine.Object mazePrefab;
    public UnityEngine.Object startPrefab;
    public UnityEngine.Object endPrefab;
    public UnityEngine.Object fencePrefab;

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
                Instantiate(mazePrefab, pos, Quaternion.Euler(angles));
            }
            else if (obj.prefabType == "fence")
            {
                Vector3 pos = new Vector3(obj.position.x/10.0f, obj.position.y/10.0f, obj.position.z/10.0f);
                Vector3 angles = new Vector3(obj.rotation.x, obj.rotation.y, obj.rotation.z);
                Instantiate(fencePrefab, pos, Quaternion.Euler(angles));
            }
            else if (obj.prefabType == "start")
            {
                Vector3 pos = new Vector3(obj.position.x/10.0f, obj.position.y/10.0f, obj.position.z/10.0f);
                Vector3 angles = new Vector3(obj.rotation.x, obj.rotation.y, obj.rotation.z);
                Instantiate(startPrefab, pos, Quaternion.Euler(angles));
            }
            else if (obj.prefabType == "end")
            {
                Vector3 pos = new Vector3(obj.position.x/10.0f, obj.position.y/10.0f, obj.position.z/10.0f);
                Vector3 angles = new Vector3(obj.rotation.x, obj.rotation.y, obj.rotation.z);
                Instantiate(endPrefab, pos, Quaternion.Euler(angles));
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