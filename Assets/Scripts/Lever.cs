using UnityEngine;
using UnityEngine.Events;

public class Lever : MonoBehaviour
{
    public UnityEvent SpawnEvent;

    private bool isEntered;
    private bool isActive;

    private void Update()
    {
        if (isEntered && !isActive && Input.GetButtonDown("Submit"))
        {
            SpawnEvent?.Invoke();
            isActive = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isEntered = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isEntered = false;
    }
}