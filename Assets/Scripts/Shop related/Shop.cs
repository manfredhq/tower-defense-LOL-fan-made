using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public ShopBlueprint[] shopTurret;
    public int nbTurret;
    public TurretBlueprint standartTurret;
    public TurretBlueprint missileLauncher;
    public TurretBlueprint laserBeamer;
    public TurretBlueprint jinx;
    public TurretBlueprint tristana;
    public TurretBlueprint viktor;
    BuildManager buildManager;

    private void Start()
    {
        //Roll();
        buildManager = BuildManager.instance;
    }

    void Roll()
    {
        //TODO: change the way it work, I'm busy and it's late
        for (int i = 0; i < nbTurret; i++)
        {
            int random = Random.Range(0, shopTurret.Length);
            GameObject obj = Instantiate(shopTurret[random].shopPrefab, transform);

        }

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
