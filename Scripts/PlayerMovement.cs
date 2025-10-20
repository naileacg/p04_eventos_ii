using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  // de la práctica anterior
  public float speed = 5;
  private Rigidbody rigid_body;

  void Start()
  {
    rigid_body = GetComponent<Rigidbody>();
  }

  void FixedUpdate()
  {
    float move_horizontal = Input.GetAxis("Horizontal");
    float move_vertical = Input.GetAxis("Vertical");

    Vector3 movement = new Vector3(move_horizontal, 0, move_vertical) * speed;
    rigid_body.MovePosition(rigid_body.position + movement * Time.fixedDeltaTime);
  }
}