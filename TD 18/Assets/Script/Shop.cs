using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour {

    public TurretBluePrint standardTurret;
    public TurretBluePrint missileLauncher;
    public TurretBluePrint laserBeamer;
    BuildManager buildManager;
    private void Start()
    {
        buildManager = BuildManager.instance;
      //  SelectStandardTurret();

    }
    public void SelectStandardTurret()
    {
        buildManager.SelectTurrentToBuild(standardTurret);
    }
    public void SelectMissileTurret()
    {
        buildManager.SelectTurrentToBuild(missileLauncher);
    }
    public void SelectLaserBemer()
    {
        buildManager.SelectTurrentToBuild(laserBeamer);
    }
}
