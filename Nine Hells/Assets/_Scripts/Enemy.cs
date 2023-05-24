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
        
        public void Init(int hp)
        {
            _hp = hp;
        }

        public void TakeDamage(int amount)
        {
            _hp--;

            if (_hp <= 0)
            {
                //die
                // Destroy(gameObject);
                Animator.SetBool("die",true);

                if (materialNPC.TryGetComponent(out Animator animator))
                {
                               
                    for (int i = 0; i < materialNPC.transform.childCount; i++)
                    {
                        materialNPC.transform.GetChild(i).gameObject.SetActive(false);
                    }

                    materialNPC.gameObject.SetActive(true);
                    animator.SetBool("isDead",true);

                    for (int i = 0; i < materialNPC.transform.childCount; i++)
                    {
                        materialNPC.transform.GetChild(i).gameObject.SetActive(true);
                    }
                    
                    // Destroy(materialNPC.GetComponent<Animator>());
                }

                transform.DOLocalMoveX(0.01f, 1f).OnComplete(()=>
                {
                    Animator.SetBool("isDead",true);
                    transform.GetComponent<BoxCollider>().enabled = false;
                    Reflect.UseReflect(materialNPC, this.gameObject, PlaneObject.ReflectType.General);
                });
            }
        }
        
        
        
        
        
    }
}
