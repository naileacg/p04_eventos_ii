using UnityEngine;

public class TeletransporteEscena : MonoBehaviour
{
  public Transform reference_object;
  public float trigger_distance = 3;

  private void Update()
  {
    if (reference_object == null) return;

    GameObject[] shields1 = GameObject.FindGameObjectsWithTag("Escudo1");
    GameObject[] type1_objects = GameObject.FindGameObjectsWithTag("Tipo1");

    foreach (var shield in shields1)
    {
      float distance = Vector3.Distance(reference_object.position, shield.transform.position);
      if (distance <= trigger_distance)
      {
        foreach (var current_object in type1_objects)
          current_object.transform.position = shield.transform.position;
      }
    }

    GameObject[] shields2 = GameObject.FindGameObjectsWithTag("Escudo2");
    GameObject[] type2_objects = GameObject.FindGameObjectsWithTag("Tipo2");

    foreach (var shield in shields2)
    {
      float distance = Vector3.Distance(reference_object.position, shield.transform.position);
      if (distance <= trigger_distance)
      {
        foreach (var current_object in type2_objects)
          current_object.transform.position = shield.transform.position;
      }
    }
  }
}
