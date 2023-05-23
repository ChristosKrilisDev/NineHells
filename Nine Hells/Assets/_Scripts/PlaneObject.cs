using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneObject : MonoBehaviour
{

    [SerializeField] private Material _materialPlaneMat;
    [SerializeField] private Material _dissolveMaterialPlaneMat;

    [SerializeField] private Material _shadowPlaneMat;
    [SerializeField] private Material _dissolveShadowPlaneMat;


    private float _delay = 0.009f;
    private MeshRenderer _meshRenderer;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
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
    
    private void SwitchToShadowPlane()
    {
        StartCoroutine(SwitchMaterialsDelay(_shadowPlaneMat, _dissolveShadowPlaneMat, -2, SwitchPlaneManager.PlaneState.ShadowPlane));

    }

    private void SwitchToMaterialPlane()
    {
        StartCoroutine(SwitchMaterialsDelay(_materialPlaneMat, _dissolveMaterialPlaneMat, -2, SwitchPlaneManager.PlaneState.MaterialPlane));
    }

    private IEnumerator SwitchMaterialsDelay(Material targetMat, Material dissolveMat, float startValue, SwitchPlaneManager.PlaneState state)
    {
        SwitchPlaneManager.CurrentPlaneState = SwitchPlaneManager.PlaneState.Switching;
        
        _meshRenderer.material = dissolveMat;
        dissolveMat.SetFloat("_DisAmount", startValue);

        while (startValue <= 2)
        {
            startValue += 0.1f;
            Debug.Log("dissolve : " + startValue);

            _meshRenderer.material.SetFloat("_DisAmount", startValue);

            yield return new WaitForSeconds(_delay);
        }

        yield return new WaitForSeconds(0.4f);

        while (startValue >= -2)
        {
            startValue -= 0.1f;
            _meshRenderer.material.SetFloat("_DisAmount", startValue);

            yield return new WaitForSeconds(_delay);
        }

        

        _meshRenderer.material = targetMat;
        SwitchPlaneManager.CurrentPlaneState = state;

    }

}
