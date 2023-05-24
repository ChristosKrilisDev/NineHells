using System;
using System.Collections;
using System.Collections.Generic;
using _Scripts;
using _Scripts.Character;
using DG.Tweening;
using UnityEngine;

public class PlaneObject : MonoBehaviour
{

    public enum PlaneTypeObject
    {
        Both,
        Material,
        Shadow
    }

    public PlaneTypeObject TypeObject = PlaneTypeObject.Both;
    public enum ReflectType
    {
        General,
        Ladder,
        NPC,
    }

    public ReflectType rType = ReflectType.General;
    public bool UseReflect = false;

    [Space]
    [Space]
    [SerializeField] private PlaneObjectParent _materialGO;
    [SerializeField] private PlaneObjectParent _shadowGO;

    private Material _dissolveMaterialPlaneMat;
    private Material _dissolveShadowPlaneMat;

    private float _delay = 0.009f;

    private void Start()
    {
        _shadowGO.gameObject.SetActive(false);

        if (TypeObject == PlaneTypeObject.Shadow)
        {
            _materialGO.gameObject.SetActive(false);
        }
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
        if (TypeObject == PlaneTypeObject.Material)
        {
            StartCoroutine(SwitchToHide(_materialGO, _dissolveShadowPlaneMat, 0f));

        }
        else if (TypeObject == PlaneTypeObject.Shadow)
        {
            StartCoroutine(SwitchToShow(_shadowGO, _dissolveMaterialPlaneMat, 1, SwitchPlaneManager.PlaneState.ShadowPlane));

        }
        else
        {
            if (UseReflect)
            {
                Reflect.UseReflect(_shadowGO.gameObject, _materialGO.gameObject, rType);

            }
            StartCoroutine(SwitchToHide(_materialGO, _dissolveShadowPlaneMat, 0f));
            StartCoroutine(SwitchToShow(_shadowGO, _dissolveMaterialPlaneMat, 1, SwitchPlaneManager.PlaneState.ShadowPlane));
        }

    }

    private void SwitchToMaterialPlane()
    {
        if (TypeObject == PlaneTypeObject.Material)
        {
            StartCoroutine(SwitchToShow(_materialGO, _dissolveMaterialPlaneMat, 1, SwitchPlaneManager.PlaneState.MaterialPlane));
        }
        else if (TypeObject == PlaneTypeObject.Shadow)
        {
            StartCoroutine(SwitchToHide(_shadowGO, _dissolveShadowPlaneMat, 0f));
        }
        else
        {
            if (UseReflect)
            {
                Reflect.UseReflect(_materialGO.gameObject, _shadowGO.gameObject, rType);
            }

            StartCoroutine(SwitchToHide(_shadowGO, _dissolveShadowPlaneMat, 0f));
            StartCoroutine(SwitchToShow(_materialGO, _dissolveMaterialPlaneMat, 1, SwitchPlaneManager.PlaneState.MaterialPlane));
        }

    }

    private IEnumerator SwitchToHide(PlaneObjectParent parent, Material dissolveMat, float startValue)
    {
        SwitchPlaneManager.CurrentPlaneState = SwitchPlaneManager.PlaneState.Switching;

        parent.SetMaterial(dissolveMat);

        foreach (var ch in parent.Childs)
        {

            ch.SetMaterials(dissolveMat);
        }

        dissolveMat.SetFloat("_DisAmount", startValue);

        while (startValue <= 1)
        {
            startValue += 0.01f;
            dissolveMat.SetFloat("_DisAmount", startValue);

            yield return new WaitForSeconds(_delay);
        }

        dissolveMat.SetFloat("_DisAmount", 0);

        parent.ResetMaterial();

        foreach (var ch in parent.Childs)
        {
            ch.ResetMaterials();
            ch.gameObject.SetActive(false);
        }
        parent.gameObject.SetActive(false);

    }

    private IEnumerator SwitchToShow(PlaneObjectParent parent, Material dissolveMat, float startValue, SwitchPlaneManager.PlaneState state)
    {
        yield return new WaitForSeconds(1.5f); //1.1f

        dissolveMat.SetFloat("_DisAmount", startValue);

        parent.gameObject.SetActive(true);
        parent.SetMaterial(dissolveMat);

        foreach (var ch in parent.Childs)
        {
            ch.gameObject.SetActive(true);
            ch.SetMaterials(dissolveMat);
        }

        while (startValue >= 0.25f)
        {
            startValue -= 0.01f;
            dissolveMat.SetFloat("_DisAmount", startValue);

            yield return new WaitForSeconds(_delay);
        }

        parent.ResetMaterial();

        foreach (var ch in parent.Childs)
        {
            ch.ResetMaterials();
        }

        yield return new WaitForSeconds(0.2f);
        SwitchPlaneManager.CurrentPlaneState = state;

    }

}
