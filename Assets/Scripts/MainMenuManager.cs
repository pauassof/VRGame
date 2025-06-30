using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject panelMenu;
    [SerializeField]
    private GameObject panelDificultad;
    [SerializeField]
    private AudioClip clickSFX;
    [SerializeField]
    private AudioClip menuMusic;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AudioManager.instance.PlayMusic(menuMusic, 1);
        panelMenu.SetActive(true);
        panelDificultad.SetActive(false);
        
    }

    public void NuevaPartida()
    {
        AudioManager.instance.PlaySFX(clickSFX, 1);
        panelMenu.SetActive(false);
        panelDificultad.SetActive(true);

    }
    public void Facil()
    {
        AudioManager.instance.PlaySFX(clickSFX, 1);
        int random = Random.Range(15, 20);
        GameManager.instance.cantidadEnemigos = random;
        SceneManager.LoadScene(1);
    }
    public void Medio()
    {
        AudioManager.instance.PlaySFX(clickSFX, 1);
        int random = Random.Range(25, 30);
        GameManager.instance.cantidadEnemigos = random;
        SceneManager.LoadScene(1);
    }
    public void Dificil()
    {
        AudioManager.instance.PlaySFX(clickSFX, 1);
        int random = Random.Range(35, 40);
        GameManager.instance.cantidadEnemigos = random;
        SceneManager.LoadScene(1);
    }
    public void ExitGame()
    {
        AudioManager.instance.PlaySFX(clickSFX, 1);
        Application.Quit();
    }
    public void VolverMenu()
    {
        AudioManager.instance.PlaySFX(clickSFX, 1);
        SceneManager.LoadScene(0);
    }
}
