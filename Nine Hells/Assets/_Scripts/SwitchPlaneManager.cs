
using UnityEngine;



public class SwitchPlaneManager : MonoBehaviour
{

    public enum PlaneState
    {
        MaterialPlane,
        ShadowPlane,
        Switching
    }
    
    
    [SerializeField] private Material _dissolveMaterialPlaneMat;
    [SerializeField] private Material _dissolveShadowPlaneMat;

    public static PlaneState CurrentPlaneState = PlaneState.Switching;
    
    private PlaneObject[] _planeObjects;
    
    // [SerializeField] private GameObject _materialPlaneGO;
    // [SerializeField] private GameObject _shadowPlaneGO;
    // private List<PlaneObject> _materialPlaneGOs;
    // private List<PlaneObject> _shadowPlaneGOs;

    private void Awake()
    {
        _planeObjects = FindObjectsOfType<PlaneObject>();

        foreach (var plane in _planeObjects)
        {
            plane.Init(_dissolveMaterialPlaneMat, _dissolveShadowPlaneMat);
        }

        // _materialPlaneGOs = new List<PlaneObject>();
        // for (int i = 0; i < _materialPlaneGO.transform.childCount; i++)
        // {
        //     var child = _materialPlaneGO.transform.GetChild(i);
        //
        //     if (child.transform.TryGetComponent(out PlaneObject pobj))
        //     {
        //         pobj.Init(_dissolveMaterialPlaneMat, _dissolveShadowPlaneMat);
        //         _materialPlaneGOs.Add(pobj);
        //     }
        // }
        //
        // _shadowPlaneGOs = new List<PlaneObject>();
        // for (int i = 0; i < _shadowPlaneGO.transform.childCount; i++)
        // {
        //     var child = _shadowPlaneGO.transform.GetChild(i);
        //     
        //     if (child.transform.TryGetComponent(out PlaneObject pobj))
        //     {
        //         pobj.Init(_dissolveMaterialPlaneMat, _dissolveShadowPlaneMat);
        //         _shadowPlaneGOs.Add(pobj);
        //     }
        // }
        CurrentPlaneState = PlaneState.MaterialPlane;
        SwitchPlane(CurrentPlaneState);
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

        CurrentPlaneState = planeState;
        //
        // if (CurrentPlaneState == PlaneState.MaterialPlane)
        // {
        //   _materialPlaneGO.SetActive(true);   
        //   _shadowPlaneGO.SetActive(false);
        //
        // }
        // else if(CurrentPlaneState == PlaneState.ShadowPlane)
        // {
        //     _shadowPlaneGO.SetActive(true);
        //     _materialPlaneGO.SetActive(false);   
        //
        // }
        
        
        HUD.Instance.PlayerStatsGUI.ChangePlaneUI(planeState);
        
        
        foreach (var po in _planeObjects)
        {
            po.SwitchPlane(planeState);
        }



        // if (planeState == PlaneState.MaterialPlane)
        // {
        //     foreach (var mgo in _materialPlaneGOs)
        //     {
        //         // mgo.gameObject.SetActive(true);
        //         mgo.Show();
        //     }
        //
        //     foreach (var sgo in _shadowPlaneGOs)
        //     {
        //         // sgo.gameObject.SetActive(false);
        //         sgo.Hide();
        //     }
        // }
        // else if (planeState == PlaneState.ShadowPlane)
        // {
        //     foreach (var mgo in _materialPlaneGOs)
        //     {
        //         // mgo.gameObject.SetActive(false);
        //         mgo.Hide();
        //     }
        //
        //     foreach (var sgo in _shadowPlaneGOs)
        //     {
        //         // sgo.gameObject.SetActive(true);
        //         sgo.Show();
        //     }
        // }
 
    }
}
