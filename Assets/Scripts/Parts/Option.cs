using UnityEngine;

namespace Parts
{
  [CreateAssetMenu(fileName = "Option", menuName = "Parts/Option")]
  public class Option : Part
  {
    public enum OptionType
    {
      Active,
      Passive,
      Triggered
    }

    public OptionType optionType;
    public int weight;
    public int hardpoints;
    public int energyCost;
    public int heatBuildup;
    public string benefit;
  }
}
