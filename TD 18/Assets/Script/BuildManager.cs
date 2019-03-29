
using UnityEngine;

public class BuildManager : MonoBehaviour {

    public static BuildManager instance;
    private void Awake()
    {
        if(instance != null)
        {
            Debug.Log("More than one BuildManager is scene!");
        }
        instance = this;      
    }
    private void Start()
    {
        DeselecNode();
    }
    public GameObject buildEffect;
    public GameObject sellEffect;
    public TurretBluePrint turretToBuild = null;
    private Node selectedNode;

    public NodeUI nodeUI;
    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney{ get { return PlayerStats.Money >= turretToBuild.cost; } }
   

    public void SelectNode(Node node)
    {
        if(selectedNode == node)
        {
            DeselecNode();
            return;
        }
        selectedNode = node;
        turretToBuild = null;
        nodeUI.setTarget(node);
    }
    public void DeselecNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }
    public void SelectTurrentToBuild(TurretBluePrint turret)
    {
        turretToBuild = turret;
        DeselecNode();
    }
    public TurretBluePrint GetTurretToBuild()
    {
        return turretToBuild;
    }
}
