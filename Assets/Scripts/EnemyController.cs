using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    enum EnemyStates {Following, Death, Hit, Attacking}

    [SerializeField]
    private EnemyStates currentState;
    [SerializeField]
    private GameObject ball;
    [SerializeField]
    private Transform ballSpawnPoint;
    [SerializeField]
    private float ballSpeed;
    [SerializeField]
    private float waitAttack;
    private float passTime = 5;
    [SerializeField]
    private bool hasBall;
    [SerializeField]
    private float fuerzaGravedad;



    private Animator animator;
    private Rigidbody rb;
    private NavMeshAgent agent;
    private GameObject rival;
    public float currentLife;
    private LevelManager lm;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
        lm = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        rival = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        passTime += Time.deltaTime;
        if (currentState == EnemyStates.Following)
        {
            animator.SetBool("Attack", false);
            animator.SetBool("Walk", true);
            agent.destination = rival.transform.position;
            float distance = (rival.transform.position - transform.position).magnitude - 0.2f;

            if (distance <= agent.stoppingDistance)
            {
                currentState = EnemyStates.Attacking;
            }
        }
        if (currentState == EnemyStates.Attacking)
        {
            animator.SetBool("Walk", false);
            transform.LookAt(new Vector3(rival.transform.position.x, transform.position.y, rival.transform.position.z));

                if (hasBall)
                {

                    if (passTime >= waitAttack)
                    {
                        animator.SetTrigger("Attack");
                        Invoke("InstanciarBola", 1);
   //                 ballClone.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, -fuerzaGravedad, 0));
                        passTime = 0;
                    }
                }
                else
                {
                    animator.SetBool("Attack", true);
                }
                float distance = (rival.transform.position - transform.position).magnitude - 0.2f;

                if (distance > agent.stoppingDistance)
                {
                    currentState = EnemyStates.Following;
                }
        }
    }
    private void InstanciarBola()
    {
        GameObject ballClone = Instantiate(ball, ballSpawnPoint.transform.position, ballSpawnPoint.transform.rotation);
        ballClone.gameObject.GetComponent<Rigidbody>().linearVelocity = ballClone.transform.up * ballSpeed;
    }

    public void TakeDamage(float damage)
    {
        currentLife -= damage;
        if (currentLife <= 0)
        {
            //Muerte
            lm.RestarEnemigos();
            Destroy(gameObject);
            
        }
    }

}

