using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour

{

    private Camera mainCam;
    private Vector3 mousePos;
    public GameObject bullet;
    public GameObject burger;
    public Transform burgerTransform;
    public Transform bulletTransform;
    public bool canFire;
    public bool fireSpell;
    private float timer;
    private float timer2;
    public float timeBetweenFiring;
    public float timeBetweenFiringSpell;


    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = mousePos - transform.position;

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotZ);

        if (!canFire) 
        {
            timer += Time.deltaTime;
            if (timer > timeBetweenFiring) 
            {
                canFire = true;
                timer = 0;
            }
        
        }
        if (!fireSpell)
        {
            timer2 += Time.deltaTime;
            if (timer2 > timeBetweenFiringSpell)
            {
                fireSpell = true;
                timer2 = 0;
            }

        }


        if (Input.GetMouseButtonDown(0)&& canFire)
        { 

            canFire = false;
            Instantiate(bullet, bulletTransform.position, Quaternion.identity);
        
        }

        if (Input.GetMouseButtonDown(1) && fireSpell)
        {

            fireSpell = false;
            Instantiate(burger, burgerTransform.position, Quaternion.identity);
            
        }


    }
   


}
