using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]
public class CameraTrigger : MonoBehaviour
{
    public UnityEvent EnterTriggerEvent;
    public UnityEvent ExitTriggerEvent;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (tag is "CameraTrigger")
            EnterTriggerEvent?.Invoke();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (tag is "CameraTrigger")
            ExitTriggerEvent?.Invoke();
    }
}
