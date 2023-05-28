
using UnityEngine;

public class NPC : MonoBehaviour
{
    public Animator Animator;
    public bool isDead = false;

    private void OnEnable()
    {
        if (!isDead)
        {
            gameObject.GetComponent<BoxCollider>().enabled = true;
        }
        if (isDead)
        {
            Animator.SetBool("isDead",isDead);
            gameObject.GetComponent<BoxCollider>().enabled = false;

        }
    }

    private void OnDisable()
    {
        
    }
}
