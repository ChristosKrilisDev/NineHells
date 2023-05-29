using UnityEngine;
using DG.Tweening;
using _Scripts.Character;
using _Scripts.Interactions.InteractionsSO;
using System.Collections.Generic;
using System;

public class Hell7 : MonoBehaviour
{

    public static int KilledEnemies = 0;
    public GameObject ladder;
    public Transform initPos, endPos;
    public GameObject player;
    static GameObject Player;
    static Hell7 instance;
    public TalkInteraction npcTalkInteraction;
    bool helpedNPC = false;

    void Start()
    {
        Player = player;
        instance = this;
    } 
    public static void IncreaseKilledEnemies()
    {
        KilledEnemies++;

        if (KilledEnemies >= 2)
        {
            Sin();
        }
    }

    public void RaiseLadder(List<Transform> args)
    {
        ladder.GetComponentInChildren<BoxCollider>().enabled = false;
        ladder.transform.DOMove(initPos.position, 0.4f).OnComplete(() =>
        {
            ladder.transform.GetComponentInChildren<BoxCollider>().enabled = true;
        });
        ladder.transform.DORotate(ladder.transform.eulerAngles + Vector3.forward * 180, 0.4f);

        helpedNPC = true;

        npcTalkInteraction.ClearDialogues();
        npcTalkInteraction.AddDialogue("WOW! Thanks for helping me out!");
    }

    public void Virtue()
    {
        if (helpedNPC)GetComponent<GoalManager>().OnGoalReached();
    }

    public static void Sin()
    {
        Player.GetComponent<Player>().AddSin();
        instance.GetComponent<GoalManager>().OpenPortal();
    }
}
