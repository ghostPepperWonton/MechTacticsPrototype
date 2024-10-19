using UnityEngine;

namespace Parts
{
  [CreateAssetMenu(fileName = "Radiator", menuName = "Parts/Radiator")]
  public class Radiator : Part
  {
    public int heatCapacity;
    public int ventilation;
    public int overload;
  }
}
