using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SwitchPlaneManager;

public class MoveTransformAround : MonoBehaviour
{
    private PlaneObject[] _planeObjects;
    float startingPositionX = 0.0f, timePassed = 0.0f;
    [SerializeField] float cameraMoveSpeed = 2.0f;

    //[SerializeField] private Material _dissolveMaterialPlaneMat;
    //[SerializeField] private Material _dissolveShadowPlaneMat;

    private void Awake()
    {
        _planeObjects = FindObjectsOfType<PlaneObject>(true);

        //foreach (var plane in _planeObjects)
        //{
        //    plane.Init(_dissolveMaterialPlaneMat, _dissolveShadowPlaneMat);
        //}


    }

    // Start is called before the first frame update
    void Start()
    {
        timePassed = 0.0f;
        startingPositionX = transform.localPosition.x;
        StartCoroutine(ChangePlane());
        StartCoroutine(MoveInSin());
    }

    IEnumerator MoveInSin()
    {
        while (true)
        {
            timePassed += Time.deltaTime;
            

            transform.localPosition = new Vector3(startingPositionX + 2*Mathf.Sin(timePassed), transform.localPosition.y, transform.localPosition.z);
            yield return new WaitForSeconds(0.01f);
        }
    }

    IEnumerator ChangePlane()
    {
        bool toggle = false;

        while (true)
        {
            yield return new WaitForSeconds(10.0f);

            if (toggle)
            {
                SwitchPlane(PlaneState.MaterialPlane);

            }
            else
            {
                SwitchPlane(PlaneState.ShadowPlane);
            }
            toggle = !toggle;
        }
    }

    void SwitchPlane(PlaneState planeState)
    {
        foreach (var po in _planeObjects)
        {
            po.SwitchPlane(planeState);
        }
    }
}
