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
    public TurretUI turretUI;

    public GameObject sellEffect;

    private TurretBlueprint turretToBuild;
    private Node selectedNode;
    private ChampShop champShop;

    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.money >= turretToBuild.cost; } }

    public void SelectTurretToBuild(TurretBlueprint turret, ChampShop champShopGiven)
    {
        turretToBuild = turret;
        selectedNode = null;
        champShop = champShopGiven;
        DeselectNode();
    }

    public void SelectNode(Node node)
    {
        if (node == selectedNode)
        {
            DeselectNode();
            return;
        }
        selectedNode = node;
        champShop = null;
        turretToBuild = null;

        turretUI.SetTarget(node);
    }

    public void DeselectNode()
    {
        selectedNode = null;
        turretUI.Hide();
    }

    public TurretBlueprint GetTurretToBuild()
    {
        return turretToBuild;
    }

    public ChampShop GetChampShop()
    {
        return champShop;
    }

    public void TurretBuild()
    {
        turretToBuild = null;
    }
}
