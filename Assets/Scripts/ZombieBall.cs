using UnityEngine;

public class ZombieBall : MonoBehaviour
{
    [SerializeField]
    private float damage;
    [SerializeField]
    private GameObject explosion;
    [SerializeField]
    private AudioClip explosionSFX;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        Vector3 direccion = rb.linearVelocity.normalized;
        transform.LookAt(direccion+transform.position);
        transform.localEulerAngles += new Vector3(90, 0, 0);
    }
    private void OnCollisionEnter(Collision collision)
    {
        AudioManager.instance.PlaySFX(explosionSFX, 1);
        if (collision.transform.tag == "Player")
        {
            collision.gameObject.transform.GetComponent<PlayerController>().TakeDamage(damage);
            GameObject explosionClone = Instantiate(explosion, transform.position, transform.rotation);
            Destroy(explosionClone, 1);
            Destroy(gameObject);
        }
        else
        {
            GameObject explosionClone = Instantiate(explosion, transform.position, transform.rotation);
            Destroy(explosionClone, 1);
            Destroy(gameObject);
            
        }
    }


}
