using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class City : MonoBehaviour {
    
    public int Cash { get; set; }
    public int CashNextTurn { get; set; }
    public int Day { get; set; }
    public float Food { get; set; }
    public float PopulationCurrent { get; set; }
    public float PopulationNextTurn { get; set; }
    public float PopulationCeiling { get; set; }
    public float JobsCurrent { get; set; }
    public float JobsCeiling { get; set; }
    public int[] buildingCounts = new int [4];

    UIController uIController;
    // Use this for initialization
    void Start () {
        Cash = 100000;
        CashNextTurn = 0;
        Day = 0;
        Food = 5;
        PopulationCeiling = 0;
        PopulationNextTurn = 0;
        PopulationCurrent = 0;
        JobsCeiling = 0;
        JobsCurrent = 0; 
        uIController = GetComponent<UIController>();
       

    }

    public void EndTurn()
    {
        Day++;
        CalculateCash();
        CalculatePopulation();
        CalculateJobs();
        CalculateFood();
        uIController.UpdateCityData();
        uIController.UpdateDayCount();
        
    }
    void CalculateJobs()
    {
        JobsCeiling = buildingCounts[3] * 10; //por cada fabrica 10 
        JobsCurrent = Mathf.Min((int)PopulationCurrent ,JobsCeiling); //coge el minimo de los 2

    }
    public void DepositCash(int deposit)
    {
        Cash += deposit;
    }
    void CalculateCash()
    {
        int aux = Cash;
        Cash += (int)JobsCurrent * 2;
        CashNextTurn = Cash-aux;
        
    }

    void CalculateFood()
    {
        Food += buildingCounts[2] * 4f;
    }

    void CalculatePopulation()
    {
        float aux = PopulationCurrent;
        PopulationCeiling = buildingCounts[1] * 5;
        if(Food >= PopulationCurrent && PopulationCurrent < PopulationCeiling)
        {
            Food -= PopulationCurrent *.5f;//cada 0.5 food alimenta a 1 
            PopulationCurrent = Mathf.Min(PopulationCurrent += Food * .5f,PopulationCeiling);
        }
        else if (Food < PopulationCurrent)
        {
            PopulationCurrent -= (PopulationCurrent - Food)*.5f;
        }
        PopulationNextTurn = (PopulationCurrent-aux);
    }
}
