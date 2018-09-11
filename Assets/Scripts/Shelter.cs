using UnityEngine;

public class Shelter : MonoBehaviour
{
    [SerializeField]
    private int maxResistance = 5;
    private int Resistencia;
    private int damage = -1;
    private bool ActivarRegen;
    private float regentime;
    private float count;
    private float timer;
    

    public int MaxResistance
    {

        get
        {
            return maxResistance;
        }
        protected set
        {
            maxResistance = value;
        }
    }
    private void Start()
    {
        regentime = 5f;
        Resistencia = maxResistance;
        ActivarRegen = false;
    }
    public void Damage(int damage)
    {
        //maxResistance += damage;
        Resistencia += damage;
        count = timer;
        ActivarRegen = true;
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            maxResistance += damage;
        }

    }
  
    private void Update()
    {
        timer += Time.deltaTime;
        if (ActivarRegen)
        {
            if (timer - count >= regentime)
            {
                curar();
            }
        }
        if (Resistencia <= 0)
        {
            Destroy(this);
            Debug.Log("Shelter dead");
            Time.timeScale = 0F;
            print("Game Over");
        }


        if (maxResistance == 0)
        {
            Destroy(this);
            Time.timeScale = 0F;
            print("Game Over");
            
        }
    }
    public void curar()
    {
        if (Resistencia <= 0)
        {
            Debug.Log("Shelter dead");
        }
        else
        {
            if (Resistencia < maxResistance)
            {
                Resistencia += 1;
                Debug.Log("Regenero");
            }
            else
            {
                Resistencia = maxResistance;
                Debug.Log("Regenero al maximo");
            }
        }


    }
}