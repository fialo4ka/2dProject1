using UnityEngine;

public class RestartKity : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var dieSpace = GameObject.Find("DieSpace");
        var mapLength = (int)(dieSpace.transform.localScale.x - 10) / 2;
        var startPosition = new Vector3(-mapLength - 3, 0, 0);
        if (collision.CompareTag("Player"))
        {
            collision.transform.position = startPosition;
        }
    }
}
