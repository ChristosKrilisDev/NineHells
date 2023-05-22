using System;
using UnityEngine;

namespace _Scripts.Interactions.InteractionsSO
{
    public class CombatController : MonoBehaviour
    {
        public float RaycastDistance = 10f;
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
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
