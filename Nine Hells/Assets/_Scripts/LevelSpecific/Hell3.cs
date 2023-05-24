using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Hell3 : MonoBehaviour
{
    public GameObject balanceScale;
    public GameObject chainTipLeft;
    public GameObject chainTipRight;

    private void Start()
    {
        Rotate(30);
    }

    public void Rotate(float angle)
    {
        balanceScale.transform.DORotate(new Vector3(balanceScale.transform.eulerAngles.x, balanceScale.transform.eulerAngles.y, balanceScale.transform.eulerAngles.z + angle), 1);
        chainTipLeft.transform.DORotate(new Vector3(chainTipLeft.transform.eulerAngles.x, chainTipLeft.transform.eulerAngles.y, chainTipLeft.transform.eulerAngles.z), 1);
        chainTipRight.transform.DORotate(new Vector3(chainTipRight.transform.eulerAngles.x, chainTipRight.transform.eulerAngles.y, chainTipRight.transform.eulerAngles.z), 1);

    }

    public void BalanceScale(float weight)
    {
        float minAngle = -30;
        float maxAngle = 0;


    }
}
