using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TurretUI : MonoBehaviour
{

    public GameObject ui;

    public TMP_Text upgradeCost;
    public Button upgradeButton;

    private Node target;



    public void SetTarget(Node _target)
    {
        target = _target;

        transform.position = target.GetBuildPosition();

        if (!target.isUpgraded)
        {
            upgradeCost.text = target.turretBlueprint.upgradeCost + "$";
            upgradeButton.interactable = true;
        }
        else
        {
            upgradeButton.interactable = false;
            upgradeCost.text = "MAX";
        }



        ui.SetActive(true);
    }

    public void Hide()
    {
        ui.SetActive(false);
    }

    public void Upgrade()
    {
        Debug.Log("upgrade button clicked");
        target.UpgradeTurret();
        BuildManager.instance.DeselectNode();
    }
}
