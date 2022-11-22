using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] [Range(1f, 5f)] private float _angularSpeed = 1f;
    [SerializeField] private Transform _target;
    private float _angleY;
    private float MouseX;
    private float MouseY;

    void Start()
    {
        MouseX = Input.GetAxis("Mouse X");
        MouseY = Input.GetAxis("Mouse Y");
    }

    private void Update()
    {
        MouseX += Input.GetAxis("Mouse X");
        MouseY -= Input.GetAxis("Mouse Y");

        transform.position = _target.transform.position;
        transform.rotation = Quaternion.Euler(MouseY, MouseX, 0);
    }
}