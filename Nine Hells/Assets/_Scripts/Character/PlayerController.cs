using UnityEngine;
using DG.Tweening;

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
        
        public float JumpDelay = 0.5f;

        public static bool CanMove = true;
        private Rigidbody _rb;

        private float previousMoveX = 1;
        private bool rotating = false;
        private Vector3 previousAngles;

        private void Start()
        {
            _rb = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            if (SwitchPlaneManager.CurrentPlaneState == SwitchPlaneManager.PlaneState.Switching || !CanMove)
            {
                _rb.velocity = Vector3.zero;
                return;
            }

            var moveX = Input.GetAxisRaw("Horizontal");
            _rb.velocity = new Vector2(moveX * _moveSpeed, _rb.velocity.y);

            if((previousMoveX<0 && moveX>0) || (previousMoveX>0 && moveX<0)) RotateOtherSide();

            if(moveX!=0)previousMoveX = moveX;


            if (!_isClimbing) return;

            var moveY = Input.GetAxisRaw("Vertical");
            var speed = IsGrounded ? 1 : 3;

            var desiredVelocity = new Vector2(_rb.velocity.x / speed, moveY * _climbSpeed);
            _rb.velocity = Vector2.ClampMagnitude(desiredVelocity, _maxVelocity);
        }
        
        private void Update()
        {
            if (SwitchPlaneManager.CurrentPlaneState == SwitchPlaneManager.PlaneState.Switching || !CanMove)
            {
                _rb.velocity = Vector3.zero;
                return;
            }

            if (CheckIfBelowHeight(-7)) ResetPlayer();

            ClimbInput();
            Jump();
        }

        private void RotateOtherSide()
        {
            if (rotating)
            {
                transform.DOKill();
                transform.eulerAngles = previousAngles + Vector3.up * 180;
            }
            rotating = true;
            previousAngles = transform.eulerAngles;
            transform.DOLocalRotate(transform.eulerAngles + Vector3.up * 180, 0.2f).OnComplete(() =>
            {
                rotating = false;
            });
        }

        private bool CheckIfBelowHeight(float minHeight)
        {
            if(transform.position.y<minHeight) return true;
            return false;
        }

        private void ResetPlayer()
        {
            LoadingManager.instance.ReloadScene();
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
            if (JumpDelay < 1)
            {
                JumpDelay += Time.deltaTime;
                return;
            }
            
            if (Input.GetKeyDown(KeyCode.Space) && IsGrounded)
            {
                JumpDelay = 0;

                // var force = Mathf.Min(_rb.velocity.y, _jumpForce);
                //todo: fix max velocity
                _rb.AddForce(new Vector3(0f, _jumpForce,0), ForceMode.VelocityChange);
            }
        }
    
        public void SlowJump(float amount)
        {
            if (_jumpForce < amount) return;
            _jumpForce -= amount;
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
