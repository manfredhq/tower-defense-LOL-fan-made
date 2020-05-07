using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color alarmingColor;
    public Vector3 positionOffset;

    [HideInInspector]
    public GameObject currentTurret;
    [HideInInspector]
    public TurretBlueprint turretBlueprint;
    [HideInInspector]
    public bool isUpgraded = false;

    private Renderer rend;
    private Color baseColor;

    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
        rend = GetComponent<Renderer>();
        baseColor = rend.material.color;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (currentTurret != null)
        {
            buildManager.SelectNode(this);
            return;
        }

        if (!buildManager.CanBuild)
        {
            return;
        }


        BuildTurret(buildManager.GetTurretToBuild(), buildManager.GetChampShop());
    }

    public void UpgradeTurret()
    {
        if (PlayerStats.money < turretBlueprint.upgradeCost)
        {
            Debug.Log("not enough money to upgrade");
            return;
        }

        //Remove old turret
        Destroy(currentTurret);

        //Building the upgraded one
        GameObject effect = Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);
        GameObject _turret = Instantiate(turretBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
        currentTurret = _turret;
        PlayerStats.money -= turretBlueprint.upgradeCost;

        isUpgraded = true;

        Debug.Log("Turret upgraded");
    }
    public void SellTurret()
    {
        PlayerStats.money += turretBlueprint.GetSellAmount();

        //Play an effect
        GameObject effect = Instantiate(buildManager.sellEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        Destroy(currentTurret);
        turretBlueprint = null;
    }

    private void BuildTurret(TurretBlueprint blueprint, ChampShop champShop)
    {
        if (PlayerStats.money < blueprint.cost)
        {
            Debug.Log("not enough money");
            return;
        }

        champShop.GetGameObject().GetComponent<Button>().interactable = false;
        buildManager.TurretBuild();

        turretBlueprint = blueprint;

        GameObject effect = Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);
        GameObject _turret = Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        currentTurret = _turret;
        PlayerStats.money -= blueprint.cost;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }
    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (!buildManager.CanBuild)
        {
            return;
        }
        if (buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = alarmingColor;
        }

    }

    private void OnMouseExit()
    {
        rend.material.color = baseColor;
    }

}
