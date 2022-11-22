using UnityEngine;

public class InputService : MonoBehaviour
{
    public static bool IsMovementActive { get; private set; } = true;
    public Vector2 Axes => IsMovementActive ?
        new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) :
        Vector2.zero;

    public void SetMovementActive(bool value)
    {
        IsMovementActive = value;
    }

}