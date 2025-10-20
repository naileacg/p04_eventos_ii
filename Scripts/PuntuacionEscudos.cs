using UnityEngine;

public class PuntuacionEscudos : MonoBehaviour
{
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
  }
}
