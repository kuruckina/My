using UnityEngine;

public class CheckAnimationBox : MonoBehaviour
{
    [SerializeField] private JoinAnimation _joinAnimation;
    public void AnimationEnded()
    {
        _joinAnimation.AnimationEnded();
    }
    public void SpawnPrefab()
    {
        _joinAnimation.SpawnPrefab();
    }
}