using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    enum EnemyStates {Following, Death, Hit, Attacking}

    [SerializeField]
    private EnemyStates currentState;

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
        if (currentState == EnemyStates.Following)
        {
            animator.SetBool("Attack", false);
            animator.SetBool("Walk", true);
            agent.destination = rival.transform.position;
            float distance = (rival.transform.position - transform.position).magnitude;

            if ((distance -= 0.2f) <= agent.stoppingDistance)
            {
                currentState = EnemyStates.Attacking;
            }
        }
        if (currentState == EnemyStates.Attacking)
        {
            animator.SetBool("Walk", false);
            animator.SetBool("Attack", true);
            transform.LookAt(new Vector3(rival.transform.position.x, transform.position.y, rival.transform.position.z));
            

            float distance = (rival.transform.position - transform.position).magnitude;

            if (distance > agent.stoppingDistance)
            {
                currentState = EnemyStates.Following;
            }

        }
    }
    public void TakeDamage(float damage)
    {
        currentLife -= damage;
        if (currentLife <= 0)
        {
            //Muerte
            animator.SetTrigger("Death");
            Destroy(gameObject, 5f);
        }
    }

}

