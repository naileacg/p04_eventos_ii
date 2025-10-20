using UnityEngine;

public class ControladorCilindro : MonoBehaviour
{
  public delegate void CubeCollisionEvent();
  public static event CubeCollisionEvent OnCylinderCollision;

  private void OnCollisionEnter(Collision collision)
  {
    if (collision.gameObject.CompareTag("Cubo"))
    {
      Debug.Log("El cubo ha chocado con el cilindro");
      OnCylinderCollision?.Invoke();
    }
  }
}
