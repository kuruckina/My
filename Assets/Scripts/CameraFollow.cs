using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] [Range(1f, 5f)] private float _angularSpeed = 1f;
    [SerializeField] private Transform _target;
    [SerializeField] private GameObject _player;
    private float _angleY;
    private float MouseX;
    private float MouseY;
    private InputService _inputService;

    private void Awake()
    {
        _inputService = new InputService();
    }

    void Start()
    {
        // MouseX = Input.GetAxis("Mouse X");
        // MouseY = Input.GetAxis("Mouse Y");
        MouseX = _inputService.Axes2.x;
        MouseY = _inputService.Axes2.y;
    }

    private void Update()
    {
        // MouseX += Input.GetAxis("Mouse X");
        // MouseY -= Input.GetAxis("Mouse Y");
        MouseX += _inputService.Axes2.x;
        MouseY -= _inputService.Axes2.y;


        transform.position = _target.transform.position;
        transform.rotation = Quaternion.Euler(MouseY, MouseX, 0);
        _player.transform.rotation = Quaternion.Euler(0, MouseX, 0);
        // transform.rotation = Quaternion.Euler(axes.x, axes.y, 0);
        // _player.transform.rotation = Quaternion.Euler(0, axes.y, 0);
    }
}