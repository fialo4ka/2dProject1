using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class CloudGeneration : MonoBehaviour
{
    public GameObject cloudLeft, cloudRight, cloudMidle, cloudNull;
    private List<GameObject> clouds;
    private GameObject dieSpace, kity;
    public int dieSpaceLength = 600;
    private int mapLength;
    public int lineCount = 3;
    private int lineMove = 10;
    private List<MapCoordinates> cloudsMap;

    void Start()
    {
        dieSpace = GameObject.Find("DieSpace");
        kity = GameObject.Find("kity");
        mapLength = (int)(dieSpaceLength - 30) / 2;
        kity.transform.position = new Vector3(-mapLength, 2, 0);
        dieSpace.transform.position = new Vector3(0, -(lineCount * lineMove + 10), 0);
        dieSpace.transform.localScale = new Vector3(dieSpaceLength, 1, 1);
        cloudsMap = new List<MapCoordinates> { new MapCoordinates(-mapLength - 3, 0, 1) };
        clouds = new List<GameObject> { cloudNull, cloudLeft, cloudMidle, cloudRight };
        GenerateCloud();
    }

    private void GenerateCloud()
    {
        Debug.Log($"1. {cloudsMap[0].X} {cloudsMap[0].Y}");
        Instantiate(clouds[cloudsMap[0].ObjectId], new Vector3(cloudsMap[0].X, cloudsMap[0].Y, 0), Quaternion.identity);
        GenerateCloudLine();
    }

    private void GenerateCloudLine()
    {
        for (int i = -mapLength; i < mapLength; i += 3)
        {
            for (int j = 0; j > (-lineCount * lineMove); j -= lineMove)
            {
                Debug.Log($"{i}:{j}:");
                SetNextObject(i, j);
            }
        }
    }

    private void SetNextObject(int xCoord, int yCoord)
    {
        Debug.Log($"obj = {xCoord - 3}x{yCoord}");

        var id = cloudsMap.FirstOrDefault(cloud => cloud.X == xCoord - 3 && cloud.Y == yCoord);
        if (id == null)
        {
            Debug.LogError($"previosObjectIndex == null {xCoord} {yCoord}");
        }
        else
        {
            Debug.Log($"obj = {id.X}x{id.Y} : {id.ObjectId}");
        }
        var newObject = GetNextObjectIndex(
            cloudsMap.FirstOrDefault(cloud => cloud.X == xCoord - 3 && cloud.Y == yCoord)?.ObjectId
            );
        cloudsMap.Add(new MapCoordinates(xCoord, yCoord, newObject));
        Instantiate(clouds[newObject], new Vector3(xCoord, yCoord, 0), Quaternion.identity);
    }

    private int GetNextObjectIndex(int? previosObjectIndex)
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
            default:
                break;
        }
        return 0;
    }
}


class MapCoordinates
{
    public int X { get; set; }
    public int Y { get; set; }
    public int ObjectId { get; set; }

    public MapCoordinates(int x, int y, int objectId)
    {
        X = x;
        Y = y;
        ObjectId = objectId;
    }
}