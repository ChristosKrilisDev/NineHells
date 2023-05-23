using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;



public class SwitchPlaneManager : MonoBehaviour
{

    public enum PlaneState
    {
        MaterialPlane,
        ShadowPlane,
        Switching
    }

    public static PlaneState CurrentPlaneState = PlaneState.MaterialPlane;
    
    private PlaneObject[] _planeObjects;

    private void Awake()
    {
        _planeObjects = FindObjectsOfType<PlaneObject>();
    }



    // Update is called once per frame
    void Update()
    {
        if(CurrentPlaneState == PlaneState.Switching) return;
        
        if (Input.GetKeyDown(KeyCode.F))
        {
            SwitchPlane(PlaneState.ShadowPlane);
        }
        
        if (Input.GetKeyDown(KeyCode.G))
        {
            SwitchPlane(PlaneState.MaterialPlane);
        }
    }

    public void SwitchPlane(PlaneState planeState)
    {
        if(CurrentPlaneState == planeState) return;
        
        foreach (var po in _planeObjects)
        {
            po.SwitchPlane(planeState);
        }
    }
}
