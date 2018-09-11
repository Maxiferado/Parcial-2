using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Hazard : MonoBehaviour
{
    private Collider2D myCollider;
    private object myRigidbody;

    [SerializeField]
    private float resistance = 1F;
    private float spinTime = 1F;
    Vector2 PeneDePerro = new Vector2(1, 0);
    private float contadorCambio;
    private int movDirect = -1;
    private float FuerzaMov = 1f;
    private float FuerzaGiro = 1000f;
    [SerializeField]
     private Rigidbody2D Satanas;
    private int quesoy;
    private bool GiroOno;

    // Use this for initialization
    protected void Start()
    {

        quesoy = Random.Range(1, 4);
        myCollider = GetComponent<Collider2D>();
        myRigidbody = GetComponent<Rigidbody2D>(); 
        if(quesoy == 1)
        {
            GiroOno = false;
        }
        if(quesoy == 2)
        {
            GiroOno = true;
        }
        if(quesoy == 3)
        {

        }
    
    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Bullet>() != null)
        {
            //TODO: Make this to reduce damage using Bullet.damage attribute
            resistance -= 1;

            if (resistance == 0)
            {
                OnHazardDestroyed();
            }
        }
        if(collision.gameObject.GetComponent<Shelter>() != null)
        {
            resistance -= 1;
            if(resistance == 0)
            {
                OnHazardDestroyed();
            }
        }
       
    }
    
    public void OnHazardDestroyed()
    {
        //TODO: GameObject should spin for 'spinTime' secs. then disappear
        Destroy(gameObject);
    }
    public void CambioDireccion()
    {
        if (contadorCambio > 1)
        {
            Satanas.velocity = Vector2.zero;
            Satanas.AddForce(PeneDePerro * FuerzaMov * movDirect, ForceMode2D.Impulse);
            contadorCambio = 0;
            movDirect *= -1;

        }
        
    }
    public void giro()
    {
        
        transform.Rotate(0,0, 1 * FuerzaGiro * Time.deltaTime);
    }

    public void Update()
    {

        Debug.Log(quesoy);

        contadorCambio += Time.deltaTime;
        if(quesoy == 1)
        {
            Debug.Log("JAJAJA mira como me muevo");
            CambioDireccion();
           
        }

        if (quesoy == 2)
        {
            Debug.Log("JAJAJA mira como giro");
            giro();

        }
        if (quesoy == 3)
        {
            Debug.Log("JAJAJA no hago nada");
        }
    }


  

}