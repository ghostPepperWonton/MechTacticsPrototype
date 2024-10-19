using UnityEngine;

namespace Parts
{
  [CreateAssetMenu(fileName = "Base", menuName = "Parts/Base")]
  public class Base : Part
  {
    public enum BaseType
    {
      Legs,
      Tripod,
      Quaduped,
      Bike,
      Car,
      Tank
    }

    public int weight;
    public int limit;
    public BaseType baseType;
    public int mobility;
    public int speed;
  }
}
