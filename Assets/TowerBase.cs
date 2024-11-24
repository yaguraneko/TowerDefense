using UnityEngine;
using UnityEngine.EventSystems;

public class TowerBase : MonoBehaviour
{
    public Color hoverColor;
    private Color baseColor;
    private Renderer crend;
    private GameObject tower;
    private BuildManager buildManager;



    // Start is called before the first frame update
     void Start()
    {
       crend= GetComponent<Renderer>();
       baseColor = crend.material.color;
       buildManager = BuildManager.instance;
    }
/*
    // Update is called once per frame
    void Update()
    {
        
    } */
    private void OnMouseDown()
    {
        if(EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if(buildManager.GetTowerToBuild()== null)
        {
            return;
        }
        if(tower != null)
        {
            Debug.Log("Impossible de construir");
        }

        //Construir une tourelle.
        GameObject towerToBuild = buildManager.GetTowerToBuild();
       tower = Instantiate(towerToBuild, transform.position, Quaternion.Euler(-90f, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z));
                // Instantiate(towerToBuild, transform.position, transform.rotation);
        
    }
    private void OnMouseEnter()
    {
        if(EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if(buildManager.GetTowerToBuild()== null)
        {
            return;
        }
        crend.material.color = hoverColor;
    }
    private void OnMouseExit()
    {
        crend.material.color = baseColor;
    }
}
