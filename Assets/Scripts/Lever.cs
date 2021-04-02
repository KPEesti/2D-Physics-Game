using UnityEngine;
using UnityEngine.Events;

public class Lever : MonoBehaviour
{
    public UnityEvent SpawnEvent;

    private bool isEntered;
    private bool isActive;

    private void Update()
    {
        if (isEntered && Input.GetButtonDown("Submit") && !isActive)
        {
            SpawnEvent?.Invoke();
            isActive = true;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        isEntered = true;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        isEntered = false;
    }
}
