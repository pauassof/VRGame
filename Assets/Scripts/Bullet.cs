using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float damage;
    [SerializeField]
    private GameObject bulletHolePrefab;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyController>().TakeDamage(damage);
            GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
        }
        else
        {
            GameObject holeClone = Instantiate(bulletHolePrefab);
            holeClone.transform.position = collision.GetContact(0).point;
            Quaternion rotation = Quaternion.FromToRotation(holeClone.transform.up, collision.GetContact(0).normal);
            holeClone.transform.rotation = rotation;
            holeClone.transform.position += holeClone.transform.up * 0.086f;
            holeClone.transform.SetParent(collision.transform);
            Destroy(holeClone, 10);
        }
        Destroy(gameObject);
    }
}
