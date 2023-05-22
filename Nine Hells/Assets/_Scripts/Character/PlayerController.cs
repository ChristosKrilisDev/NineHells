using UnityEngine;

namespace _Scripts.Character
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(PlayerInteraction))]
    public class PlayerController : MonoBehaviour
    {
        public bool IsGrounded = false;
        private bool _isClimbing = false;

        [Space]
        [SerializeField]private float _moveSpeed = 5f;
        [SerializeField]private float _climbSpeed = 0.5f;
        [SerializeField]private float _jumpForce = 5f;

        private Rigidbody _rb;

        private void Start()
        {
            _rb = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            ClimbInput();
            Jump();
        }
    
        private void FixedUpdate()
        {
            var moveX = Input.GetAxisRaw("Horizontal");
            _rb.velocity = new Vector2(moveX * _moveSpeed, _rb.velocity.y);


            if (!_isClimbing) return;
            var moveY = Input.GetAxisRaw("Vertical");
            var speed = IsGrounded ? 1 : 3;
            _rb.velocity = new Vector2(_rb.velocity.x/speed, moveY * _climbSpeed);

        }

        private void ClimbInput()
        {
            if (!Input.GetKeyDown(KeyCode.UpArrow) || !_isClimbing) return;
        
            _isClimbing = false;
            _rb.useGravity =false;
            _rb.velocity = Vector3.zero;
        }

        private void Jump()
        {
            if (Input.GetKeyDown(KeyCode.Space) && IsGrounded)
            {
                _rb.AddForce(new Vector3(0f, _jumpForce,0), ForceMode.Impulse);
            }
        }
    

        private void OnTriggerEnter(Collider collision)
        {
            if (collision.CompareTag("Ladder"))
            {
                _isClimbing = true;
                _rb.useGravity = false;
            }
        }

        private void OnTriggerExit(Collider collision)
        {
            if (collision.CompareTag("Ladder"))
            {
                _isClimbing = false;
                _rb.useGravity = true;
            }
        }
    

    }
}
