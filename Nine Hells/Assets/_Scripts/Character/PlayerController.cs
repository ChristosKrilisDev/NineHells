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
        [SerializeField] private float _maxVelocity = 5;
        [SerializeField]private float _moveSpeed = 5f;
        [SerializeField]private float _climbSpeed = 0.5f;
        [SerializeField]private float _jumpForce = 5f;

        private Rigidbody _rb;

        private void Start()
        {
            _rb = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            if (SwitchPlaneManager.CurrentPlaneState == SwitchPlaneManager.PlaneState.Switching)
            {
                _rb.velocity = Vector3.zero;
                return;
            }

            var moveX = Input.GetAxisRaw("Horizontal");
            _rb.velocity = new Vector2(moveX * _moveSpeed, _rb.velocity.y);
            
            if (!_isClimbing) return;

            var moveY = Input.GetAxisRaw("Vertical");
            var speed = IsGrounded ? 1 : 3;

            var desiredVelocity = new Vector2(_rb.velocity.x / speed, moveY * _climbSpeed);
            _rb.velocity = Vector2.ClampMagnitude(desiredVelocity, _maxVelocity);
        }
        
        private void Update()
        {
            if (SwitchPlaneManager.CurrentPlaneState == SwitchPlaneManager.PlaneState.Switching)
            {
                _rb.velocity = Vector3.zero;
                return;
            }

            ClimbInput();
            Jump();
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
                // var force = Mathf.Min(_rb.velocity.y, _jumpForce);
                //todo: fix max velocity
                _rb.AddForce(new Vector3(0f, _jumpForce,0), ForceMode.VelocityChange);
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
