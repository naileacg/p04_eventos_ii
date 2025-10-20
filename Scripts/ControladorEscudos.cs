using UnityEngine;

public class ControladorEscudos : MonoBehaviour
{
  public delegate void HumanoidCollisionEvent(string collidedType);
  public static event HumanoidCollisionEvent OnHumanoidCollision;

  private void OnCollisionEnter(Collision collision)
  {
    if (collision.gameObject.CompareTag("Tipo1"))
    {
      OnHumanoidCollision?.Invoke("Tipo1");
    }
    else if (collision.gameObject.CompareTag("Tipo2"))
    {
      OnHumanoidCollision?.Invoke("Tipo2");
    }
  }
}
