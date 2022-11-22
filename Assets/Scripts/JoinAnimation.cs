using System;
using UnityEngine;

public class JoinAnimation : MonoBehaviour
{
    public Animator doorAnimator;   
    public Transform target;
    private PlayerAnimation anim;
    private bool secondTurn = false;
    private InputService _inputService;

    private void Awake()
    {
        _inputService = new InputService();
    }

    private void Start()
    {
        anim = GetComponent<PlayerAnimation>(); 
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (Vector3.Distance(transform.position, target.position) <= 0.5)
            {
                transform.position = new Vector3(target.position.x, target.position.y, target.position.z);
                _inputService.SetMovementActive(false);
                doorAnimator.SetTrigger("open");
                anim.PlayOpenAnimation();
                // _inputService.SetMovementActive(true);
            }
        }
    }
}