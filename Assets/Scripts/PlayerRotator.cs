using UnityEngine;

public class PlayerRotator : MonoBehaviour
{
    [SerializeField] private float _speed = 0.1f;
    private Vector3 _previousMousePosition;

    private void Start()
    {
        _previousMousePosition = Input.mousePosition;
    }

    private void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector3 delta = _previousMousePosition - mousePosition;
        float rotationDelta = delta.x;

        transform.Rotate(transform.up, rotationDelta * _speed * Time.deltaTime);
        _previousMousePosition = mousePosition;
        //float h = _speed * Time.deltaTime * Input.GetAxis("Mouse X");
        //transform.Rotate(transform.up, h, 0);
    }
}