using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using _Scripts.Interactions.InteractionsSO;
using System.Linq;
using _Scripts.Character;

public class Hell3 : MonoBehaviour
{
    public GameObject balanceScale;
    public GameObject chainTipLeft;
    public GameObject chainTipRight;

    public GameObject player;
    private float currentWeight = 0;

    private Vector3 balanceScaleDefault;
    private Vector3 chainTipLeftDefault;
    private Vector3 chainTipRightDefault;

    private void Start()
    {
        //Rotate(30);
        // 0kg, 15kg, 35kg
        //Perfect Balance at 50kg, lw: 65kg, mw: 85kg, hw: 100kg
        //BalanceScale(50);

        balanceScaleDefault = balanceScale.transform.eulerAngles;
        chainTipLeftDefault = chainTipLeft.transform.eulerAngles;
        chainTipRightDefault = chainTipRight.transform.eulerAngles;

    }

    public void Rotate(float angle)
    {
        //Debug.Log(angle);
        balanceScale.transform.DORotate(new Vector3(balanceScale.transform.eulerAngles.x, balanceScale.transform.eulerAngles.y, balanceScale.transform.eulerAngles.z + angle), 1);
        chainTipLeft.transform.DORotate(new Vector3(chainTipLeft.transform.eulerAngles.x, chainTipLeft.transform.eulerAngles.y, chainTipLeft.transform.eulerAngles.z), 1);
        chainTipRight.transform.DORotate(new Vector3(chainTipRight.transform.eulerAngles.x, chainTipRight.transform.eulerAngles.y, chainTipRight.transform.eulerAngles.z), 1);

    }

    public void BalanceScale(float weight)
    {
        float minAngle = -30;
        float maxAngle = 30;

        float minWeight = 0;
        float maxWeight = 100;

        float targetAngle = (weight - minWeight) * (maxAngle - minAngle) / (maxWeight - minWeight) + minAngle;
        Rotate(targetAngle);

        if(weight>=50)StartCoroutine(CheckObjective(weight));
    }

    IEnumerator CheckObjective(float weight)
    {
        yield return new WaitForSeconds(2);

        if (weight == 50) Virtue();
        else Sin();

        GetComponent<GoalManager>().OnGoalReached();

        
    }

    private void Virtue()
    {
        player.GetComponent<Player>().AddVirtue();
    }

    private void Sin()
    {
        balanceScale.transform.parent.gameObject.AddComponent<Rigidbody>();

        AddStability(balanceScale.transform.parent);
        AddStability(balanceScale.transform);
        AddStability(chainTipLeft.transform);
        AddStability(chainTipRight.transform);

        balanceScale.transform.parent.gameObject.GetComponent<Rigidbody>().AddExplosionForce(1000, balanceScale.transform.position, 5);

        player.GetComponent<Player>().AddSin();
    }

    private void AddStability(Transform _transform)
    {
        for (int i = 0; i < _transform.childCount; i++)
        {
            GameObject go = _transform.GetChild(i).gameObject;
            go.AddComponent<Rigidbody>();
            go.AddComponent<MeshCollider>();
            go.GetComponent<MeshCollider>().convex = true;
        }
    }

    public void GainWeight()
    {
        currentWeight = currentWeight switch
        {

            0 => 15,
            15 => 35,
            35 => 50,
            50 => 65,
            65 => 85,
            85 => 100,
            _ => 0
        };

        //Debug.Log($"Weight: {currentWeight}");
    }

    public void CheckWeight()
    {
        
        BalanceScale(currentWeight);
    }

    public void Reset()
    {
        balanceScale.transform.DOKill();
        chainTipLeft.transform.DOKill();
        chainTipRight.transform.DOKill();

        balanceScale.transform.eulerAngles = balanceScaleDefault;
        chainTipLeft.transform.eulerAngles = chainTipLeftDefault;
        chainTipRight.transform.eulerAngles= chainTipRightDefault;

        balanceScale.transform.parent.GetComponent<UseInteraction>().CanInteract = true;
    }
}
