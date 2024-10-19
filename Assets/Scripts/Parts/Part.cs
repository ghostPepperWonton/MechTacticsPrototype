using UnityEngine;

namespace Parts
{
  public class Part : ScriptableObject
  {
    public enum PartType
    {
      Base,
      Core,
      Arm,
      TargetingSystem,
      Generator,
      Radiator,
      Booster,
      Weapon,
      Option
    }

    public string id;
    public string displayName;
    public string manufacturer;
    public int cost;
    public PartType partType;
  }
}
