using _Scripts.Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hell6 : MonoBehaviour
{
    int talkCounter = 0;
    GameObject player;

    public void IncreaseTalkCounter()
    {
        talkCounter++;
        if (talkCounter >= 7) Virtue();
    }

    public void Virtue()
    {
        
        player.GetComponent<Player>().AddVirtue();
        GetComponent<GoalManager>().OnGoalReached();
    }

    public void Sin()
    {
        player.GetComponent<Player>().AddSin();
        GetComponent<GoalManager>().OnGoalReached();
    }
}
