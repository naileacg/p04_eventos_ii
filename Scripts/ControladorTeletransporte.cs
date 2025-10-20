using UnityEngine;

public class ControladorTeletransporte : MonoBehaviour
{
  public Transform reference_object;
  public Transform shield1;
  public Transform shield2;
  public float trigger_distance = 3;

  private void Update()
  {
    float distance = Vector3.Distance(transform.position, reference_object.position);
    if (distance <= trigger_distance)
    {
      // Teletransportar tipo 1 al escudo 1
      GameObject[] type1_objects = GameObject.FindGameObjectsWithTag("Tipo1");
      foreach (var current_object in type1_objects)
      {
        if (shield1 != null)
          current_object.transform.position = shield1.position;
      }

      // Que tipo 2 mire al escudo 2
      GameObject[] tipo2_objects = GameObject.FindGameObjectsWithTag("Tipo2");
      foreach (var current_object in tipo2_objects)
      {
        if (shield2 != null)
          current_object.transform.LookAt(shield2.position);
      }
    }
  }
}
