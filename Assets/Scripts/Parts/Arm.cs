using UnityEngine;

namespace Parts
{
  [CreateAssetMenu(fileName = "Arm", menuName = "Parts/Arm")]
  public class Arm : Part
  {
    public int weight;
    public int limit;
  }
}
