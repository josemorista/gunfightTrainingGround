using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchWeapons : MonoBehaviour
{
  public int selectedWeapon = 0;
  void selectWeapon()
  {
    int i = 0;
    foreach (Transform weapon in transform)
    {
      if (i == selectedWeapon)
      {
        weapon.gameObject.SetActive(true);
      }
      else
      {
        weapon.gameObject.SetActive(false);
      }
      i++;
    }
  }

  void checkUpdates()
  {
    int previousWeapon = selectedWeapon;
    if (Input.GetButtonDown("Weapon 1"))
    {
      selectedWeapon = 0;
    }
    else if (Input.GetButtonDown("Weapon 2"))
    {
      selectedWeapon = 1;
    }
    else if (Input.GetButtonDown("Weapon 3"))
    {
      selectedWeapon = 2;
    }

    if (Input.GetAxis("Mouse ScrollWheel") > 0f)
    {
      if (selectedWeapon >= transform.childCount - 1)
      {
        selectedWeapon = 0;
      }
      else
      {
        selectedWeapon++;
      }
    }

    if (Input.GetAxis("Mouse ScrollWheel") < 0f)
    {
      if (selectedWeapon <= 0)
      {
        selectedWeapon = transform.childCount - 1;
      }
      else
      {
        selectedWeapon--;
      }
    }

    if (selectedWeapon != previousWeapon)
    {
      selectWeapon();
    }
  }

  // Start is called before the first frame update
  void Start()
  {
    selectWeapon();
  }

  // Update is called once per frame
  void Update()
  {
    checkUpdates();
  }
}
