using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TurretUI : MonoBehaviour
{

    public GameObject ui;

    public TMP_Text upgradeCost;
    public Button upgradeButton;

    public TMP_Text sellGain;

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

        sellGain.text = target.turretBlueprint.GetSellAmount() + "$";

        ui.SetActive(true);
    }

    public void Hide()
    {
        ui.SetActive(false);
    }

    public void Upgrade()
    {
        target.UpgradeTurret();
        BuildManager.instance.DeselectNode();
    }

    public void Sell()
    {
        target.SellTurret();
        BuildManager.instance.DeselectNode();
    }
}
