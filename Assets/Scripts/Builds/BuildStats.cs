using Parts;
using System.Collections.Generic;
using System.Linq;

namespace Builds
{
  public class BuildStats
  {
    public enum Status
    {
      Ok,
      Error
    }

    public Build build;

    public BuildStats(Build build)
    {
      this.build = build;
    }

    public int Cost()
    {
      int cost = 0;

      if (build.@base != null)
      {
        cost += build.@base.cost;
      }
      if (build.@core != null)
      {
        cost += build.@core.cost;
      }
      if (build.leftArm != null)
      {
        cost += build.leftArm.cost;
      }
      if (build.rightArm != null)
      {
        cost += build.rightArm.cost;
      }
      if (build.@targetingSystem != null)
      {
        cost += build.@targetingSystem.cost;
      }
      if (build.@generator != null)
      {
        cost += build.@generator.cost;
      }
      if (build.@radiator != null)
      {
        cost += build.@radiator.cost;
      }
      if (build.@booster != null)
      {
        cost += build.@booster.cost;
      }

      foreach (var weapon in build.weapons)
      {
        cost += weapon.cost;
      }
      foreach (var option in build.options)
      {
        cost += option.cost;
      }

      return cost;
    }

    public int Weight()
    {
      int weight = 0;

      if (build.@base != null)
      {
        weight += build.@base.weight;
      }
      if (build.@core != null)
      {
        weight += build.@core.weight;
      }
      if (build.leftArm != null)
      {
        weight += build.leftArm.weight;
      }
      if (build.rightArm != null)
      {
        weight += build.rightArm.weight;
      }

      foreach (var weapon in build.weapons)
      {
        weight += weapon.weight;
      }
      foreach (var option in build.options)
      {
        weight += option.weight;
      }

      return weight;
    }

    public int Armor()
    {
      int armor = 0;

      if (build.@base != null)
      {
        armor += build.@base.armor;
      }
      if (build.@core != null)
      {
        armor += build.@core.armor;
      }

      return armor;
    }

    public int Mobility()
    {
      return build.@base == null ? 0 : build.@base.mobility;
    }

    public int Speed()
    {
      return build.@base == null ? 0 : build.@base.speed;
    }

    public int Integrity()
    {
      return build.@core == null ? 0 : build.@core.integrity;
    }

    public int MaxRange()
    {
      List<int> maxRanges = new();

      if (build.@targetingSystem != null)
      {
        maxRanges.Add(build.@targetingSystem.maxRange);
      }
      foreach (var weapon in build.weapons)
      {
        maxRanges.Add(weapon.maxRange);
      }

      return maxRanges.Count == 0 ? 0 : maxRanges.Min();
    }

    public int Battery()
    {
      return build.@generator == null ? 0 : build.@generator.battery;
    }

    public int Recharge()
    {
      return build.@generator == null ? 0 : build.@generator.recharge;
    }

    public int HeatCapacity()
    {
      return build.@radiator == null ? 0 : build.@radiator.heatCapacity;
    }

    public int Ventilation()
    {
      return build.@radiator == null ? 0 : build.@radiator.ventilation;
    }

    public int Overload()
    {
      return build.@radiator == null ? 0 : build.@radiator.overload;
    }

    public int Evasion()
    {
      return build.@booster == null ? 0 : build.@booster.evasion;
    }

    public int AvailableHardpoints()
    {
      if (build.@core == null)
      {
        return 0;
      }

      int usedHardpoints = 0;

      foreach (var option in build.options)
      {
        usedHardpoints += option.hardpoints;
      }

      return build.@core.hardpoints - usedHardpoints;
    }

    public int RemainingBaseLimit()
    {
      if (build.@base == null)
      {
        return 0;
      }

      int usedLimit = 0;

      if (build.@core != null)
      {
        usedLimit += build.@core.weight;
      }
      if (build.leftArm != null)
      {
        usedLimit += build.leftArm.weight;
      }
      if (build.rightArm != null)
      {
        usedLimit += build.rightArm.weight;
      }

      foreach (var weapon in build.weapons)
      {
        usedLimit += weapon.weight;
      }
      foreach (var option in build.options)
      {
        usedLimit += option.weight;
      }

      return build.@base.limit - usedLimit;
    }

    public int RemainingCoreLimit()
    {
      if (build.@core == null)
      {
        return 0;
      }

      int usedLimit = 0;

      if (build.leftArm != null)
      {
        usedLimit += build.leftArm.weight;
      }
      if (build.rightArm != null)
      {
        usedLimit += build.rightArm.weight;
      }

      foreach (var weapon in build.weapons)
      {
        usedLimit += weapon.weight;
      }
      foreach (var option in build.options)
      {
        usedLimit += option.weight;
      }

      return build.@core.limit - usedLimit;
    }

