using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Magazine : MonoBehaviour
{
    public int bullets;
    [SerializeField]
    private Transform spawn;

    public void OnSelect()
    {
            transform.SetParent(spawn, false);
            GetComponent<Rigidbody>().isKinematic = false;
            GameObject cargadorClone = Instantiate(gameObject, spawn.transform.position, spawn.rotation);
            cargadorClone.transform.SetParent(spawn, true);
            cargadorClone.GetComponent<Rigidbody>().isKinematic = true;
    }

}
