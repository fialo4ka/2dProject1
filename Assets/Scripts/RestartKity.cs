using UnityEngine;

public class RestartKity : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var dieSpace = GameObject.Find("DieSpace");
        var mapLength = (int)(dieSpace.transform.localScale.x - 30) / 2;
        var startPosition = new Vector3(-mapLength, 2, 0);
        if (collision.CompareTag("Player"))
        {
            collision.transform.position = startPosition;
        }
    }
}
