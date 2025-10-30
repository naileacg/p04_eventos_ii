using UnityEngine;

// Modificación: A partir de la escena del ejercicio 3 construye una escena en la que exista sólo un guerrero 
// de tipo 1 y otro de tipo 2. Ahora debes tener un grupo de escudos Tipo 1 y otro grupo de objetos Tipo 2:
// - Cuando el cubo alcanza al guerrero de tipo 1, los escudos de tipo 1 se agrupan y los de tipo 2 cambian de color.
// - Cuando el cubo llega al guerrero de tipo 2, los escudos de tipo 1 se alejan radialmente del objeto de tipo 1 y los de tipo 2 aumentan de tamaño.

public class ControladorHumanoidesExamen : MonoBehaviour
{
  public Transform shield1;
  public Transform shield2;
  private string humanoid_type;
  private Vector3 target_position;

  private void Start()
  {
    humanoid_type = gameObject.tag;
    ControladorEscudosExamen.OnHumanoidCollisionExam += onHumanoidCollisionReceivedExam;
  }

  private void onHumanoidCollisionReceivedExam(string collided_type)
  {
    // Si el cubo colisiona con un tipo 1 → los escudos de tipo 1 se agrupan y los de tipo 2 cambian de color
    if (collided_type == "Tipo1" && humanoid_type == "Tipo1" && shield1 != null)
    {
      GameObject[] type1_shields = GameObject.FindGameObjectsWithTag("Escudo1");
      Vector3 group_position = shield1.position;
      foreach (var current_shield in type1_shields)
      {
        current_shield.transform.position = group_position;
        Debug.Log("Posición del " + current_shield.name + " modificada a " + current_shield.transform.position);
      }
      GameObject[] type2_shields = GameObject.FindGameObjectsWithTag("Escudo2");
      foreach (var current_shield in type2_shields)
      {
        Renderer rend = current_shield.GetComponent<Renderer>();
        rend.material.color = Color.red;
      }
    }

    // Si el cubo colisiona con un tipo 2 → los escudos de tipo 1 se alejan radialmente del objeto de tipo 1 y los de tipo 2 aumentan de tamaño.
    if (collided_type == "Tipo2" && humanoid_type == "Tipo2")
    {
      GameObject type1_humanoid = GameObject.FindGameObjectWithTag("Tipo1");
      Vector3 origin = type1_humanoid.transform.position;
      float distance = 5;
      GameObject[] type1_shields = GameObject.FindGameObjectsWithTag("Escudo1");
      foreach (var current_shield in type1_shields)
      {
        Vector3 direction = (current_shield.transform.position - origin).normalized;
        current_shield.transform.position = origin + direction * distance;
      }
      GameObject[] type2_shields = GameObject.FindGameObjectsWithTag("Escudo2");
      Vector3 new_scale = new Vector3(2, 2, 2);
      foreach (var current_shield in type2_shields)
      {
        current_shield.transform.localScale = Vector3.Scale(current_shield.transform.localScale, new_scale);
      }
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
