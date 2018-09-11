using UnityEngine;

public class KillVolume : MonoBehaviour
{
    
    private int TomaPerro = -1;
    [SerializeField]
    private Shelter[] shelters;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Hazard>() != null)
        {
            Time.timeScale = 0F;
            print("Game Over");
        }
        if (collision.gameObject.GetComponent<Hazard>() != null)
        {
            
            for (int i = 0; i < shelters.Length; i++)
            {
                if (shelters[i] != null)
                {
                    print("Damaging a shelter");
                    collision.gameObject.GetComponent<Hazard>().OnHazardDestroyed();
                    
                    //myObject.GetComponent<MyScript>().MyFunction()

                }
            }

        }

        Destroy(collision.gameObject);
    }
    
}