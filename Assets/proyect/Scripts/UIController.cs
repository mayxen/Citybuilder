using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
    City city;
    [SerializeField]
    Text cityText;
    [SerializeField]
    Text dayText;
    // Use this for initialization
    void Start () {
        city = GetComponent<City>();
        UpdateCityData();
        UpdateDayCount();
    }
	
	public void UpdateDayCount()
    {
        dayText.text =string.Format("Day {0}", city.Day);
    }

    public void UpdateCityData()
    {
        cityText.text = string.Format("Jobs: {0}/{1}\nCash: {2}$ (+{6}$)\nPopulation:{3}/{4} (+{7})\nFood:{5}", city.JobsCurrent, city.JobsCeiling, (int)city.Cash, (int)city.PopulationCurrent, city.PopulationCeiling, (int)city.Food,city.CashNextTurn,(int)city.PopulationNextTurn);
    }
}
