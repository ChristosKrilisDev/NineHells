using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SwitchPlaneManager : MonoBehaviour
{

    public enum PlaneState
    {

    }
    
    
    [SerializeField] private List<PlaneObject> _planeObjects;
    
    
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            foreach (var po in _planeObjects)
            {
                po.SwitchToShadowPlane();
            }
        }
        
        if (Input.GetKeyDown(KeyCode.G))
        {
            foreach (var po in _planeObjects)
            {
                po.SwitchToMaterialPlane();
            }
        }
    }
}
