using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField]
    private int damage = 1;

    private Collider2D myCollider;
    private Rigidbody2D myRigidbody;

    [SerializeField]
    private float force = 10F;

    [SerializeField]
    private float autoDestroyTime = 5F;
    private float tiempoBala;



    // Use this for initialization
    private void Start()
    {

        myCollider = GetComponent<Collider2D>();
        myRigidbody = GetComponent<Rigidbody2D>();

        myRigidbody.AddForce(transform.up * force, ForceMode2D.Impulse);

        Invoke("AutoDestroy", autoDestroyTime);
    }

    private void AutoDestroy()
    {

        Destroy(gameObject);

    }
    public void Update()
    {
        tiempoBala = Time.deltaTime;

        if (tiempoBala == autoDestroyTime)
        {
            AutoDestroy();
        }
    }
    protected void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.GetComponent<Hazard>() != null && CompareTag("Bala1"))
        {
            AutoDestroy();

        }
        if (collision.gameObject.GetComponent<Hazard>() != null && CompareTag("Bala2"))
        {
            Debug.Log("Sigue Derecho");
        }
    }
}