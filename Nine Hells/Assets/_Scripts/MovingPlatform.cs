
using DG.Tweening;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

    public Transform startTransform;
    public Transform endTrasform;
    
    public float startDelay, endDelay;
    public float speed;

    private void OnEnable()
    {
        MoveLeft();
    }

    private void MoveLeft()
    {
        transform.DOKill();
        transform.DOLocalMove(startTransform.localPosition, speed).SetDelay(startDelay).OnComplete(() =>
        {
            MOveRight();
        });
    }

    private void MOveRight()
    {
        transform.DOKill();
        transform.DOLocalMove(endTrasform.localPosition, speed).SetDelay(endDelay).OnComplete(() =>
        {
            MoveLeft();
        });
    }

    private void OnDisable()
    {

    }

}
