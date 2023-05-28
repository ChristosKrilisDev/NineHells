using _Scripts.Character;
using UnityEngine;

public class Hell5 : MonoBehaviour
{
    public Player player;

    public void Virtue()
    {
        player.GetComponent<Player>().AddVirtue();
        GetComponent<GoalManager>().OpenPortal();
    }

    public void Sin()
    {
        player.GetComponent<Player>().AddSin();
        GetComponent<GoalManager>().OpenPortal();
    }
}
