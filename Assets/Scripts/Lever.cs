using UnityEngine;
using UnityEngine.Events;

public class Lever : MonoBehaviour
{
    private bool isEntered;
    public UnityEvent SpawnEvent;

    private void Update()
    {
        if (isEntered && Input.GetButtonDown("Submit"))
            SpawnEvent?.Invoke();
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
