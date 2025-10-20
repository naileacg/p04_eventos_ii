using UnityEngine;
using TMPro;

public class Contador100 : MonoBehaviour
{
  private int score = 0;
  public TMP_Text score_text;
  public TMP_Text reward_text;
  private int next_reward = 100;

  private void Start()
  {
    UpdateScore();
    if (reward_text != null)
      reward_text.text = "";
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
    CheckReward();
  }

  private void UpdateScore()
  {
    score_text.text = "Puntuación: " + score;
  }

  private void CheckReward()
  {
    if (score >= next_reward && reward_text != null)
    {
      reward_text.text = "¡Recompensa de 100 puntos obtenida!";
      next_reward += 100;
      Invoke("ClearRewardText", 3);
    }
  }

  private void ClearRewardText()
  {
    if (reward_text != null)
      reward_text.text = "";
  }
}
