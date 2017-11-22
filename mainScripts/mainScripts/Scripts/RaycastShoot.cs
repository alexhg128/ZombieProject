using UnityEngine;
using System.Collections;

public class RaycastShoot : MonoBehaviour
{

    public int gunDamage = 1;
    public float fireRate = 0.20f;
    public float weaponRange = 100f;
    public float hitForce = 100f;
    public Transform gunEnd;
    public Transform rayEnd;

    private Camera fpsCam;
    private WaitForSeconds shotDuration = new WaitForSeconds(0.07f);
    private AudioSource gunAudio;
    private LineRenderer laserLine;
    private float nextFire;

	void Start ()
    {
        gunEnd = transform.Find("GunEnd");
        rayEnd = transform.Find("RayEnd");
        laserLine = GetComponent<LineRenderer>();
        gunAudio = GetComponent<AudioSource>();
        fpsCam = GetComponentInParent<Camera>();
        laserLine.material = new Material(Shader.Find("Particles/Additive"));
        laserLine.SetColors(Color.red, Color.red);
    }
	
	void Update ()
    {
        
	    if (IsFiring())
        {
            nextFire = Time.time + fireRate;
            StartCoroutine(ShotEffect());
            Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;
            
            laserLine.SetPosition(0, gunEnd.position);
            laserLine.SetPosition(1, rayEnd.position);
            if(Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, weaponRange))
            {
                ShootableZombie health = hit.collider.GetComponent<ShootableZombie>();

                // If there was a health script attached
                if (health != null)
                {
                    // Call the damage function of that script, passing in our gunDamage variable
                    health.Damage(gunDamage);
                }

                // Check if the object we hit has a rigidbody attached
                if (hit.rigidbody != null)
                {
                    // Add force to the rigidbody we hit, in the direction from which it was hit
                    hit.rigidbody.AddForce(-hit.normal * hitForce);
                }
            }
            /*else
            {
                laserLine.SetPosition(1, rayOrigin + (fpsCam.transform.forward * weaponRange));
            }*/
        }
	}

    private IEnumerator ShotEffect()
    {
        gunAudio.Play();
        laserLine.enabled = true;
        yield return shotDuration;
        laserLine.enabled = false;
    }

    private bool IsFiring()
    {
        if (Input.GetButtonDown("Fire1") && Time.time > nextFire)
        {
            return true;
        }
        if(Input.GetAxis("FireTrigger") > 0 && Time.time > nextFire)
        {
            return true;
        }
        return false;
    }
}
