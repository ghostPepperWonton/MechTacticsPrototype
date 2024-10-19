using UnityEngine;

namespace Parts
{
  [CreateAssetMenu(fileName = "Generator", menuName = "Parts/Generator")]
  public class Generator : Part
  {
    public int battery;
    public int recharge;
  }
}
