using TMPro;
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
    [SerializeField]
    private TextMeshProUGUI textBullets;
    [SerializeField]
    private AudioClip shootSFX, recargarSFX, noBulletsSFX;
    
    private bool hasSlider;


    private XRGrabInteractable interactable;
    [SerializeField]
    private Transform transformLeft;
    [SerializeField]
    private Transform transformRight;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        interactable = GetComponent<XRGrabInteractable>();
        
    }

   
    private void Update()
    {
        if (magazine != null)
        {
            textBullets.text = magazine.bullets.ToString();
        }
        else
        {
            textBullets.text = "0";
        }
        
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

            transform.SetParent(spawnArma, false);
            GetComponent<Rigidbody>().isKinematic = false;
        if (interactable.IsSelectedByLeft())
        {
            gameObject.GetComponent<XRGrabInteractable>().attachTransform = transformLeft; 
        }
        else
        {
            gameObject.GetComponent<XRGrabInteractable>().attachTransform = transformRight;
        }
    }
    public void OnActivated()//Shoot
    {
        if(timePass > fireRate)
        {
            if (magazine != null && magazine.bullets > 0)
            {
                AudioManager.instance.PlaySFX(shootSFX, 1);
                magazine.bullets--;
                GameObject bulletClone = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
                bulletClone.gameObject.GetComponent<Rigidbody>().linearVelocity = bulletClone.transform.forward * bulletSpeed;
                Destroy(bulletClone, 10);
                //GameObject muzzleclone = Instantiate(muzzleFlash, bulletSpawnPoint.position, bulletSpawnPoint.rotation, bulletSpawnPoint);
                //Destroy(muzzleclone, 1);
            }
            else
            {
                AudioManager.instance.PlaySFX(noBulletsSFX, 1);
            }

        }
        
    }
    private void OnCollisionStay(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
    }
    public void OnSelectExit()
    {
        gameObject.transform.position = spawnArma.position;
        gameObject.transform.rotation = spawnArma.rotation;
        gameObject.transform.SetParent(spawnArma, true);
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        
    }

    public void LoadMagazine(SelectEnterEventArgs args)
    {
        AudioManager.instance.PlaySFX(recargarSFX, 1);
        magazine = args.interactableObject.transform.GetComponent<Magazine>();

    }

    public void RemoveMagazine()
    {
        magazine = null;
    }
}
