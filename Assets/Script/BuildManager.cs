using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    #region Singleton
    public static BuildManager instance;
        private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("Il y a déja un Build Manager dans la Scène !");
            return;
        }
        instance = this;
    }
    #endregion
    public GameObject standardTowerPrefab;
    public GameObject canonTowerPrefab;
    public GameObject mageTowerPrefab; 
    private TowersBluePrint towerToBuild;
    public GameObject buildingEffect;
   


    public bool canBuild { get {return towerToBuild != null;} }
    public bool hasMoney { get {return PlayerStats.money >= towerToBuild.cost;} }


    public void SelectTowerToBuild(TowersBluePrint _tower)
    {
        towerToBuild = _tower;
    }
    public void BuildTowerOn(TowerBase towerBase)
    {

        if (PlayerStats.money < towerToBuild.cost)
        {
            Debug.Log("Pas assez d'argent");
            return;
        }

        PlayerStats.money -= towerToBuild.cost;
        Debug.Log("Toure achetée il vous reste " + PlayerStats.money);
        GameObject tower = (GameObject)Instantiate(towerToBuild.prefab, towerBase.transform.position, Quaternion.Euler(-90f, towerBase.transform.rotation.eulerAngles.y, towerBase.transform.rotation.eulerAngles.z));
        towerBase.tower = tower;
        GameObject effect = (GameObject)Instantiate(buildingEffect,towerBase.transform.position,Quaternion.identity);
        Destroy(effect,1f);
    }
}
  