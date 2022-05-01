using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class raycasthit : MonoBehaviour {
    //Float & İnt & Double
    public int gunDamage,mp5damage1,mp5damage2,m4a1damage1,m4a1damage2,combatknifedamage1,combatknifedamage2;//Gun Damages
    public float gunRange, knifeRange;
    public int camval;
    public float gunvalue;
    private float nextFire;
       public float knifedelay,knifedelayMax,knifeleftval,knifenormval;
    public float ammo, sarjor, totalammo, ammokln,fireRate=.10f,weaponRange;//Public Ammos
    public float mp5ammo,mp5sarjor,mp5totalammo,m4a1ammo,m4a1sarjor,m4a1totalammo;//Private Gun Ammos
    public float hitForce = 100f;
    //UI's
    public Text ammotext;
    public RawImage gunimage;
    public Texture mp5texture, m4a1texture,combatknifetexture,cartexture;
    //Booleans
    public bool changeweapon,reload,ates,knifeleft,drivingcar;   
    //String's
    public string gunname,carmodel;
    //Transform & GameObjects
    public Transform gunEndmp5,gunEndm4a1,gunEndKnife;
    public GameObject mp5obj, m4a1obj,combatknifeobj;
    public GameObject muzzleobjmp5,muzzleobjm4a1;
    //Scripts
    public RemyMoveSc rms;
    public RayViewer rv;
    public bool carenterexit;
    //Camera
    public Camera fpsCam;   
    //Other
    private WaitForSeconds shotDuration = new WaitForSeconds(.07f);
    private AudioSource gunAudio;
    public AudioClip shotclip,reloadclip,noammoclip,knifeclip;
  LineRenderer laserLine;
   

    void Start () {
                laserLine = GetComponent<LineRenderer>();
        gunAudio = GetComponent<AudioSource>();
        rv = GetComponent<RayViewer>();
               camval = 1;
        m4a1ammo = m4a1sarjor;
        mp5ammo = mp5sarjor;
        carenterexit = false;
        carmodel = "none";
        if (gunname == "m4a1")
        {
                     ammo = m4a1sarjor;
            totalammo = m4a1totalammo;
            sarjor = m4a1sarjor;
            
        }
  else if(gunname == "mp5")
        {
                   ammo = mp5sarjor;
            totalammo = mp5totalammo;
            sarjor = mp5sarjor;
                   }
        else if(gunname == "combatknife")
        {
            ammo = 0;
            totalammo = 0;
        }
        muzzleobjmp5.SetActive(false);
        muzzleobjm4a1.SetActive(false);
        m4a1obj.SetActive(false);
        combatknifeobj.SetActive(false);
        mp5obj.SetActive(false);
       ammotext.text = ammo + "/" + totalammo;
    }


    void Update()
    {
        if (knifeleft)
            knifedelayMax = knifeleftval;
        else
            knifedelayMax = knifenormval;

         if (Time.timeScale == 1)
        {
            if (changeweapon)
            {
                if (gunname == "combatknife")
                {
                    ammo = 0;
                    totalammo = 0;
                }
                else if (gunname == "mp5")
                {
                    ammo = mp5ammo;
                    totalammo = mp5totalammo;
                    sarjor = mp5sarjor;
                }
                else if (gunname == "m4a1")
                {
                    ammo = m4a1ammo;
                    totalammo = m4a1totalammo;
                    sarjor = m4a1sarjor;
                }
                ammotext.text = ammo + "/" + totalammo;
                changeweapon = false;
            }
            if (gunvalue == 1)
            {
                weaponRange = knifeRange;
                rv.weaponRange = knifeRange;
            }
            else
            {
                weaponRange = gunRange;
                rv.weaponRange = gunRange;
            }

            if (carmodel != "none")
            {
                gunimage.texture = cartexture;
                mp5obj.SetActive(false);
                m4a1obj.SetActive(false);
                combatknifeobj.SetActive(false);
                ammotext.text = carmodel;
                drivingcar = true;
            }

            else if (carmodel == "none")
            {
                if (drivingcar)
                {
                    drivingcar = false;
                    ammotext.text = ammo + "/" + totalammo;
                }
                if (!ates && !reload && Input.GetKeyDown(KeyCode.Alpha1))
                {
                    gunvalue = 1;
                    changeweapon = true;
                }
                else if (!ates && !reload && Input.GetKeyDown(KeyCode.Alpha2))
                {
                    gunvalue = 2;
                    changeweapon = true;

                }
                else if (!ates && !reload && Input.GetKeyDown(KeyCode.Alpha3))
                {
                    gunvalue = 3;
                    changeweapon = true;
                }
                if (gunname == "mp5")
                {
                    mp5ammo = ammo;
                    mp5totalammo = totalammo;
                    mp5sarjor = sarjor;
                    gunimage.texture = mp5texture;
                    mp5obj.SetActive(true);
                    m4a1obj.SetActive(false);
                    combatknifeobj.SetActive(false);
                }
                else if (gunname == "m4a1")
                {
                    m4a1ammo = ammo;
                    m4a1sarjor = sarjor;
                    m4a1totalammo = totalammo;
                    gunimage.texture = m4a1texture;
                    mp5obj.SetActive(false);
                    m4a1obj.SetActive(true);
                    combatknifeobj.SetActive(false);
                }
                else if (gunname == "combatknife")
                {
                    mp5obj.SetActive(false);
                    m4a1obj.SetActive(false);
                    gunimage.texture = combatknifetexture;
                    combatknifeobj.SetActive(true);
                }

                if (ammo == 0)
                {
                    if (gunvalue != 1)
                    {
                        gunimage.color = Color.red;
                    }
                }
                else if (ammo > 0 || gunvalue == 1)
                {
                    gunimage.color = Color.white;
                }
            }
            if (carenterexit)
            {
                ates = false;
            }
            if (!carenterexit && (!reload && ammo > 0 && Input.GetMouseButton(0)) || (Input.GetMouseButton(0) && gunvalue == 1) || Input.GetMouseButton(1) && gunvalue == 1)
            {
                ates = true;
                if (Input.GetMouseButton(1) && !Input.GetMouseButton(0))
                {
                    knifeleft = true;
                }
            }
            if (Input.GetMouseButtonDown(1) && gunvalue != 1)
            {
                camval = 2;
            }
          else if (Input.GetMouseButtonUp(1)||gunvalue == 1||changeweapon)
            {
                           knifeleft = false;
                camval = 1;
                                }
            if (camval == 1)
            {
                fpsCam.fieldOfView = 60;
            }
            else if (camval == 2)
            {
                                fpsCam.fieldOfView = 45;
            }
            if (Input.GetKey(KeyCode.R))
            {
                if (totalammo > 0 && ammo < sarjor)
                {

                    StartCoroutine(ReloadEffect());

                }
            }
            if (reload && !ates)
            {
                ammokln = sarjor - ammo;
                if (ammokln >= totalammo)
                {
                    ammokln = totalammo;
                    ammo += ammokln;
                    totalammo -= ammokln;
                }
                else if (ammokln < totalammo)
                {
                    ammo += ammokln;
                    totalammo -= ammokln;
                }
                ammotext.text = ammo + "/" + totalammo;
            }

            if (!reload && ammo == 0 && Input.GetMouseButtonDown(0) && gunvalue != 1)
            {
                StartCoroutine(NoAmmoEffect());
            }
            else if (Input.GetMouseButtonUp(0) ||Input.GetMouseButtonUp(1)|| ammo <= 0 && gunvalue != 1 || reload)
            {
                ates = false;
                muzzleobjmp5.SetActive(false);
                muzzleobjm4a1.SetActive(false);
               knifedelay = knifedelayMax;
            }
            if (ates)
            {
                                 if (gunname == "mp5")
                {
                    mp5();
                }
                else if (gunname == "m4a1")
                {
                    m4a1();
                }
                else if (gunname == "combatknife")
                {
                    if (knifedelay > 0)
                    {
                        knifedelay -= Time.deltaTime;
                    }
                    else if (knifedelay <= 0)
                    {
                        knife();
                        knifedelay = knifedelayMax;
                    }
                                   }
            }
        }
        if (Time.timeScale == 0)
        {
            if (ates)
            {
                ates = false;
                
            }
            if (muzzleobjmp5.activeSelf||muzzleobjm4a1.activeSelf)
            {
                muzzleobjm4a1.SetActive(false);
                muzzleobjmp5.SetActive(false);
            }
            camval = 1;
        }
    }
      private IEnumerator ShotEffect()
    {
        gunAudio.clip = shotclip;
        gunAudio.Play();          
        laserLine.enabled = true;
        yield return shotDuration;
        laserLine.enabled = false;

    }
    private IEnumerator ReloadEffect()
    {
    
             rms.rreload = true;
        reload = true;
        gunAudio.clip = reloadclip;
        gunAudio.Play();
        yield return new WaitForSeconds(3f);
                reload = false;
        rms.rreload = false;
        
    }
    private IEnumerator NoAmmoEffect()
    {
        gunAudio.clip = noammoclip;
        gunAudio.Play();
        yield return new WaitForSeconds(1);

    }
    public void m4a1()
    {
        if (Time.time > nextFire)
        {
            muzzleobjm4a1.SetActive(true);
            ammo -= 1;
            ammotext.text = ammo + "/" + totalammo;
            nextFire = Time.time + fireRate;
            StartCoroutine(ShotEffect());
            Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;
            laserLine.SetPosition(0, gunEndm4a1.position);
            if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, weaponRange))
            {
                laserLine.SetPosition(1, hit.point);
                ShootedEnemy health = hit.collider.GetComponent<ShootedEnemy>();
                if (health != null)
                {
                    gunDamage = Random.Range(m4a1damage1,m4a1damage2);
                    health.Damage(gunDamage);
                }
                if (hit.rigidbody != null)
                {
                    hit.rigidbody.AddForce(-hit.normal * hitForce);
                }
            }
            else
            {
                laserLine.SetPosition(1, rayOrigin + (fpsCam.transform.forward * weaponRange));
            }
        }
    }
    public void mp5()
    {
        if (Time.time > nextFire)
        {
            muzzleobjmp5.SetActive(true);
            ammo -= 1;
            ammotext.text = ammo + "/" + totalammo;
            nextFire = Time.time + fireRate;
            StartCoroutine(ShotEffect());
            Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;
            laserLine.SetPosition(0, gunEndmp5.position);
            if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, weaponRange))
            {
                laserLine.SetPosition(1, hit.point);
                ShootedEnemy health = hit.collider.GetComponent<ShootedEnemy>();
                if (health != null)
                {
                    gunDamage = Random.Range(mp5damage1,mp5damage2);
                    health.Damage(gunDamage);
                }
                if (hit.rigidbody != null)
                {
                    hit.rigidbody.AddForce(-hit.normal * hitForce);
                }
            }
            else
            {
                laserLine.SetPosition(1, rayOrigin + (fpsCam.transform.forward * weaponRange));
            }
        }
    }
    public void knife()
    {
       
        gunAudio.PlayOneShot(knifeclip);
            Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;
            laserLine.SetPosition(0, gunEndKnife.position);
            if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, weaponRange))
            {
                laserLine.SetPosition(1, hit.point);
                ShootedEnemy health = hit.collider.GetComponent<ShootedEnemy>();
                if (health != null)
                {
                    gunDamage = Random.Range(combatknifedamage1, combatknifedamage2);
                    health.Damage(gunDamage);
                }
                if (hit.rigidbody != null)
                {
                    hit.rigidbody.AddForce(-hit.normal * hitForce);
                }
            }
            else
            {
                laserLine.SetPosition(1, rayOrigin + (fpsCam.transform.forward * weaponRange));
            }
            }
        }
    
