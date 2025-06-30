using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float damage;



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyController>().TakeDamage(damage);
            GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
        }
        else if (collision.gameObject.tag == "EnemyHead")
        {
            collision.gameObject.transform.GetComponentInParent<EnemyController>().TakeDamage(damage * 2);
            GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
        }
        else
        {
            
        }
        Destroy(gameObject);
    }
}
