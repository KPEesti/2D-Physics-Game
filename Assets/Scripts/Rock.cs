using System.Collections;
using UnityEngine;

public class Rock : MonoBehaviour
{

    [SerializeField] private Rigidbody2D StoneRigid;
    [SerializeField] public Rigidbody2D ShootRigid;
    [SerializeField] private GameObject StonePrefab;
    [SerializeField] private Transform SpawnPos;
    [SerializeField] private bool isPressed;
    [SerializeField] private float maxDistance = 1f;

    private Collider2D collider;

    private void Start()
    {
        StoneRigid = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
    }

    private void Update()
    {
        if (isPressed)
        {
            Vector2 mousePos = UnityEngine.Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (Vector2.Distance(mousePos, ShootRigid.position) > maxDistance)
                StoneRigid.position = ShootRigid.position + (mousePos - ShootRigid.position).normalized * maxDistance;
            else StoneRigid.position = mousePos;
        }
    }

    private void OnMouseDown()
    {
        isPressed = true;
        StoneRigid.isKinematic = true;
    }

    private void OnMouseUp()
    {
        isPressed = false;
        StoneRigid.isKinematic = false;
        collider.isTrigger = false;

        StartCoroutine(LetGo());
    }

    IEnumerator LetGo()
    {
        yield return new WaitForSeconds(0.1f);
        gameObject.GetComponent<SpringJoint2D>().enabled = false;
        enabled = false;

        yield return new WaitForSeconds(2f);

        if (StonePrefab != null)
            StonePrefab.transform.position = SpawnPos.position;
    }
}
