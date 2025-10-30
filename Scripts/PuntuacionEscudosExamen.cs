using UnityEngine;

// Modificación: al llegar a la puntuación de 100, los escudos de tipo 1 se 
// teletrasporten a otra zona de la escena y el guerrero de tipo 1 se dirija 
// hacia el guerrero de tipo 2. El cubo y el guerrero tipo 1 deben tener físicas.

public class PuntuacionEscudosExamen : MonoBehaviour
{
  public float move_force = 20;
  private int score = 0;

  private void OnTriggerEnter(Collider other)
  {
    if (other.CompareTag("Escudo1"))
    {
      score += 5;
      Debug.Log($"Escudo 1 recogido. Puntuación total: {score}");
      Destroy(other.gameObject);
    }
    else if (other.CompareTag("Escudo2"))
    {
      score += 10;
      Debug.Log($"Escudo 2 recogido. Puntuación total: {score}");
      Destroy(other.gameObject);
    }

    if (score >= 100)
    {
      // Teletransportar los escudos de tipo 1
      GameObject[] type1_shields = GameObject.FindGameObjectsWithTag("Escudo1");
      foreach (GameObject current_shield in type1_shields)
      {
        // ponemos la nueva posicion para que se genere en posiciones random dependiendo del tamaño del plano
        Vector3 new_position = new Vector3(Random.Range(410, 455), 1, Random.Range(113, 140));
        current_shield.transform.position = new_position;
        Debug.Log("Escudo " + current_shield.name + " teletransportado a " + current_shield.transform.position);
      }

      // El humanoide tipo 1 irá al de tipo 2
      GameObject humanoid1 = GameObject.FindGameObjectWithTag("Tipo1");
      GameObject humanoid2 = GameObject.FindGameObjectWithTag("Tipo2");
      Rigidbody rb = humanoid1.GetComponent<Rigidbody>();
      rb.freezeRotation = true; // para que el humanoide no se caiga en lo que va al tipo 2
      Vector3 direction = (humanoid2.transform.position - humanoid1.transform.position).normalized;
      rb.AddForce(direction * move_force, ForceMode.Impulse); // usamos el addforce para que se "empuje"
    }
  }
}
