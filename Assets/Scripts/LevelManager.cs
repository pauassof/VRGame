using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.InputSystem;
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


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
}
