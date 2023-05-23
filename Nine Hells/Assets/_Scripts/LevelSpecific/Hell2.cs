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
}
