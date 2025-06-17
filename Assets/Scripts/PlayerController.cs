using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float totalLife;
    [SerializeField]
    private float maxLife;
    private float vidaParalm;
    private LevelManager lm;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lm = GameObject.Find("LevelManager").GetComponent<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        totalLife -= damage;
        vidaParalm = totalLife / maxLife;
        lm.BajarVida(vidaParalm);
        
        if (totalLife <= 0)
        {
            //Death
        }
        else
        {
            
        }
    }
}
