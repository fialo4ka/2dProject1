using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CloudGeneration : MonoBehaviour
{
    public GameObject cloudLeft, cloudRight, cloudMidle, cloudNull;
    private List<GameObject> clouds;
    private GameObject dieSpace, kity;
    private int mapLength;
    public int secondLine = 8;

    void Start()
    {
        dieSpace = GameObject.Find("DieSpace");
        kity = GameObject.Find("kity");
        mapLength = (int)(dieSpace.transform.localScale.x - 30) / 2;
        kity.transform.position = new Vector3(-mapLength, 2, 0);
        clouds = new List<GameObject> { cloudNull, cloudLeft, cloudMidle, cloudRight };
        GenerateCloud();
    }

    private void GenerateCloud()
    {
        var previosObjectIndex = 1;
        Instantiate(clouds[previosObjectIndex], new Vector3(-mapLength - 3, 0, 0), Quaternion.identity);
        GenerateCloudLine(previosObjectIndex, 0);
        GenerateCloudLine(0, secondLine);
    }

    private void GenerateCloudLine(int previosObjectIndex, int yCoord)
    {
        for (int i = -mapLength; i < mapLength; i += 3)
        {
            previosObjectIndex = SetNextObject(previosObjectIndex, i, yCoord);
        }
    }

    private int SetNextObject(int previosObjectIndex, int xCoord, int yCoord)
    {
        var bjectIndex = GetNextObjectIndex(previosObjectIndex);
        Instantiate(clouds[bjectIndex], new Vector3(xCoord, yCoord, 0), Quaternion.identity);
        return bjectIndex;
    }

    private int GetNextObjectIndex(int previosObjectIndex)
    {
        switch (previosObjectIndex)
        {
            case 0:
                return Random.Range(0, 2);
            case 1:
                return 2;
            case 2:
                return 3;
            case 3:
                return Random.Range(0, 2);
        }
        return 0;
    }
}
