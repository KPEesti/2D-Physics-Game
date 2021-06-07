using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]
public class CameraTrigger : MonoBehaviour
{
    public UnityEvent EnterTriggerEvent;
    public UnityEvent ExitTriggerEvent;

    private void OnTriggerEnter2D(Collider2D other) => EnterTriggerEvent?.Invoke();

    private void OnTriggerExit2D(Collider2D other) => ExitTriggerEvent?.Invoke();
}
