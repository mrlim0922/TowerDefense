using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Node : MonoBehaviour {

    public Color hoverColor;
    public Color notEnoughMoneyColor;
    public Vector3 positionOffset;

    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TurretBluePrint turretBlueprint;
    [HideInInspector]
    public bool isUpgraded = false;

    private Color startColor;
    private Renderer rend;
    BuildManager buildManager;
   
    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;  
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }
   
    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;     

        if (turret != null)
        {
            buildManager.SelectNode(this);
            return;
        }
        if (!buildManager.CanBuild)
            return;

        BuildTurret(buildManager.GetTurretToBuild());
    }
    void BuildTurret(TurretBluePrint blueprint)
    {
        if (PlayerStats.Money < blueprint.upgradeCost)
        {
            Debug.Log(" Not enough money ");
            return;
        }
        PlayerStats.Money -= blueprint.cost;

        GameObject _turret = (GameObject)Instantiate(blueprint.prefab,
           transform.position /*+ node.GetBuildPosition()*/,
            Quaternion.identity);
        turret = _turret;

        turretBlueprint = blueprint;


        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect,
            transform.position, Quaternion.identity);
        Destroy(effect, 5f);

        Debug.Log("Money left " + PlayerStats.Money);

    }
    public void UpgradeTurret()
    {
        if (PlayerStats.Money < turretBlueprint.upgradeCost)
        {
            Debug.Log(" Not enough money ");
            return;
        }
        PlayerStats.Money -= turretBlueprint.upgradeCost;


        Destroy(turret);


        GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradedPrefab,
           transform.position /*+ node.GetBuildPosition()*/,
            Quaternion.identity);
        turret = _turret;

        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect,
            transform.position, Quaternion.identity);
        Destroy(effect, 5f);

        isUpgraded = true;

        Debug.Log("Money left " + PlayerStats.Money);
    }

    public void SellTurret()
    {
        PlayerStats.Money += turretBlueprint.GetSellAmount();

        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect,
           transform.position, Quaternion.identity);
        Destroy(effect, 5f);



        Destroy(turret);
        turretBlueprint = null;
    }
    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;
        if (!buildManager.CanBuild) return;

        if (buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        }
        else
        {           
            rend.material.color = notEnoughMoneyColor;
        }        
    }
    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
