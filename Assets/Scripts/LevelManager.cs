using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit.Inputs;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private GameObject panelAjustes;
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
    [SerializeField]
    private int tiempoSpawn;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cantidadEnemigos = GameManager.instance.cantidadEnemigos;
        StartCoroutine(SpawnEnemigos());
    }

    // Update is called once per frame
    void Update()
    {
        if (manoIzquierda)
        {
            panelAjustes.SetActive(!boolAjustes);
        }
        else if (manoDerecha)
        {
            panelAjustes.SetActive(!boolAjustes);
        }
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
}
