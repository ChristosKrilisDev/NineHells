
using UnityEngine;

public class NPC : MonoBehaviour
{
    public Animator Animator;
    public bool isDead = false;

    private void OnEnable()
    {
        if (!isDead)
        {
            if (gameObject.TryGetComponent(out BoxCollider boxCollider))
            {
                boxCollider.enabled = true;
            }
        }
        if (isDead)
        {
            Animator.SetBool("isDead",isDead);

            if (gameObject.TryGetComponent(out BoxCollider boxCollider))
            {
                boxCollider.enabled = false;
            }

        }
    }

    private void OnDisable()
    {
        
    }
}
