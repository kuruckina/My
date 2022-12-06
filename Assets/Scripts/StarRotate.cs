using UnityEngine;

public class StarRotate : MonoBehaviour
{
    private void Update()
    {
        transform.Rotate(new Vector3(0, 45, 0) * Time.deltaTime);
    }
}