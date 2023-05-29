using _Scripts.Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hell6 : MonoBehaviour
{
    int talkCounter = 0;
    static int deadCounter = 0;
    GameObject player;
    static GameObject Player;
    static Hell6 instance;

    void Start()
    {
        Player = player;    
        instance= this;
    }

    public void IncreaseTalkCounter()
    {
        talkCounter++;
        if (talkCounter >= 7) Virtue();
    }

    public static void IncreaseDeadCounter()
    {
        deadCounter++;

        if (deadCounter >= 7) Sin();
    }
    

    public void Virtue()
    {
        
        player.GetComponent<Player>().AddVirtue();
        GetComponent<GoalManager>().OnGoalReached();
    }

    public static void Sin()
    {
        Player.GetComponent<Player>().AddSin();
        instance.GetComponent<GoalManager>().OnGoalReached();
    }
}
