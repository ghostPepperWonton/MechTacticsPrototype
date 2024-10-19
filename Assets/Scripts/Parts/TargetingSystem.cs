using UnityEngine;

namespace Parts
{
  [CreateAssetMenu(fileName = "Targeting System", menuName = "Parts/Targeting System")]
  public class TargetingSystem : Part
  {
    public enum TargetingSystemType
    {
      ShortRange,
      LongRange
    }

    public int maxRange;
    public int targetRange;
    public TargetingSystemType targetingSystemType;
  }
}
