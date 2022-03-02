using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject shootOrigen;

    [SerializeField] private int shootCooldown = 2;
    [SerializeField] private float timeShoot = 0;

    private bool canShoot = true;
    [SerializeField] private GameObject bulletPrefab;

    [SerializeField] private float distanceRay = 10f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (canShoot)
        {
            emitirRaycast();
        }
        else
        {
            timeShoot += Time.deltaTime;
        }

        if(timeShoot > shootCooldown){
            canShoot = true;
        }
    }

    private void emitirRaycast()
    {
        RaycastHit hit;

        if(Physics.Raycast(shootOrigen.transform.position, shootOrigen.transform.TransformDirection(Vector3.forward), out hit, distanceRay)){
            if(hit.transform.tag == "Player"){
                canShoot = false;
                timeShoot = 0;
                GameObject b = Instantiate(bulletPrefab, shootOrigen.transform.position, bulletPrefab.transform.rotation);
                b.GetComponent<Rigidbody>().AddForce(shootOrigen.transform.TransformDirection(Vector3.forward) *10f, ForceMode.Impulse);
            }
        }
    }

    private void OnDrawGizmos() {
        if(canShoot){
            Gizmos.color = Color.blue;
            Vector3 puntob = shootOrigen.transform.TransformDirection(Vector3.forward) * distanceRay;
            Gizmos.DrawRay(shootOrigen.transform.position, puntob);
        }
    }
}
