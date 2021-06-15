using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]
public class CameraTrigger : MonoBehaviour
{
    public UnityEvent IsEnteredEvent;
    public UnityEvent IsExitEvent;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (tag is "CameraTrigger" && collision.tag is "Player")
            IsEnteredEvent?.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (tag is "CameraTrigger" && collision.tag is "Player")
            IsExitEvent?.Invoke();
    }
}
