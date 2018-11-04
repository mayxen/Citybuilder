using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingController : MonoBehaviour {

    City city;
    Ground ground;
    UIController uiController;
    [SerializeField]
    Building[] buildings;
    Building selectedBuilding;
	// Use this for initialization
	void Start () {
        ground = GetComponent<Ground>();
        city = GetComponent<City>();
        uiController = GetComponent<UIController>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && Input.GetKey(KeyCode.LeftShift) && selectedBuilding != null)
        {
            InteractWithGround(0);
        }
        else if (Input.GetMouseButtonDown(0) && selectedBuilding != null)
        {
            InteractWithGround(0);
        }
        else if (Input.GetMouseButtonDown(1))
        {
            InteractWithGround(1);
        }
    }

    void InteractWithGround(int action)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray,out hit))//pillo si se ha pulsado y con out se hace referencias a la posicion del objeto no una copia del objeto
        {
            Vector3 gridPos = ground.CalculateGridPosition(hit.point);//transformo esa posicion a una que pueda utilizar
            if (!UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
            {
                if (ground.checkForBuilding(gridPos) == null && action == 0)//compruebo si está cogido esa posicion
                {
                    if (city.Cash >= selectedBuilding.cost)//si puedo pagar la casa
                    {
                        city.DepositCash(-selectedBuilding.cost);
                        uiController.UpdateCityData();
                        city.buildingCounts[selectedBuilding.id]++;
                        ground.AddBuilding(selectedBuilding, gridPos);
                    }
                }
                else if(ground.checkForBuilding(gridPos) != null && action == 1)
                {
                    city.DepositCash(ground.checkForBuilding(gridPos).cost);
                    city.buildingCounts[ground.checkForBuilding(gridPos).id]--;
                    ground.RemoveBuilding(gridPos);
                    uiController.UpdateCityData();
                    
                }
            }
            
        }
    }

    public void EnableBuilder(int building)
    {
        selectedBuilding= buildings[building];
        
    }


}
