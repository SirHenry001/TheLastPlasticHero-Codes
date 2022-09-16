using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoEnemy : MonoBehaviour
{
    public float ammoSpeed = 30f;

    public GameObject hitEffect;
    public GameObject bloodEffect;

    public GameManager gameManager;

    /*
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            GameObject hit = Instantiate(hitEffect, transform.position,transform.rotation);
            Destroy(hit, 1.5f);
            GameObject blood = Instantiate(bloodEffect, transform.position,transform.rotation);
            Destroy(blood, 0.5f);
            gameManager.AddHealth(5);
        }

        if(collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
        
    }
    */

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            GameObject hit = Instantiate(hitEffect, transform.position, transform.rotation);
            Destroy(hit, 1.5f);
            GameObject blood = Instantiate(bloodEffect, transform.position, transform.rotation);
            Destroy(blood, 0.5f);
            gameManager.AddHealth(4);
        }

        if (other.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 3f);
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * ammoSpeed * Time.deltaTime);

    }
}
