using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class CartucheraCargadores : MonoBehaviour
{
    [SerializeField]
    private GameObject CargadorPrefab;
    private XRGrabInteractable cartucheraLeft;


    private void Start()
    {
        cartucheraLeft = gameObject.GetComponent<XRGrabInteractable>();
    }

    public void CogerCargador(SelectEnterEventArgs args)
    {
        Debug.Log("Agarro Algo");
            GameObject cargadorClone = Instantiate(CargadorPrefab);

            XRGrabInteractable interactable = cargadorClone.GetComponent<XRGrabInteractable>();
            XRBaseInteractor interactor = args.interactorObject as XRBaseInteractor;

            cartucheraLeft.interactionManager.SelectExit((IXRSelectInteractor)interactor, (IXRSelectInteractable)cartucheraLeft);
            cartucheraLeft.interactionManager.SelectEnter((IXRSelectInteractor)interactor, (IXRSelectInteractable)interactable);

    }
    public void EntraLaMano()
    {
        Debug.Log("Entra Algo");
    }

}
