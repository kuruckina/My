using UnityEngine;

public class BasketRb : MonoBehaviour
{
    private Rigidbody _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void Kinematic(bool value)
    {
        _rb.isKinematic = value;
    }
}