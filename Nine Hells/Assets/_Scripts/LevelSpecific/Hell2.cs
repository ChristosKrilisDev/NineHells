using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hell2 : MonoBehaviour
{
    public GameObject portal;
    public GameObject player;
    public void OnNpcHelped()
    {
        portal.SetActive(true);

        portal.transform.position = player.transform.position - Vector3.right * 2f;
    }

    public void RaiseLadder(Transform[] args)
    {
        args[0].GetComponent<BoxCollider>().enabled = false;
        args[0].DOLocalMove(args[1].localPosition, 0.4f).OnComplete(() =>
        {
            args[0].GetComponent<BoxCollider>().enabled = true;
        });
        args[0].DOLocalRotate(args[1].transform.eulerAngles, 0.4f);
    }
}
