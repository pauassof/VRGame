using UnityEngine;

public class ManoEnemigo : MonoBehaviour
{
    public float damage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<PlayerController>().TakeDamage(damage);
        }
    }
}
