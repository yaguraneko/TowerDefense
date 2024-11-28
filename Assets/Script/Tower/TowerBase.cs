using UnityEngine.EventSystems;
using UnityEngine;

public class TowerBase : MonoBehaviour
{
    public Color hoverColor;
    private Color baseColor;
    public Color notEnoughMoneyColor;
    private Renderer crend;

    public GameObject tower;
    private BuildManager buildManager;
 



    // Start is called before the first frame update
     void Start()
    {
       crend= GetComponent<Renderer>();
       baseColor = crend.material.color;
    buildManager = BuildManager.instance;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position ;
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
        if(!buildManager.canBuild)
        {
            return;
        }
        if(tower != null)
        {
            Debug.Log("Impossible de construir");
        }

        //Construir une tourelle.
        buildManager.BuildTowerOn(this);
        
    }
    private void OnMouseEnter()
    {   
         if(EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if(!buildManager.canBuild)
        {
            return;
        }
        if(buildManager.hasMoney)
        {
            crend.material.color = hoverColor;
        }else
        {
            crend.material.color = notEnoughMoneyColor;
            Debug.Log("Pas d'argent");
        }
    }
    private void OnMouseExit()
    {
        crend.material.color = baseColor;
    }
}
