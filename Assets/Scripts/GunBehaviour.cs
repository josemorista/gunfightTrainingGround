using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBehaviour : MonoBehaviour
{
  public Rigidbody bullet;

  public int currentAmmo = 30, maxAmmo = 90, clipSize = 30;
  public float bulletSpeed = 10f, fireRate = 25f, timeToReload = 2f;
  private float nextBulletTime = 0f, reloadingTime = 0f;
  public bool auto = true;

  private bool reloading = false;
  // Start is called before the first frame update
  void Start()
  {
    currentAmmo = clipSize;
  }

  void Reload()
  {
    if (maxAmmo - clipSize > 0)
    {
      currentAmmo = clipSize;
      maxAmmo -= clipSize;
    }
    else
    {
      currentAmmo = maxAmmo;
      maxAmmo = 0;
    }
  }

  void Shoot()
  {
    currentAmmo--;
    Rigidbody newBullet = Instantiate(bullet, transform.position, transform.rotation);
    newBullet.transform.Rotate(new Vector3(90f, 0f, 0f));
    newBullet.velocity = transform.right * 0 + transform.up * 0 + transform.forward * bulletSpeed;
  }

  // Update is called once per frame
  void Update()
  {
    if (auto && Input.GetButton("Fire1") && Time.time > nextBulletTime)
    {
      nextBulletTime = Time.time + 1f / fireRate;
      if (currentAmmo > 0)
      {
        Shoot();
      }
    }
    if (!auto && Input.GetButtonDown("Fire1") && Time.time > nextBulletTime)
    {
      nextBulletTime = Time.time + 1f / fireRate;
      if (currentAmmo > 0)
      {
        Shoot();
      }
    }
    if (!reloading && Input.GetButtonDown("Reload") && currentAmmo < clipSize)
    {
      Debug.Log("Reloading...");
      reloading = true;
      currentAmmo = 0;
      reloadingTime = timeToReload + Time.time;
    }

    if (reloading && Time.time > reloadingTime)
    {
      reloading = false;
      Reload();
      Debug.Log("Reloaded");
    }

  }
}
