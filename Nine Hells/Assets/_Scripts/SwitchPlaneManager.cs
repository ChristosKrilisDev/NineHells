using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;



public class SwitchPlaneManager : MonoBehaviour
{

    public enum PlaneState
    {

    }
    
    
    [SerializeField] private PlaneObject[] _planeObjects;

    private void Awake()
    {
        _planeObjects = FindObjectsOfType<PlaneObject>();
    }

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
