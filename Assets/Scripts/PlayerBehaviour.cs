using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
  CharacterController player;
  public float speed = 10.0f, gravity = 9.8f, jumpHeight = 1f;
  private float xMovement = 0f, yMovement = 0f, zMovement = 0f;
  // Start is called before the first frame update
  void Start()
  {
    player = GetComponent<CharacterController>();
  }

  // Update is called once per frame
  void Update()
  {
    if (player.isGrounded)
    {
      xMovement = Input.GetAxis("Horizontal");
      zMovement = Input.GetAxis("Vertical");
      if (Input.GetButtonDown("Jump"))
      {
        yMovement = Mathf.Sqrt(jumpHeight * 2 * gravity);
      }
    }
    else
    {
      yMovement -= gravity * Time.deltaTime;
    }
    Vector3 moveDirection = transform.right * xMovement + transform.up * yMovement + transform.forward * zMovement;
    player.Move(moveDirection * speed * Time.deltaTime);
  }
}
