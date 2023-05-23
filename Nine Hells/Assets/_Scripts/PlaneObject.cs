using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneObject : MonoBehaviour
{

    // [SerializeField] private Material _materialPlaneMat;
    // [Space]
    // [SerializeField] private Material _shadowPlaneMat;
    [Space]
    [SerializeField] private GameObject _materialGO;
    [SerializeField] private GameObject _shadowGO;

    private Material _dissolveMaterialPlaneMat;
    private Material _dissolveShadowPlaneMat;

    private float _delay = 0.009f;
    // private MeshRenderer _meshRenderer;

    private void Awake()
    {
        // _meshRenderer = GetComponent<MeshRenderer>();
        _shadowGO.SetActive(false);
    }

    public void Init(Material dissolveMaterialPlaneMat, Material dissolveShadowPlaneMat)
    {
        _dissolveMaterialPlaneMat = dissolveMaterialPlaneMat;
        _dissolveShadowPlaneMat = dissolveShadowPlaneMat;
    }

    public void SwitchPlane(SwitchPlaneManager.PlaneState planeState)
    {
        switch (planeState)
        {

            case SwitchPlaneManager.PlaneState.MaterialPlane:
                SwitchToMaterialPlane();

                break;
            case SwitchPlaneManager.PlaneState.ShadowPlane:
                SwitchToShadowPlane();

                break;
            case SwitchPlaneManager.PlaneState.Switching:
                //do nothing
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(planeState), planeState, null);
        }
    }

    // public void Hide()
    // {
    //     StartCoroutine(HideMaterials(_materialPlaneMat, _dissolveMaterialPlaneMat, -2, SwitchPlaneManager.PlaneState.MaterialPlane));
    //
    // }
    //
    // public void Show()
    // {
    //     StartCoroutine(ShowMaterials(_materialPlaneMat, _dissolveMaterialPlaneMat, 2, SwitchPlaneManager.PlaneState.MaterialPlane));
    // }

    private void SwitchToShadowPlane()
    {
        StartCoroutine(SwitchMaterialsDelay(_materialGO, _shadowGO, _dissolveShadowPlaneMat, -2, SwitchPlaneManager.PlaneState.ShadowPlane));

    }

    private void SwitchToMaterialPlane()
    {
        StartCoroutine(SwitchMaterialsDelay(_shadowGO, _materialGO , _dissolveMaterialPlaneMat, -2, SwitchPlaneManager.PlaneState.MaterialPlane));
    }

    private IEnumerator SwitchMaterialsDelay(GameObject goToHide, GameObject targetGO,  Material dissolveMat, float startValue, SwitchPlaneManager.PlaneState state)
    {
        SwitchPlaneManager.CurrentPlaneState = SwitchPlaneManager.PlaneState.Switching;

        // dissolveMat.color = targetMat.color;
        // var cMaterial = _meshRenderer.material;
        //TODO : add color to mat
        MeshRenderer mr = goToHide.GetComponent<MeshRenderer>();
        mr.material = dissolveMat;

        // _meshRenderer.material.color = cMaterial.color;
        dissolveMat.SetFloat("_DisAmount", startValue);

        while (startValue <= 2)
        {
            startValue += 0.1f;

            mr.material.SetFloat("_DisAmount", startValue);

            yield return new WaitForSeconds(_delay);
        }

        goToHide.SetActive(false);
        targetGO.SetActive(true);

        yield return new WaitForSeconds(0.4f);

        mr = targetGO.GetComponent<MeshRenderer>();
        mr.material = dissolveMat;
        dissolveMat.SetFloat("_DisAmount", startValue);

        while (startValue >= -2)
        {
            startValue -= 0.1f;
            mr.material.SetFloat("_DisAmount", startValue);

            yield return new WaitForSeconds(_delay);
        }

        // mr.material = targetMat;
        SwitchPlaneManager.CurrentPlaneState = state;

    }
    

}
