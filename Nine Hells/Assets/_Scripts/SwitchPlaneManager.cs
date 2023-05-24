
using _Scripts.Interactions.InteractionsSO;
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

    public CombatController CombatController;
    public Animator MaterialAnimator;
    public Animator ShadowAnimator;

    private void Awake()
    {
        _planeObjects = FindObjectsOfType<PlaneObject>();

        foreach (var plane in _planeObjects)
        {
            plane.Init(_dissolveMaterialPlaneMat, _dissolveShadowPlaneMat);
        }


        CurrentPlaneState = PlaneState.MaterialPlane;
        SwitchPlane(CurrentPlaneState);
    }



    // Update is called once per frame
    void Update()
    {
        if(CurrentPlaneState == PlaneState.Switching) return;
        
        if (Input.GetKeyDown(KeyCode.F))
        {
            CombatController.enabled = true;
            CombatController.ActivateWeapon();
            CombatController.Animator = ShadowAnimator;
            SwitchPlane(PlaneState.ShadowPlane);
        }
        
        if (Input.GetKeyDown(KeyCode.G))
        {
            CombatController.enabled = false;
            CombatController.HideWeapon();
            CombatController.Animator = MaterialAnimator;
            SwitchPlane(PlaneState.MaterialPlane);

        }
    }

    public void SwitchPlane(PlaneState planeState)
    {
        if(CurrentPlaneState == planeState) return;

        CurrentPlaneState = planeState;
        
        
        HUD.Instance.PlayerStatsGUI.ChangePlaneUI(planeState);
        
        
        foreach (var po in _planeObjects)
        {
            po.SwitchPlane(planeState);
        }

        
 
    }
}
