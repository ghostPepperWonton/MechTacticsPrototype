using UnityEngine;

namespace Parts
{
  [CreateAssetMenu(fileName = "Booster", menuName = "Parts/Booster")]
  public class Booster : Part
  {
    public int energyCost;
    public int heatBuildup;
    public int evasion;
  }
}
