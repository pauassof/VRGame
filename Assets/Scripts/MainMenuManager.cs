using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject panelMenu;
    [SerializeField]
    private GameObject panelDificultad;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        panelMenu.SetActive(true);
        panelDificultad.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NuevaPartida()
    {
        panelMenu.SetActive(false);
        panelDificultad.SetActive(true);
    }
    public void Facil()
    {
        int random = Random.Range(15, 20);
        GameManager.instance.cantidadEnemigos = random;
    }
    public void Medio()
    {
        int random = Random.Range(25, 30);
        GameManager.instance.cantidadEnemigos = random;
    }
    public void Dificil()
    {
        int random = Random.Range(35, 40);
        GameManager.instance.cantidadEnemigos = random;
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
