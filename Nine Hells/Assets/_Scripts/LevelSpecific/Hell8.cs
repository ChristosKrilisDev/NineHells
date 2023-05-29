using _Scripts.Character;
using _Scripts.Interactions.InteractionsSO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hell8 : MonoBehaviour
{
    public GameObject player;
    public TalkInteraction npcTalkInteraction;

    public bool helpedNpc = false;

    public void Virtue()
    {
        if (!helpedNpc) return;
        player.GetComponent<Player>().AddVirtue();
        GetComponent<GoalManager>().OnGoalReached();
    }

    public void Sin()
    {
        player.GetComponent<Player>().AddSin();
        GetComponent<GoalManager>().OnGoalReached();
    }

    public void HelpNpc()
    {
        helpedNpc = true;
        npcTalkInteraction.ClearDialogues();

        npcTalkInteraction.AddDialogue("Heh. It seems you didn't have a choice but help me");
        npcTalkInteraction.AddDialogue("Go now");
    }
}
