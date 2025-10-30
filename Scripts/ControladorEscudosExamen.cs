using UnityEngine;

// Modificación: A partir de la escena del ejercicio 3 construye una escena en la que exista sólo un guerrero 
// de tipo 1 y otro de tipo 2. Ahora debes tener un grupo de escudos Tipo 1 y otro grupo de objetos Tipo 2:
// - Cuando el cubo alcanza al guerrero de tipo 1, los escudos de tipo 1 se agrupan y los de tipo 2 cambian de color.
// - Cuando el cubo llega al guerrero de tipo 2, los escudos de tipo 1 se alejan radialmente del objeto de tipo 1 y los de tipo 2 aumentan de tamaño.

public class ControladorEscudosExamen : MonoBehaviour
{
  public delegate void HumanoidCollisionEventExam(string collidedType);
  public static event HumanoidCollisionEventExam OnHumanoidCollisionExam;

  private void OnCollisionEnter(Collision collision)
  {
    if (collision.gameObject.CompareTag("Tipo1"))
    {
      OnHumanoidCollisionExam?.Invoke("Tipo1");
    }
    else if (collision.gameObject.CompareTag("Tipo2"))
    {
      OnHumanoidCollisionExam?.Invoke("Tipo2");
    }
  }
}
