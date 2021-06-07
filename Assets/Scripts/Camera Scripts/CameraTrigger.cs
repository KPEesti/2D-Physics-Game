using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]
public class CameraTrigger : MonoBehaviour
{
    public UnityEvent IsEnteredEvent;
    public UnityEvent IsExitEvent;

    private bool isActive1 = true;
    private bool isActive2 = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (tag is "CameraTrigger" && isActive1 && collision.tag is "Player")
        {
            IsEnteredEvent?.Invoke();
            isActive1 = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (tag is "CameraTrigger" && isActive2 && collision.tag is "Player")
        {
            IsExitEvent?.Invoke();
            isActive2 = false;
        }
    }
}
