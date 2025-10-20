using UnityEngine;
using System.Collections;

public class ControladorEsferas : MonoBehaviour
{
  public Transform type1_type2; // esfera tipo 1 va a la esfera tipo 2
  public Transform type2_cylinder; // esfera tipo 2 va al cilindro
  public float speed = 3;
  private string sphere_type;
  private bool should_move = false;
  private Vector3 target_position;

  private void Start()
  {
    sphere_type = gameObject.tag;
    // Suscribimos la esfera al evento del cilindro
    ControladorCilindro.OnCylinderCollision += onCylinderCollisionReceived;
  }

  // Método que se va a ejecutar cuando se reciba el evento
  private void onCylinderCollisionReceived()
  {
    Debug.Log($"{name} de {sphere_type} ha recibido el evento");
    if (sphere_type == "Tipo1" && type1_type2 != null)
    {
      target_position = type1_type2.position;
      should_move = true;
    }
    else if (sphere_type == "Tipo2" && type2_cylinder != null)
    {
      target_position = type2_cylinder.position;
      should_move = true;
    }
  }


  private void Update()
  {
    if (!should_move) return;
    transform.position = Vector3.MoveTowards(transform.position, target_position, speed * Time.deltaTime);
    if (Vector3.Distance(transform.position, target_position) < 0.1)
    {
      should_move = false;
    }
  }
}
