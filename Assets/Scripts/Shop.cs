﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{

    public TurretBlueprint standartTurret;
    public TurretBlueprint missileLauncher;
    public TurretBlueprint laserBeamer;
    public TurretBlueprint jinx;
    public TurretBlueprint tristana;
    public TurretBlueprint viktor;
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
        Debug.Log("Missile turret selected");
        buildManager.SelectTurretToBuild(missileLauncher);
    }

    public void SelectLaserBeamer()
    {
        Debug.Log("Laser turret selected");
        buildManager.SelectTurretToBuild(laserBeamer);
    }

    public void SelectJinx()
    {
        Debug.Log("Jinx turret selected");
        buildManager.SelectTurretToBuild(jinx);
    }

    public void SelectTristana()
    {
        Debug.Log("Tristana turret selected");
        buildManager.SelectTurretToBuild(tristana);
    }

    public void SelectViktor()
    {
        Debug.Log("Viktor turret selected");
        buildManager.SelectTurretToBuild(viktor);
    }



}
