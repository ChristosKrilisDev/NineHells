using _Scripts.Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalManager : MonoBehaviour
{
    public GameObject portal;
    public GameObject player;
    public GameObject character;

    public void OnGoalReached()
    {
        
        character.SetActive(true);
        character.transform.position = player.transform.position - Vector3.right * 2f;

    }

    public void OpenPortal()
    {
        portal.SetActive(true);

        portal.transform.position = player.transform.position - Vector3.right * 2f;
        player.GetComponent<Player>().AddVirtue();
    }
}
