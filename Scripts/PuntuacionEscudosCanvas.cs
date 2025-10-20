using UnityEngine;
using TMPro;

public class PuntuacionEscudosCanvas : MonoBehaviour
{
  private int score = 0;
  public TMP_Text score_text;
  private void Start()
  {
    UpdateScore();
  }

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

    UpdateScore();
  }

  private void UpdateScore()
  {
    score_text.text = "Puntuación: " + score;
  }
}
