using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Equals("Player"))
        {

            LoadingManager.instance.LoadNextScene();
        }
    }
}
