using UnityEngine;

public class Shop : MonoBehaviour
{
    public TowersBluePrint arrowTower;
    public TowersBluePrint canonTower;
    public TowersBluePrint mageTower;
    private BuildManager buildManager;
      //Start is called before the first frame update
    void Start()
    {
       buildManager = BuildManager.instance; 
    }

    // Update is called once per frame
  /*   void Update()
    {
        
    }  */
     public void SelectArrowTower()
     {
         Debug.Log("Archer Preparé");
         buildManager.SelectTowerToBuild(arrowTower);
     }
    public void SelectCanonTower()
     {
         Debug.Log("canon armé");
         buildManager.SelectTowerToBuild(canonTower);
     }
    public void SelectMageTower()
     {
         Debug.Log("magie chargée");
         buildManager.SelectTowerToBuild(mageTower);
     }
}
