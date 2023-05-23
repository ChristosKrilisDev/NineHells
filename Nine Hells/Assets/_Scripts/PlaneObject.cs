using System;
using System.Collections;
using System.Collections.Generic;
using _Scripts;
using UnityEngine;

public class PlaneObject : MonoBehaviour
{
    
    [Space]
    [SerializeField] private PlaneObjectParent _materialGO;
    [SerializeField] private PlaneObjectParent _shadowGO;

    private Material _dissolveMaterialPlaneMat;
    private Material _dissolveShadowPlaneMat;

    private float _delay = 0.009f;

    private void Awake()
    {
        _shadowGO.gameObject.SetActive(false);
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
    
    private void SwitchToShadowPlane()
    {
        StartCoroutine(SwitchToHide(_materialGO, _dissolveShadowPlaneMat, -2));
        StartCoroutine(SwitchToShow(_shadowGO, _dissolveMaterialPlaneMat, 2, SwitchPlaneManager.PlaneState.ShadowPlane));

    }

    private void SwitchToMaterialPlane()
    {
        StartCoroutine(SwitchToHide(_shadowGO, _dissolveShadowPlaneMat, -2));
        StartCoroutine(SwitchToShow(_materialGO, _dissolveMaterialPlaneMat, 2, SwitchPlaneManager.PlaneState.MaterialPlane));
    }

    private IEnumerator SwitchToHide(PlaneObjectParent parent, Material dissolveMat, float startValue)
    {
        SwitchPlaneManager.CurrentPlaneState = SwitchPlaneManager.PlaneState.Switching;

        dissolveMat.mainTexture = parent.MeshRenderer.material.mainTexture;
        parent.MeshRenderer.material = dissolveMat;

        foreach (var ch in parent.Childs)
        {
            ch.MeshRenderer.material = dissolveMat;
        }

        dissolveMat.SetFloat("_DisAmount", startValue);

        while (startValue <= 2)
        {
            startValue += 0.1f;
            dissolveMat.SetFloat("_DisAmount", startValue);
            yield return new WaitForSeconds(_delay);
        }

        parent.ResetMaterial();
        parent.gameObject.SetActive(false);
        
        foreach (var ch in parent.Childs)
        {
            ch.ResetMaterial();
            ch.gameObject.SetActive(false);
        }


        yield return new WaitForSeconds(0.4f);
        
    }

    private IEnumerator SwitchToShow(PlaneObjectParent parent, Material dissolveMat, float startValue, SwitchPlaneManager.PlaneState state)
    {
        yield return new WaitForSeconds(0.3f);

        parent.MeshRenderer.material = dissolveMat;

        foreach (var ch in parent.Childs)
        {
            ch.MeshRenderer.material = dissolveMat;
            ch.gameObject.SetActive(true);
        }

        parent.gameObject.SetActive(true);
        
        dissolveMat.SetFloat("_DisAmount", startValue);
        
        while (startValue >= -2)
        {
            startValue -= 0.1f;
            dissolveMat.SetFloat("_DisAmount", startValue);
            yield return new WaitForSeconds(_delay);
        }
        
        parent.ResetMaterial();
        // parent.gameObject.SetActive(false);
        
        foreach (var ch in parent.Childs)
        {
            ch.ResetMaterial();
            // ch.gameObject.SetActive(false);
        }

        yield return new WaitForSeconds(0.4f);
        SwitchPlaneManager.CurrentPlaneState = state;

    }
    

}
