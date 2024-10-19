using UnityEngine;

namespace Parts
{
  [CreateAssetMenu(fileName = "Weapon", menuName = "Parts/Weapon")]
  public class Weapon : Part
  {
    public enum WeaponType
    {
      Punch,
      Lance,
      Slash,
      Handgun,
      Shotgun,
      Smg,
      Rifle,
      GattlingGun,
      Sniper,
      Rocket,
      Missile,
      Mortar,
      Mine
    }

    public enum MountType
    {
      Arm,
      Shoulder
    }

    public enum MountSide
    {
      Left,
      Right
    }

    public enum AmmoType
    {
      Kinetic,
      Energy,
      Heat
    }

    public enum RangeType
    {
      ShortRange,
      LongRange
    }

    public WeaponType weaponType;
    public int weight;
    public int energyCost;
    public int heatBuildup;
    public MountType mountType;
    public MountSide mountSide;
    public AmmoType ammoType;
    public int attack;
    public int accuracy;
    public int damage;
    public int maxRange;
    public int targetRange;
    public RangeType rangeType;
  }
}
