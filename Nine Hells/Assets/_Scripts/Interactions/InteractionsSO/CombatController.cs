using System;
using DG.Tweening;
using UnityEngine;

namespace _Scripts.Interactions.InteractionsSO
{
    public class CombatController : MonoBehaviour
    {
        public float RaycastDistance = 10f;

        public Animator Animator;

        public GameObject Sword;
        public Vector3 SwordScale;

        public float AttackDelay = 1f;
        
        
        private void Start()
        {
            SwordScale = Sword.transform.localScale;
            HideWeapon();
        }

        public void ActivateWeapon()
        {
            Sword.SetActive(true);
            Sword.transform.DOKill();
            Sword.transform.DOScale(SwordScale,0.8f);
            // Sword.SwitchPlane(SwitchPlaneManager.PlaneState.ShadowPlane);
        }

        public void HideWeapon()
        {
            Sword.transform.DOKill();
            Sword.transform.DOScale(Vector3.zero,0.8f).OnComplete(() =>
            {
                Sword.SetActive(false);

            });

            // Sword.SwitchPlane(SwitchPlaneManager.PlaneState.MaterialPlane);
        }
        
        private void Update()
        {

            if(SwitchPlaneManager.CurrentPlaneState != SwitchPlaneManager.PlaneState.ShadowPlane)
                return;

            if (AttackDelay < 1)
            {
                AttackDelay += Time.deltaTime;
                return;
            }
            
            if (Input.GetKey(KeyCode.F))
            {
                AttackDelay = 0;

                Sword.gameObject.SetActive(true);
                
                //delay
                Animator.SetTrigger("attack");
                
                RaycastHit hit;

                if (!Physics.Raycast(transform.position, transform.right, out hit, RaycastDistance)) return;
                Debug.DrawLine(transform.position, transform.right * RaycastDistance,Color.red);
                Debug.Log("Ray hit: " + hit.collider.gameObject.name);

                if (hit.collider.TryGetComponent<Enemy>(out Enemy enemy))
                {
                    Debug.Log("Ray hit: " + enemy.gameObject.name);
                    enemy.TakeDamage(1);
                    // hit.collider.gameObject.GetComponent<Enemy>().TakeDamage(10);
                }
            }
        }

    }
}
