using UnityEngine;

public class IKAnimation : MonoBehaviour
{
    private Animator anim;
    private bool interact;
    private Vector3 positionForIК;
    private float weight = 0;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnAnimatorIK() // метод подобен Update, но используется для программных анимаций
    {
        if (interact)
        {
            if (weight < 1) weight += 0.02f;
            anim.SetIKPositionWeight(AvatarIKGoal.RightHand, weight);
            anim.SetIKPosition(AvatarIKGoal.RightHand, positionForIК);
            anim.SetLookAtWeight(weight);
            anim.SetLookAtPosition(positionForIК);
        }
        else if (weight > 0)
        {
            weight -= 0.03f;
            anim.SetIKPositionWeight(AvatarIKGoal.RightHand, weight);
            anim.SetIKPosition(AvatarIKGoal.RightHand, positionForIК);
            anim.SetLookAtWeight(weight);
            anim.SetLookAtPosition(positionForIК);
        }
    }

    public void StartInteraction(Vector3 pos)
    {
        positionForIК = pos;
        interact = true;
    }

    public void StopInteraction()
    {
        interact = false;
    }
}