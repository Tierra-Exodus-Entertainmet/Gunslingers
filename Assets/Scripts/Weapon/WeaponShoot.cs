using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShoot : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float FireRate = 5f;//15f
    public int MaxAmmo = 5;
    private int _currentAmmo = -1;
    public float ReloadTime = 1.5f;
    private bool isReloading = false;

    public Animator anim;
    private float _nextTimetoFire = 0f;

    public Camera fpsCam;
    public ParticleSystem Flash;
   // public GameObject Flash;
    // Start is called before the first frame update
    void Start()
    {
        if (_currentAmmo == -1)
        {
            _currentAmmo = MaxAmmo;
        }
        anim = GetComponent<Animator>();
        fpsCam = GameObject.FindGameObjectWithTag(Cam.MainCamera).GetComponent<Camera>();
        Flash = GameObject.FindGameObjectWithTag(Weapons.Muzzle).GetComponent<ParticleSystem>();
       // Flash.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isReloading)
        {
            return;
        }

        if (_currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }
        if (Input.GetButton("Fire1") && Time.time >=_nextTimetoFire)
        {
            _nextTimetoFire = Time.time + 1f / FireRate;
            Shoot();
        }
    }

    public void Shoot()
    {
         Flash.Play();
        _currentAmmo--;
        //StartCoroutine(FlashIt());
        RaycastHit hit;
       if( Physics.Raycast(fpsCam.transform.position,fpsCam.transform.forward,out hit, range))
        {
            Debug.Log(hit.transform.name);
            //damage if enemy
        }
            
    }
    public IEnumerator Reload()
    {
        isReloading = true;

        anim.SetBool("Reload", true);
        yield return new WaitForSeconds(ReloadTime-0.5f);
        anim.SetBool("Reload", false);
        yield return new WaitForSeconds(0.5f);

        _currentAmmo = MaxAmmo;
        isReloading = false;
             
    }
   // public IEnumerator FlashIt()
   // {
   //     Flash.SetActive(true);
   //     yield return new WaitForSeconds(0.1f);
   //     Flash.SetActive(false);
   // }
}
