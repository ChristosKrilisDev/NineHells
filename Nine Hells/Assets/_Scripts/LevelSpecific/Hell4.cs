using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

public class Hell4 : MonoBehaviour
{
    Transform bucket;
    
    public void GrabBucket(List<Transform> args)
    {

        bucket = args[2];
        bucket.GetComponent<Rigidbody>().useGravity = false;
        bucket.GetComponent<Rigidbody>().isKinematic = true;
        bucket.DOMove(args[1].position + args[1].transform.right*1.5f+Vector3.up*0.5f, 0.5f).OnComplete(() => { args[2].parent = args[1]; });
        
    }

    public void DropBucket()
    {
        bucket.parent = null;
        bucket.GetComponent<Rigidbody>().useGravity = true;
        bucket.GetComponent<Rigidbody>().isKinematic = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            DropBucket();
        }
    }
}
