using UnityEngine;

namespace Parts
{
  [CreateAssetMenu(fileName = "Core", menuName = "Parts/Core")]
  public class Core : Part
  {
    public int weight;
    public int limit;
    public int armor;
    public int integrity;
    public int hardpoints;
  }
}
