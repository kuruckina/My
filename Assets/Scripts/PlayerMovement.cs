using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Base Settings")]
    [SerializeField] private PlayerAnimation _animation;
    [SerializeField] private CharacterController _controller;
    [SerializeField] private float _walkSpeed = 3f;
    [SerializeField] private float _runSpeed = 10f;
    [SerializeField] private float _gravityMultiplier = 1.5f;

    [Header("Grounded")]
    [SerializeField] private Transform _checkGroundTransform;
    [SerializeField] private float _checkGroundRadius;
    [SerializeField] private LayerMask _checkGroundMask;

    [Header("Jump")]
    [SerializeField] private float _jumpHeight = 2f;

    public AudioSource _source;

    private Transform _cachedTransform;
    private Vector3 _fallVector;
    private InputService _inputService;

    private void Awake()
    {
        _cachedTransform = transform;
        _inputService = new InputService();
    }

    private void Update()
    {
        Vector2 axes = _inputService.Axes;
        Vector3 moveVector = _cachedTransform.right * axes.x + _cachedTransform.forward * axes.y;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveVector *= _runSpeed;
        }
        else
        {
            moveVector *= _walkSpeed;
        }

        _controller.Move(moveVector * Time.deltaTime);
        _animation.SetSpeed(moveVector.magnitude);
        if (moveVector.magnitude > 0 && !_source.isPlaying)
        {
            _source.Play();
        }
        else if(moveVector.magnitude == 0 && _source.isPlaying)
        {
            _source.Stop();
        }

        //----ходьба 
        if (Input.GetKey(KeyCode.W))
        {
            _animation.SetWalkAnimation(true);
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            _animation.SetWalkAnimation(false);
        }

        if (Input.GetKey(KeyCode.S))
        {
            _animation.SetWalkBackAnimation(true);
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            _animation.SetWalkBackAnimation(false);
        }

        if (Input.GetKey(KeyCode.A))
        {
            _animation.SetWalkLeftAnimation(true);
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            _animation.SetWalkLeftAnimation(false);
        }

        if (Input.GetKey(KeyCode.D))
        {
            _animation.SetWalkRightAnimation(true);
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            _animation.SetWalkRightAnimation(false);
        }

        //----бег 
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _animation.SetRunAnimation(true);
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            _animation.SetRunAnimation(false);
        }


        bool isGrounded = Physics.CheckSphere(_checkGroundTransform.position, _checkGroundRadius, _checkGroundMask);
        Debug.LogError(isGrounded);

        if (isGrounded && _fallVector.y < 0)
        {
            _fallVector.y = 0;
            _animation.SetJumpAnimation(false);
        }

        float gravity = Physics.gravity.y * _gravityMultiplier;

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            _animation.SetJumpAnimation(true);
            _fallVector.y = Mathf.Sqrt(_jumpHeight * -2f * gravity);
        }

        _fallVector.y += gravity * Time.deltaTime;
        _controller.Move(_fallVector * Time.deltaTime);
    }
}