    public int RemainingLeftArmLimit()
    {
      if (build.leftArm == null)
      {
        return 0;
      }

      int usedLimit = 0;

      foreach (var weapon in build.weapons)
      {
        if (weapon.mountType == Weapon.MountType.Arm && weapon.mountSide == Weapon.MountSide.Left)
        {
          usedLimit += weapon.weight;
        }
      }

      return build.leftArm.limit - usedLimit;
    }

    public int RemainingRightArmLimit()
    {
      if (build.rightArm == null)
      {
        return 0;
      }

      int usedLimit = 0;

      foreach (var weapon in build.weapons)
      {
        if (weapon.mountType == Weapon.MountType.Arm && weapon.mountSide == Weapon.MountSide.Right)
        {
          usedLimit += weapon.weight;
        }
      }

      return build.rightArm.limit - usedLimit;
    }

    public (Status BuildStatus, List<string> Errors) MissingPartCheck()
    {
      List<string> errors = new();

      if (build.@base == null)
      {
        errors.Add("Missing base");
      }
      if (build.@core == null)
      {
        errors.Add("Missing core");
      }
      if (build.leftArm == null)
      {
        errors.Add("Missing left arm");
      }
      if (build.rightArm == null)
      {
        errors.Add("Missing right arm");
      }
      if (build.@targetingSystem == null)
      {
        errors.Add("Missing targeting system");
      }
      if (build.@generator == null)
      {
        errors.Add("Missing generator");
      }
      if (build.@radiator == null)
      {
        errors.Add("Missing radiator");
      }
      if (build.@booster == null)
      {
        if (build.@base == null || build.@base.baseType != Base.BaseType.Tank)
        {
          errors.Add("Missing booster");
        }
      }
      if (build.weapons.Count == 0)
      {
        errors.Add("Missing weapons");
      }

      if (errors.Count > 0)
      {
        return (Status.Error, errors);
      }

      return (Status.Ok, errors);
    }

    public (Status BuildStatus, List<string> Errors) BudgetCheck(int budget)
    {
      List<string> errors = new();

      if (Cost() > budget)
      {
        int difference = Cost() - budget;
        errors.Add("Budget exceeded by " + difference + " " + Utils.Pluralize("credit", difference));
        return (Status.Error, errors);
      }

      return (Status.Ok, errors);
    }

    public (Status BuildStatus, List<string> Errors) HardpointCheck()
    {
      List<string> errors = new();

      if (build.@core == null)
      {
        errors.Add("No core");
        return (Status.Error, errors);
      }

      int available = AvailableHardpoints();
      if (available < 0)
      {
        errors.Add("Hardpoints exceeded by " + (-available).ToString());
        return (Status.Error, errors);
      }

      return (Status.Ok, errors);
    }

    public (Status BuildStatus, List<string> Errors) BaseLimitCheck()
    {
      List<string> errors = new();

      if (build.@base == null)
      {
        errors.Add("No base");
        return (Status.Error, errors);
      }

      int remaining = RemainingBaseLimit();
      if (remaining < 0)
      {
        errors.Add("Base limit exceeded by " + (-remaining).ToString());
        return (Status.Error, errors);
      }

      return (Status.Ok, errors);
    }

    public (Status BuildStatus, List<string> Errors) CoreLimitCheck()
    {
      List<string> errors = new();

      if (build.@core == null)
      {
        errors.Add("No core");
        return (Status.Error, errors);
      }

      int remaining = RemainingCoreLimit();
      if (remaining < 0)
      {
        errors.Add("Core limit exceeded by " + (-remaining).ToString());
        return (Status.Error, errors);
      }

      return (Status.Ok, errors);
    }

    public (Status BuildStatus, List<string> Errors) LeftArmLimitCheck()
    {
      List<string> errors = new();

      if (build.leftArm == null)
      {
        errors.Add("No left arm");
        return (Status.Error, errors);
      }

      int remaining = RemainingLeftArmLimit();
      if (remaining < 0)
      {
        errors.Add("Left arm limit exceeded by " + (-remaining).ToString());
        return (Status.Error, errors);
      }

      return (Status.Ok, errors);
    }

    public (Status BuildStatus, List<string> Errors) RightArmLimitCheck()
    {
      List<string> errors = new();

      if (build.rightArm == null)
      {
        errors.Add("No right arm");
        return (Status.Error, errors);
      }

      int remaining = RemainingRightArmLimit();
      if (remaining < 0)
      {
        errors.Add("Right arm limit exceeded by " + (-remaining).ToString());
        return (Status.Error, errors);
      }

      return (Status.Ok, errors);
    }
  }
}
