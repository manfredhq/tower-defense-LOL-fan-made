using UnityEngine;

public class Shop : MonoBehaviour
{
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
        buildManager = BuildManager.instance;
    }

    public void SelectStandartTurret(ChampShop champShop)
    {
        Debug.Log("standart turret selected");
        buildManager.SelectTurretToBuild(standartTurret, champShop);
    }
    public void SelectMissileTurret(ChampShop champShop)
    {
        Debug.Log("Missile turret selected");
        buildManager.SelectTurretToBuild(missileLauncher, champShop);
    }

    public void SelectLaserBeamer(ChampShop champShop)
    {
        Debug.Log("Laser turret selected");
        buildManager.SelectTurretToBuild(laserBeamer, champShop);
    }

    public void SelectJinx(ChampShop champShop)
    {
        Debug.Log("Jinx turret selected");
        buildManager.SelectTurretToBuild(jinx, champShop);
    }

    public void SelectTristana(ChampShop champShop)
    {
        Debug.Log("Tristana turret selected");
        buildManager.SelectTurretToBuild(tristana, champShop);
    }

    public void SelectViktor(ChampShop champShop)
    {
        Debug.Log("Viktor turret selected");
        buildManager.SelectTurretToBuild(viktor, champShop);
    }



}
