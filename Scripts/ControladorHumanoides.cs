using UnityEngine;

public class ControladorHumanoides : MonoBehaviour
{
  public Transform shield1; // Tipo 1 va al escudo 1
  public Transform shield2; // Tipo 2 va al escudo 2
  public float speed = 3;
  private string humanoid_type;
  private bool should_move = false;
  private Vector3 target_position;

  private void Start()
  {
    humanoid_type = gameObject.tag;
    // Suscribimos la esfera al evento del cubo
    ControladorEscudos.OnHumanoidCollision += onHumanoidCollisionReceived;
  }

  private void onHumanoidCollisionReceived(string collided_type)
  {
    // Si el cubo colisiona con un tipo 2 → tipo 1 se mueve al escudo 1
    if (collided_type == "Tipo2" && humanoid_type == "Tipo1" && shield1 != null)
    {
      target_position = shield1.position;
      should_move = true;
    }
    // Si el cubo colisiona con un tipo 1 → tipo 2 se mueve al escudo 2
    else if (collided_type == "Tipo1" && humanoid_type == "Tipo2" && shield2 != null)
    {
      target_position = shield2.position;
      should_move = true;
    }
  }

  private void Update()
  {
    if (!should_move) return;
    transform.position = Vector3.MoveTowards(transform.position, target_position, speed * Time.deltaTime);
    if (Vector3.Distance(transform.position, target_position) < 0.1f)
    {
      should_move = false;
    }
  }

  private void OnTriggerEnter(Collider other)
  {
    if (other.CompareTag("Escudo1") || other.CompareTag("Escudo2"))
    {
      Renderer rend = GetComponentInChildren<Renderer>();
      if (humanoid_type == "Tipo1")
      {
        rend.material.color = Color.red;
      }
      else if (humanoid_type == "Tipo2")
      {
        rend.material.color = Color.yellow;
      }
    }
  }
}
