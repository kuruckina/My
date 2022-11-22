using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    //private static readonly int WalkSpeed = Animator.StringToHash("WalkSpeed");
    //private static readonly int RunSpeed = Animator.StringToHash("RunSpeed");
    [SerializeField] private Animator _animator;

    public void SetWalkAnimation(bool value)
    {
        _animator.SetBool("walk", value);
    }

    public void SetWalkBackAnimation(bool value)
    {
        _animator.SetBool("walkB", value);
    }

    public void SetWalkLeftAnimation(bool value)
    {
        _animator.SetBool("walkL", value);
    }

    public void SetWalkRightAnimation(bool value)
    {
        _animator.SetBool("walkR", value);
    }

    public void SetRunAnimation(bool value)
    {
        _animator.SetBool("run", value);
    }

    public void SetJumpAnimation(bool value)
    {
        _animator.SetBool("jump", value);
    }
    public void PlayOpenAnimation()
    {
        _animator.SetTrigger("open");
    }

    private void Update()
    {
        //float number = Random.Range()
    }
}