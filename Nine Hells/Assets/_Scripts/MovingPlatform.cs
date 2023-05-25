
using DG.Tweening;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

    public Transform startTransform;
    public Transform endTrasform;
    
 
    public float speed;

    private void OnEnable()
    {
        MoveLeft();
    }

    private void MoveLeft()
    {
        transform.DOKill();
        transform.DOLocalMove(startTransform.localPosition, speed).OnComplete(() =>
        {
            MOveRight();
        });
    }

    private void MOveRight()
    {
        transform.DOKill();
        transform.DOLocalMove(endTrasform.localPosition, speed).OnComplete(() =>
        {
            MoveLeft();
        });
    }

    private void OnDisable()
    {

    }

}
