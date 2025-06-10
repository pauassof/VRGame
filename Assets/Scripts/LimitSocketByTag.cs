using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class LimitSocket : MonoBehaviour
{
    [SerializeField]
    private string allowedTag;
    [SerializeField]
    private XRSocketInteractor socket;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != allowedTag)
        {
            socket.enabled = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        socket.enabled=true;
    }
}
