using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject kity;
    private void Update()
    {
        transform.position = new Vector3(kity.transform.position.x, kity.transform.position.y, transform.position.z);
    }
}
