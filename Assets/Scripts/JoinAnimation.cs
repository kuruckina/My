using System;
using UnityEngine;

public class JoinAnimation : MonoBehaviour
{
    public Animator boxAnimator;
    public Animator sphereAnimator;
    public Transform target;
    private PlayerAnimation anim;
    private InputService _inputService;
    private bool boxIsOpen = false;

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
        if (Input.GetKeyDown(KeyCode.F) && !boxIsOpen)
        {
            if (Vector3.Distance(transform.position, target.position) <= 0.5)
            {
                transform.position = new Vector3(target.position.x, target.position.y, target.position.z);
                _inputService.SetMovementActive(false);
                boxAnimator.SetTrigger("open");
                anim.PlayOpenAnimation();
                boxIsOpen = true;
            }
        }
    }

    public void AnimationEnded()
    {
        _inputService.SetMovementActive(true);
    //     sphereAnimator.SetTrigger("spawn");
    }
    
    public void SpawnPrefab()
    {
        sphereAnimator.SetTrigger("spawn");
    }
}