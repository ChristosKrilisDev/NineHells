using UnityEngine;
namespace _Scripts.Character
{
    public class GroundChecker : MonoBehaviour
    {
        public PlayerController Player;

        private void Start()
        {
            // Player = transform.root.GetComponent<PlayerController>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Ground"))
            {
                Player.IsGrounded = true;
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Ground"))
            {
                Player.IsGrounded = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Ground"))
            {
                Player.IsGrounded = false;
            }
        }

    }
}
