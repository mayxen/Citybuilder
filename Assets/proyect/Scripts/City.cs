using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class City : MonoBehaviour {
    
    public int Cash { get; set; }
    public int Day { get; set; }
    public float Food { get; set; }
    public float PopulationCurrent { get; set; }
    public float PopulationCeiling { get; set; }
    public float JobsCurrent { get; set; }
    public float JobsCeiling { get; set; }

    public int[] buildingCounts = new int [3];
    // Use this for initialization
    void Start () {
        Cash = 10000;
        Food = 5;
        JobsCeiling = 10;

	}

    public void EndTurn()
    {
        Day++;
        Debug.Log("heeey");
        CalculatePopulation();
        CalculateJobs();
        CalculateCash();
        CalculateFood();
        Debug.LogFormat("Jobs: {0}/{1},Cash: {2},pop:{3}/{4},Food:{5}",JobsCurrent,JobsCeiling,Cash,PopulationCurrent,PopulationCeiling,Food);
        
    }
    void CalculateJobs()
    {
        JobsCeiling = buildingCounts[2] * 10; //por cada fabrica 10 
        JobsCurrent = Mathf.Min((int)PopulationCurrent ,JobsCeiling); //coge el minimo de los 2

    }

    void CalculateCash()
    {
        Cash += (int)JobsCurrent * 2;
    }

    void CalculateFood()
    {
        Food += buildingCounts[1] * 4f;
    }

    void CalculatePopulation()
    {
        PopulationCeiling = buildingCounts[0] * 5;
        if(Food >= PopulationCurrent && PopulationCurrent < PopulationCeiling)
        {
            Food -= PopulationCurrent *.5f;//cada 0.5 food alimenta a 1 
            PopulationCurrent = Mathf.Min(PopulationCurrent += Food * .5f,PopulationCeiling);
        }
        else if (Food < PopulationCurrent)
        {
            PopulationCurrent -= (PopulationCurrent - Food)*.5f;
        }
    }
}
