using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public int reload = 12;
    public int reloadTime = 100;

    public bool isGrounded = false;

    public bool gameActive = true;
    public bool loading = false;
    public bool imageReloadOn;
    public bool imageReloadBackOn;
    public bool imageEmptyOn;

    public Animator animator;

    public Image reloadImage;
    public Image reloadBackImage;
    public Image emptyImage;

    public LayerMask layerMask;

    public float speed = 5f;
    public float rayLength = 1.2f;

    public GameObject bullet;
    public GameObject bulletSpawnerLeft;
    public GameObject bulletSpawnerRight;
    public GameObject gunpowderEffectLeft;
    public GameObject fireEffectLeft;
    public GameObject gunpowderEffectRight;
    public GameObject fireEffectRight;

    //---Triggers
    public GameObject entryDenier;
    public GameObject musicTrigger;

    public GameManager gameManager;
    public MusicManager musicManager;

    public GameObject ammoText;

    public Rigidbody myRigidbody;

    public Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        musicManager = GameObject.Find("MusicManager").GetComponent<MusicManager>();
        mainCamera = FindObjectOfType<Camera>();

        //reloadImage.enabled = false;
        //imageReloadOn = false;

        reloadBackImage.enabled = false;
        imageReloadBackOn = false;

        emptyImage.enabled = false;
        imageEmptyOn = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (gameActive)
        {
            //---SHOOTING
            if (Input.GetButtonDown("Fire1") && !loading)
            {
                animator.SetBool("firing", true);
                InvokeRepeating("Shoot", 0f, 1f);
            }

            if (Input.GetButtonUp("Fire1") && !loading)
            {
                animator.SetBool("firing", false);
                CancelInvoke();
            }

            if (Input.GetKeyDown(KeyCode.Space) && reload <= 11 && !loading)
            {

                StartCoroutine("Reload");

            }

            //---MOUSE CONTROL
            Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
            Plane groundPLane = new Plane(Vector3.up, Vector3.zero);
            float raylenght;

            if (groundPLane.Raycast(cameraRay, out raylenght))
            {
                Vector3 pointToLook = cameraRay.GetPoint(raylenght);
                Debug.DrawLine(cameraRay.origin, pointToLook, Color.cyan);

                transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
            }
  
        }

        
    }

    public void Shoot() //LINKED TO "//---SHOOTING"
    {

        if (reload <= 0)
        {
            gameManager.PlayAudio(4);
            emptyImage.enabled = true;
            imageEmptyOn = true;
            return;
        }

        else
        {
            reload -= 1;
            ammoText.GetComponent<TextMeshProUGUI>().text = reload.ToString() + " x 12";

            gameManager.PlayAudio(0);
            gameManager.PlayAudio(1);

            Instantiate(bullet, bulletSpawnerLeft.transform.position, bulletSpawnerRight.transform.rotation);
            Instantiate(bullet, bulletSpawnerRight.transform.position, bulletSpawnerRight.transform.rotation);
            Instantiate(gunpowderEffectLeft, bulletSpawnerLeft.transform.position, bulletSpawnerRight.transform.rotation);
            Instantiate(gunpowderEffectRight, bulletSpawnerRight.transform.position, bulletSpawnerRight.transform.rotation);
            
            GameObject fireL = Instantiate(fireEffectLeft, bulletSpawnerLeft.transform.position, bulletSpawnerRight.transform.rotation);
            Destroy(fireL,2f);

            GameObject fireR = Instantiate(fireEffectRight, bulletSpawnerRight.transform.position, bulletSpawnerRight.transform.rotation);
            Destroy(fireR, 2f);

        }
    }

    public IEnumerator Reload()
    {
        loading = true;
        gameManager.PlayAudio(2);
        emptyImage.enabled = false;
        imageEmptyOn = false;
        reloadImage.gameObject.SetActive(true);
        reloadBackImage.enabled = true;
        imageReloadBackOn = true;

        yield return new WaitForSeconds(1f);
        reload = 12;
        ammoText.GetComponent<TextMeshProUGUI>().text = "12 x 12";
        loading = false;
        reloadImage.gameObject.SetActive(false);
        reloadBackImage.enabled = false;
        imageReloadBackOn = false;

    }


    private void FixedUpdate()
    {
        //pelaajan ohjattavuus rigidbodylla. ei nopeutta määritelty. se on määritelty alempana kiihtyvyyden yhteydessä
        float ver = Input.GetAxisRaw("Vertical");
        float hor = Input.GetAxisRaw("Horizontal");

        Vector3 movement = new Vector3(hor, 0f, ver);
        movement.Normalize();

        //Ray ray;
        RaycastHit hit;

        // PAINOVOIMA HAHMOLLE
        if (Physics.Raycast(transform.position, Vector3.down,out hit, rayLength, layerMask))
        {
            //print("hit the ground");
            isGrounded = true;
        }

        else if (!Physics.Raycast(transform.position, Vector3.down, out hit, rayLength, layerMask))
        {
            isGrounded = false;
        }

        Debug.DrawRay(transform.position, Vector3.down * rayLength, Color.red);

        if(isGrounded == true)
        {
            myRigidbody.velocity = movement * speed;
        }

        //myRigidbody.velocity = movement * speed;
        
        //liikkuvuusnopeus tehty koodissa puhtaasti- kiihtyvyys:
        if (hor != 0 || ver != 0)
        {
            speed += Time.deltaTime * 20;

            if (speed >= 11f)
            {
                speed = 11f;
            }
        }

        else if (hor == 0 || ver == 0)
        {
            speed = 2f;
        }
        
    }

}
