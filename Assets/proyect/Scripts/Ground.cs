using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour {
    Building[,] buildins = new Building[100, 100];//2D array
	
    public void AddBuilding(Building building,Vector3 pos)
    {
        buildins[(int)pos.x, (int)pos.z] = Instantiate(building,pos,Quaternion.identity);
    }

    public Building checkForBuilding(Vector3 pos)
    {
        return buildins[(int)pos.x, (int)pos.z];
    }

    public void RemoveBuilding(Vector3 pos)
    {
        Destroy(buildins[(int)pos.x, (int)pos.z].gameObject);
        buildins[(int)pos.x, (int)pos.z] = null;
    }

    public Vector3 CalculateGridPosition(Vector3 pos)
    {
        return new Vector3(Mathf.Round(pos.x), 0, Mathf.Round(pos.z));
    }
}
