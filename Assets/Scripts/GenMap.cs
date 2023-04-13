using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenMap : MonoBehaviour
{
    public List<GameObject> listRoad;
    public GameObject[] mapPrefabs;
    public GameObject mapParent;
    public float timeStart;
    public float timeEnd;

    public float Zpostion;

    void Start()
    {
        listRoad = new List<GameObject>();
        timeStart = Time.time;
        Zpostion = 0;
    }

    // Update is called once per frame
    void Update()
    {
        GenRoad(mapPrefabs[0]);
    }
    public void GenRoad(GameObject road)
    {
        if (Time.time - timeStart > 2f)
        {
            GameObject go = Instantiate(road, mapParent.transform);
            go.transform.localPosition = new Vector3(mapParent.transform.position.x, 0, Zpostion);
            go.transform.rotation = Quaternion.identity;
            listRoad.Add(go);
            Zpostion += 10;
            timeStart = Time.time;
        }
    }
}
