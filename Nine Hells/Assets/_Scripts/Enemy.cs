using UnityEngine;
namespace _Scripts
{
    public class Enemy : MonoBehaviour
    {
        public int _hp =1;


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
                Destroy(gameObject);
            }
        }
        
        
    }
}
