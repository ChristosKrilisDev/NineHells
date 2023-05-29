using System;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using _Scripts.Character;
using UnityEngine;

public class Hell2 : MonoBehaviour
{
    public GameObject portal;
    public GameObject player;
    public GameObject oldMan;
    public static GameObject Player;
    public static GameObject Portal;
    public static GameObject OldMan;

    private void Start()
    {
        Portal = portal;
        Player = player;
        OldMan = oldMan;
    }

    public void OnNpcHelped()
    {
        //portal.SetActive(true);

        //portal.transform.position = player.transform.position - Vector3.right * 2f;

        OldMan.SetActive(true);
        OldMan.transform.position = Player.transform.position - Vector3.right * 2f;
        Player.GetComponent<Player>().AddVirtue();

    }

    public void RaiseLadder(List<Transform> args)
    {
        args[0].GetComponent<BoxCollider>().enabled = false;
        args[0].DOLocalMove(args[1].localPosition, 0.4f).OnComplete(() =>
        {
            args[0].GetComponent<BoxCollider>().enabled = true;
        });
        args[0].DOLocalRotate(args[1].transform.eulerAngles, 0.4f);
    }


    public static int KilledEnemies=0;
    
    public static void IncreaseKilledEnemies()
    {
        KilledEnemies++;

        if (KilledEnemies >= 2)
        {
            //Portal.SetActive(true);

            //Portal.transform.position = Player.transform.position - Vector3.right * 2f;
            OldMan.SetActive(true);
            OldMan.transform.position = Player.transform.position - Vector3.right * 2f;

            Player.GetComponent<Player>().AddSin();
        }
    }
    
}
