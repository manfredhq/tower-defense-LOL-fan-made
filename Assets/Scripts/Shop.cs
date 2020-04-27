using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void purchaseStandartTurret()
    {
        Debug.Log("standart turret selected");
        buildManager.SetTurretToBuild(buildManager.standartTurretPrefab);
    }
    public void purchaseMissileTurret()
    {
        Debug.Log("another turret selected");
        buildManager.SetTurretToBuild(buildManager.missileTurretPrefab);
    }

}
