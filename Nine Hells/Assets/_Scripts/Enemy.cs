using System;
using _Scripts.Character;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UIElements;
namespace _Scripts
{
    public class Enemy : MonoBehaviour
    {
        public int _hp =1;


        public GameObject materialNPC;
        public Animator Animator;
        public GameObject Head;
        public bool CountEnemyDeath;
        public bool isDead = false;
        
        public void Init(int hp)
        {
            _hp = hp;
        }

        private void OnEnable()
        {
            if (isDead)
            {
                Animator.SetBool("isDead",isDead);
            }
            if (_hp > 0)
            {
                gameObject.GetComponent<BoxCollider>().enabled = true;
            }
        }

        public void TakeDamage(int amount)
        {
            _hp--;

            if (_hp <= 0)
            {
                
                if (CountEnemyDeath && LoadingManager.instance.GetCurrentLevel()==2) //todo : add level 6 counter
                {
                    Hell2.IncreaseKilledEnemies();
                }
                else if(CountEnemyDeath && LoadingManager.instance.GetCurrentLevel() == 7)
                {
                    Hell7.IncreaseKilledEnemies();
                }
                
                //die
                // Destroy(gameObject);
                isDead = true;
                Animator.SetBool("die",true);


                if (materialNPC.TryGetComponent(out Animator animator))
                {
                               
                    for (int i = 0; i < materialNPC.transform.childCount; i++)
                    {
                        materialNPC.transform.GetChild(i).gameObject.SetActive(false);
                    }

                    materialNPC.gameObject.SetActive(true);
                    materialNPC.GetComponent<NPC>().isDead = isDead;
                    materialNPC.transform.GetComponent<BoxCollider>().enabled = false;
                    animator.SetBool("isDead",isDead);

                    for (int i = 0; i < materialNPC.transform.childCount; i++)
                    {
                        materialNPC.transform.GetChild(i).gameObject.SetActive(true);
                    }
                    
                    // Destroy(materialNPC.GetComponent<Animator>());
                }

                transform.DOLocalMoveX(0.01f, 0.5f).OnComplete(()=>
                {
                    Animator.SetBool("isDead",isDead);
                    transform.GetComponent<BoxCollider>().enabled = false;
                    Reflect.UseReflect(materialNPC, this.gameObject, PlaneObject.ReflectType.NPC);
                });
            }
        }
        
        
        
        
        
    }
}
