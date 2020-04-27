using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    //to handle the singleton
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("too many Build manager");
            return;
        }
        instance = this;

    }

    public GameObject buildEffect;

    private TurretBlueprint turretToBuild;

    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.money >= turretToBuild.cost; } }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
    }

    public void BuildTurretOnNode(Node node)
    {
        if (PlayerStats.money < turretToBuild.cost)
        {
            Debug.Log("not enough money");
            return;
        }

        GameObject effect = Instantiate(buildEffect, node.GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);
        GameObject turret = Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.currentTurret = turret;
        PlayerStats.money -= turretToBuild.cost;
        Debug.Log("Turret build! money left " + PlayerStats.money);
    }
}
