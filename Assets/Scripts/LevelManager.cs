using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit.Inputs;

public class LevelManager : MonoBehaviour
{
    private bool boolAjustes = false;
    [SerializeField]
    private InputActionReference manoIzquierda;
    [SerializeField]
    private InputActionReference manoDerecha;
    [SerializeField]
    private Image vida;
    [SerializeField]
    private Transform[] spawners;
    [SerializeField]
    private GameObject[] enemigos;
    private int cantidadEnemigos;
    private int totalEnemigos;
    [SerializeField]
    private int tiempoSpawn;
    [SerializeField]
    private GameObject panelFinal;
    [SerializeField]
    private GameObject body;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        cantidadEnemigos = GameManager.instance.cantidadEnemigos;
        totalEnemigos = cantidadEnemigos;
        
        StartCoroutine(SpawnEnemigos());
    }

    // Update is called once per frame
    void Update()
    {
        body.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y - 0.4f, Camera.main.transform.position.z);

    }
    public void BajarVida(float vida_)
    {
        vida.fillAmount = vida_;
    }
    private IEnumerator SpawnEnemigos()
    {
        for (int i = 0; cantidadEnemigos >= i; i++)
        {
            int random = Random.Range(0, spawners.Length);
            int randomEnemy = Random.Range(0, enemigos.Length);
            GameObject enemyClone = Instantiate(enemigos[randomEnemy], spawners[random].position, spawners[random].rotation);
            yield return new WaitForSeconds(tiempoSpawn);
        }
    }
    public void RestarEnemigos()
    {
        totalEnemigos--;
        if (totalEnemigos <= 0)
        {
            panelFinal.SetActive(true);
            //sonido victoria
        }
    }
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
    public void Muerte()
    {
        SceneManager.LoadScene(2);
    }
}
