using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace _Scripts.Interactions.InteractionsSO
{
    public class CombatController : MonoBehaviour
    {
        public float RaycastDistance = 10f;
        public float playerHealth = 100.0f;
        public List<Buff> playerBuffs = new(), playerDebuffs = new();
        public Animator Animator;

        public GameObject Sword;
        public Vector3 SwordScale;

        public float AttackDelay = 0.7f;
        
        
        private void Start()
        {
            playerHealth = 100.0f;
            HUD.Instance.PlayerStatsGUI.ChangePlayerHPUI(playerHealth);
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

        void AddBuffToPlayer(Buff newBuff)
        {
            bool playerAlreadyHasBuff = false;

            if (newBuff.buffType == BuffType.Buff)
            {
                foreach (Buff buff in playerBuffs)
                {
                    if (buff.buffNo == newBuff.buffNo)
                    {
                        playerAlreadyHasBuff = true;
                        break;
                    }
                }

                if (!playerAlreadyHasBuff)
                {
                    playerBuffs.Add(newBuff);
                    HUD.Instance.PlayerStatsGUI.RefreshBuffsUi(playerBuffs);
                }
            }
            else
            {
                foreach(Buff debuff in playerDebuffs)
                    {
                    if (debuff.buffNo == newBuff.buffNo)
                    {
                        playerAlreadyHasBuff = true;
                        break;
                    }
                }

                if (!playerAlreadyHasBuff)
                {
                    playerDebuffs.Add(newBuff);
                    HUD.Instance.PlayerStatsGUI.RefreshDebuffsUi(playerDebuffs);
                }
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                Buff buff = new Buff(BuffType.Buff, 1);
                AddBuffToPlayer(buff);
            }

            if (Input.GetKeyDown(KeyCode.K))
            {
                Buff buff = new Buff(BuffType.Buff, 3);
                AddBuffToPlayer(buff);
            }

            if (Input.GetKeyDown(KeyCode.L))
            {
                Buff buff = new Buff(BuffType.Debuff, 1);
                AddBuffToPlayer(buff);
            }

            if (Input.GetKeyDown(KeyCode.N))
            {
                playerHealth -= 10.0f;
                HUD.Instance.PlayerStatsGUI.ChangePlayerHPUI(playerHealth);
                if (playerHealth <= 0.0f)
                {
                    Debug.Log("GAME OVER");
                }
            }

            if (SwitchPlaneManager.CurrentPlaneState != SwitchPlaneManager.PlaneState.ShadowPlane)
            return;

            if (AttackDelay < 0.7f)
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

                if (hit.collider.TryGetComponent(out Enemy enemy))
                {
                    Debug.Log("Ray hit: " + enemy.gameObject.name);
                    enemy.TakeDamage(1);
                    // hit.collider.gameObject.GetComponent<Enemy>().TakeDamage(10);
                }

                if(hit.collider.TryGetComponent(out BarrelFood barrelFood))
                {
                    barrelFood.TakeDamage(1);
                    Debug.Log("Hit barrels");
                }

                if (hit.collider.TryGetComponent(out Rocks rocks))
                {
                    rocks.HitRocks();
                }

                if(hit.collider.TryGetComponent(out BridgeCollide bridgeCollide))
                {
                    bridgeCollide.HitBridge(1);
                }
            }
        }

    }
}
