using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{

    public TurretBlueprint standartTurret;
    public TurretBlueprint missileLauncher;
    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void SelectStandartTurret()
    {
        Debug.Log("standart turret selected");
        buildManager.SelectTurretToBuild(standartTurret);
    }
    public void SelectMissileTurret()
    {
        Debug.Log("another turret selected");
        buildManager.SelectTurretToBuild(missileLauncher);
    }

}
