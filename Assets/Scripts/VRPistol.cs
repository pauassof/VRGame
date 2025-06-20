using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class VRPistol : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private float bulletSpeed;
    [SerializeField]
    private Transform bulletSpawnPoint;
    [SerializeField]
    private float fireRate;
    private float timePass;
    [SerializeField]
    private GameObject muzzleFlash;

    //Cargador
    private Magazine magazine;
    //Slider
    [SerializeField]
    private Transform slider;
    [SerializeField]
    private float sliderPos;
    [SerializeField]
    private bool deagle;
    [SerializeField]
    private Transform spawnArma;
    private bool hasSlider;
    private bool esClon;


    private XRGrabInteractable interactable;
    [SerializeField]
    private Vector3 leftHandPos, rightHandPos;
    [SerializeField]
    private Vector3 leftHandRot, rightHandRot;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        interactable = GetComponent<XRGrabInteractable>();
        
    }

   
    private void Update()
    {
        if (!deagle)
        {
            if (slider.localPosition.z <= sliderPos)
            {
                Slide();
            }
        }
        else
        {
            if (slider.localPosition.z >= sliderPos)
            {
                Slide();
            }

        }
        
        timePass += Time.deltaTime;
    }
    void Slide()
    {

        if (hasSlider == false)
        {
            hasSlider = true;
        }
    }

    public void OnSelect()
    {
        if (esClon)
        {
            transform.SetParent(spawnArma, false);
            GetComponent<Rigidbody>().useGravity = true;
        }
        if (interactable.IsSelectedByLeft())
        {
            //transform.GetChild(0).localPosition = leftHandPos;
           // transform.GetChild(0).localEulerAngles = leftHandRot;
        }
        else
        {
            //transform.GetChild(0).localPosition = rightHandPos;
            //transform.GetChild(0).localEulerAngles = rightHandRot;
        }
    }
    public void OnActivated()//Shoot
    {
        if(timePass > fireRate)
        {
            if (magazine != null && magazine.bullets > 0 && hasSlider)
            {
                magazine.bullets--;
                GameObject bulletClone = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
                bulletClone.gameObject.GetComponent<Rigidbody>().linearVelocity = bulletClone.transform.forward * bulletSpeed;
                Destroy(bulletClone, 10);
                //GameObject muzzleclone = Instantiate(muzzleFlash, bulletSpawnPoint.position, bulletSpawnPoint.rotation, bulletSpawnPoint);
                //Destroy(muzzleclone, 1);
            }
            else
            {

            }
        }
        
    }
    public void OnSelectExit()
    {
        GameObject armaClone = Instantiate(gameObject, spawnArma.transform.position, spawnArma.rotation);
        armaClone.transform.SetParent(spawnArma, true);
        armaClone.GetComponent<Rigidbody>().useGravity = false;
        if (esClon == false)
        {
            Destroy(gameObject, 2f);
        }
        else
        {
            Destroy(armaClone, 2f);
        }
        
    }

    public void LoadMagazine(SelectEnterEventArgs args)
    {
        magazine = args.interactableObject.transform.GetComponent<Magazine>();
        hasSlider = false;
    }

    public void RemoveMagazine()
    {
        magazine = null;
        hasSlider = false;
    }
}
