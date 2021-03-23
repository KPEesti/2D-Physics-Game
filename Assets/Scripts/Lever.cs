using UnityEngine;

public class Lever : MonoBehaviour
{
    private bool isEntered;
    public delegate Coroutine Act();
    public static event Act LeverAction;

    private void Update()
    {
        if (isEntered && Input.GetButtonDown("Submit"))
            LeverAction?.Invoke();
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
