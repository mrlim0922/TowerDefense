using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NodeUI : MonoBehaviour {

    public GameObject ui;
    
    public Text upgradeCost;
    public Text sellAmount;

    public Button upgradeButton;
    private Node target;
    public void setTarget (Node _target)
    {
        target = _target ;
        transform.position = target.GetBuildPosition();

        if(!target.isUpgraded)
        {
            upgradeCost.text = "$" + target.turretBlueprint.cost;
            upgradeButton.interactable = true;
        }
        else
        {
            upgradeCost.text = "Done";
            upgradeButton.interactable = true;
        }

        sellAmount.text = "$" + target.turretBlueprint.GetSellAmount();
        ui.SetActive(true);
    }
    public void Hide()
    {
        ui.SetActive(false);
    }

    public void Upgrade()
    {
        target.UpgradeTurret();
        BuildManager.instance.DeselecNode();
    }

    public void Sell()
    {
        target.SellTurret();
        BuildManager.instance.DeselecNode();
    }
}
