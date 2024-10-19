using Builds;
using NUnit.Framework;
using Parts;
using System.Collections.Generic;
using UnityEngine;

public class BuildStatsTest
{
  #region Cost
  [Test]
  public void BuildStats_Cost_ZeroWhenEmpty()
  {
    Build build = ScriptableObject.CreateInstance<Build>();
    BuildStats buildStats = new(build);

    Assert.AreEqual(0, buildStats.Cost());
  }

  [Test]
  public void BuildStats_Cost_IncludesOnlyDraftedParts()
  {
    Build build = ScriptableObject.CreateInstance<Build>();
    build.@base = ScriptableObject.CreateInstance<Base>();
    build.@base.cost = 100;
    BuildStats buildStats = new(build);

    Assert.AreEqual(100, buildStats.Cost());
  }

  [Test]
  public void BuildStats_Cost_ProperlyAddsUpAFullBuild()
  {
    Build build = ScriptableObject.CreateInstance<Build>();

    build.@base = ScriptableObject.CreateInstance<Base>();
    build.@base.cost = 1;

    build.@core = ScriptableObject.CreateInstance<Core>();
    build.@core.cost = 1;

    build.leftArm = ScriptableObject.CreateInstance<Arm>();
    build.leftArm.cost = 1;

    build.rightArm = ScriptableObject.CreateInstance<Arm>();
    build.rightArm.cost = 1;

    build.@targetingSystem = ScriptableObject.CreateInstance<TargetingSystem>();
    build.@targetingSystem.cost = 1;

    build.@generator = ScriptableObject.CreateInstance<Generator>();
    build.@generator.cost = 1;

    build.@radiator = ScriptableObject.CreateInstance<Radiator>();
    build.@radiator.cost = 1;

    build.@booster = ScriptableObject.CreateInstance<Booster>();
    build.@booster.cost = 1;

    build.weapons.Add(ScriptableObject.CreateInstance<Weapon>());
    build.weapons[0].cost = 1;

    build.options.Add(ScriptableObject.CreateInstance<Option>());
    build.options[0].cost = 1;

    BuildStats buildStats = new(build);

    Assert.AreEqual(10, buildStats.Cost());
  }
  #endregion

  #region Weight
  [Test]
  public void BuildStats_Weight_ZeroWhenEmpty()
  {
    Build build = ScriptableObject.CreateInstance<Build>();
    BuildStats buildStats = new(build);

    Assert.AreEqual(0, buildStats.Weight());
  }

  [Test]
  public void BuildStats_Weight_IncludesOnlyDraftedParts()
  {
    Build build = ScriptableObject.CreateInstance<Build>();
    build.@base = ScriptableObject.CreateInstance<Base>();
    build.@base.weight = 100;
    BuildStats buildStats = new(build);

    Assert.AreEqual(100, buildStats.Weight());
  }

  [Test]
  public void BuildStats_Weight_ProperlyAddsUpAFullBuild()
  {
    Build build = ScriptableObject.CreateInstance<Build>();

    build.@base = ScriptableObject.CreateInstance<Base>();
    build.@base.weight = 1;

    build.@core = ScriptableObject.CreateInstance<Core>();
    build.@core.weight = 1;

    build.leftArm = ScriptableObject.CreateInstance<Arm>();
    build.leftArm.weight = 1;

    build.rightArm = ScriptableObject.CreateInstance<Arm>();
    build.rightArm.weight = 1;

    build.weapons.Add(ScriptableObject.CreateInstance<Weapon>());
    build.weapons[0].weight = 1;

    build.options.Add(ScriptableObject.CreateInstance<Option>());
    build.options[0].weight = 1;

    BuildStats buildStats = new(build);

    Assert.AreEqual(6, buildStats.Weight());
  }
  #endregion

  #region Armor
  [Test]
  public void BuildStats_Armor_ZeroWhenEmpty()
  {
    Build build = ScriptableObject.CreateInstance<Build>();
    BuildStats buildStats = new(build);

    Assert.AreEqual(0, buildStats.Armor());
  }

  [Test]
  public void BuildStats_Armor_IncludesOnlyDraftedParts()
  {
    Build build = ScriptableObject.CreateInstance<Build>();

    build.@base = ScriptableObject.CreateInstance<Base>();
    build.@base.armor = 1;

    BuildStats buildStats = new(build);

    Assert.AreEqual(1, buildStats.Armor());
  }

  [Test]
  public void BuildStats_Armor_SumsAllArmorForFullBuild()
  {
    Build build = ScriptableObject.CreateInstance<Build>();

    build.@base = ScriptableObject.CreateInstance<Base>();
    build.@base.armor = 1;

    build.@core = ScriptableObject.CreateInstance<Core>();
    build.@core.armor = 1;

    BuildStats buildStats = new(build);

    Assert.AreEqual(2, buildStats.Armor());
  }
  #endregion

  #region Mobility
  [Test]
  public void BuildStats_Mobility_ZeroWhenEmpty()
  {
    Build build = ScriptableObject.CreateInstance<Build>();
    BuildStats buildStats = new(build);

    Assert.AreEqual(0, buildStats.Mobility());
  }

  [Test]
  public void BuildStats_Mobility_UsesBaseMobility()
  {
    Build build = ScriptableObject.CreateInstance<Build>();

    build.@base = ScriptableObject.CreateInstance<Base>();
    build.@base.mobility = 1;

    BuildStats buildStats = new(build);

    Assert.AreEqual(1, buildStats.Mobility());
  }
  #endregion

  #region Speed
  [Test]
  public void BuildStats_Speed_ZeroWhenEmpty()
  {
    Build build = ScriptableObject.CreateInstance<Build>();
    BuildStats buildStats = new(build);

    Assert.AreEqual(0, buildStats.Speed());
  }

  [Test]
  public void BuildStats_Speed_UsesBaseSpeed()
  {
    Build build = ScriptableObject.CreateInstance<Build>();

    build.@base = ScriptableObject.CreateInstance<Base>();
    build.@base.speed = 1;

    BuildStats buildStats = new(build);

    Assert.AreEqual(1, buildStats.Speed());
  }
  #endregion

  #region Integrity
  [Test]
  public void BuildStats_Integrity_ZeroWhenEmpty()
  {
    Build build = ScriptableObject.CreateInstance<Build>();
    BuildStats buildStats = new(build);

    Assert.AreEqual(0, buildStats.Integrity());
  }

  [Test]
  public void BuildStats_Integrity_UsesCoreIntegrity()
  {
    Build build = ScriptableObject.CreateInstance<Build>();

    build.@core = ScriptableObject.CreateInstance<Core>();
    build.@core.integrity = 1;

    BuildStats buildStats = new(build);

    Assert.AreEqual(1, buildStats.Integrity());
  }
  #endregion

  #region MaxRange
  [Test]
  public void BuildStats_MaxRange_ZeroWhenEmpty()
  {
    Build build = ScriptableObject.CreateInstance<Build>();
    BuildStats buildStats = new(build);

    Assert.AreEqual(0, buildStats.MaxRange());
  }

  [Test]
  public void BuildStats_MaxRange_IncludesOnlyDraftedParts()
  {
    Build build = ScriptableObject.CreateInstance<Build>();

    build.@targetingSystem = ScriptableObject.CreateInstance<TargetingSystem>();
    build.@targetingSystem.maxRange = 1;

    BuildStats buildStats = new(build);

    Assert.AreEqual(1, buildStats.MaxRange());
  }

  [Test]
  public void BuildStats_MaxRange_UsesLowestMaxRangeForFullBuild()
  {
    Build build = ScriptableObject.CreateInstance<Build>();

    build.@targetingSystem = ScriptableObject.CreateInstance<TargetingSystem>();
    build.@targetingSystem.maxRange = 2;

    build.weapons.Add(ScriptableObject.CreateInstance<Weapon>());
    build.weapons[0].maxRange = 1;

    BuildStats buildStats = new(build);

    Assert.AreEqual(1, buildStats.MaxRange());
  }
  #endregion

  #region Battery
  [Test]
  public void BuildStats_Battery_ZeroWhenEmpty()
  {
    Build build = ScriptableObject.CreateInstance<Build>();
    BuildStats buildStats = new(build);

    Assert.AreEqual(0, buildStats.Battery());
  }

  [Test]
  public void BuildStats_Battery_UsesGeneratorBattery()
  {
    Build build = ScriptableObject.CreateInstance<Build>();

    build.@generator = ScriptableObject.CreateInstance<Generator>();
    build.@generator.battery = 1;

    BuildStats buildStats = new(build);

    Assert.AreEqual(1, buildStats.Battery());
  }
  #endregion

  #region Recharge
  [Test]
  public void BuildStats_Recharge_ZeroWhenEmpty()
  {
    Build build = ScriptableObject.CreateInstance<Build>();
    BuildStats buildStats = new(build);

    Assert.AreEqual(0, buildStats.Recharge());
  }

  [Test]
  public void BuildStats_Recharge_UsesGeneratorRecharge()
  {
    Build build = ScriptableObject.CreateInstance<Build>();

    build.@generator = ScriptableObject.CreateInstance<Generator>();
    build.@generator.recharge = 1;

    BuildStats buildStats = new(build);

    Assert.AreEqual(1, buildStats.Recharge());
  }
  #endregion

  #region HeatCapacity
  [Test]
  public void BuildStats_HeatCapacity_ZeroWhenEmpty()
  {
    Build build = ScriptableObject.CreateInstance<Build>();
    BuildStats buildStats = new(build);

    Assert.AreEqual(0, buildStats.HeatCapacity());
  }

  [Test]
  public void BuildStats_HeatCapacity_UsesRadiatorHeatCapacity()
  {
    Build build = ScriptableObject.CreateInstance<Build>();

    build.@radiator = ScriptableObject.CreateInstance<Radiator>();
    build.@radiator.heatCapacity = 1;

    BuildStats buildStats = new(build);

    Assert.AreEqual(1, buildStats.HeatCapacity());
  }
  #endregion

  #region Ventilation
  [Test]
  public void BuildStats_Ventilation_ZeroWhenEmpty()
  {
    Build build = ScriptableObject.CreateInstance<Build>();
    BuildStats buildStats = new(build);

    Assert.AreEqual(0, buildStats.Ventilation());
  }

  [Test]
  public void BuildStats_Ventilation_UsesRadiatorVentilation()
  {
    Build build = ScriptableObject.CreateInstance<Build>();

    build.@radiator = ScriptableObject.CreateInstance<Radiator>();
    build.@radiator.ventilation = 1;

    BuildStats buildStats = new(build);

    Assert.AreEqual(1, buildStats.Ventilation());
  }
  #endregion

  #region Overload
  [Test]
  public void BuildStats_Overload_ZeroWhenEmpty()
  {
    Build build = ScriptableObject.CreateInstance<Build>();
    BuildStats buildStats = new(build);

    Assert.AreEqual(0, buildStats.Overload());
  }

  [Test]
  public void BuildStats_Overload_UsesRadiatorOverload()
  {
    Build build = ScriptableObject.CreateInstance<Build>();

    build.@radiator = ScriptableObject.CreateInstance<Radiator>();
    build.@radiator.overload = 1;

    BuildStats buildStats = new(build);

    Assert.AreEqual(1, buildStats.Overload());
  }
  #endregion

  #region Evasion
  [Test]
  public void BuildStats_Evasion_ZeroWhenEmpty()
  {
    Build build = ScriptableObject.CreateInstance<Build>();
    BuildStats buildStats = new(build);

    Assert.AreEqual(0, buildStats.Evasion());
  }

  [Test]
  public void BuildStats_Evasion_UsesBoosterEvasion()
  {
    Build build = ScriptableObject.CreateInstance<Build>();

    build.@booster = ScriptableObject.CreateInstance<Booster>();
    build.@booster.evasion = 1;

    BuildStats buildStats = new(build);

    Assert.AreEqual(1, buildStats.Evasion());
  }
  #endregion

  #region AvailableHardpoints
  [Test]
  public void BuildStats_AvailableHardpoints_ZeroWhenEmpty()
  {
    Build build = ScriptableObject.CreateInstance<Build>();
    BuildStats buildStats = new(build);

    Assert.AreEqual(0, buildStats.AvailableHardpoints());
  }

  [Test]
  public void BuildStats_AvailableHardpoints_ProperlySubtractsOptionsFromTotal()
  {
    Build build = ScriptableObject.CreateInstance<Build>();

    build.@core = ScriptableObject.CreateInstance<Core>();
    build.@core.hardpoints = 10;

    build.options.Add(ScriptableObject.CreateInstance<Option>());
    build.options[0].hardpoints = 1;

    BuildStats buildStats = new(build);

    Assert.AreEqual(9, buildStats.AvailableHardpoints());
  }

  [Test]
  public void BuildStats_AvailableHardpoints_CanBeNegative()
  {
    Build build = ScriptableObject.CreateInstance<Build>();

    build.@core = ScriptableObject.CreateInstance<Core>();
    build.@core.hardpoints = 1;

    build.options.Add(ScriptableObject.CreateInstance<Option>());
    build.options[0].hardpoints = 10;

    BuildStats buildStats = new(build);

    Assert.AreEqual(-9, buildStats.AvailableHardpoints());
  }
  #endregion

  #region RemainingBaseLimit
  [Test]
  public void BuildStats_RemainingBaseLimit_ZeroWhenEmpty()
  {
    Build build = ScriptableObject.CreateInstance<Build>();
    BuildStats buildStats = new(build);

    Assert.AreEqual(0, buildStats.RemainingBaseLimit());
  }

  [Test]
  public void BuildStats_RemainingBaseLimit_ProperlyAddsUpAFullBuild()
  {
    Build build = ScriptableObject.CreateInstance<Build>();

    // Not included in total
    build.@base = ScriptableObject.CreateInstance<Base>();
    build.@base.weight = 1000;
    build.@base.limit = 10;

    build.@core = ScriptableObject.CreateInstance<Core>();
    build.@core.weight = 1;

    build.leftArm = ScriptableObject.CreateInstance<Arm>();
    build.leftArm.weight = 1;

    build.rightArm = ScriptableObject.CreateInstance<Arm>();
    build.rightArm.weight = 1;

    build.weapons.Add(ScriptableObject.CreateInstance<Weapon>());
    build.weapons[0].weight = 1;

    build.options.Add(ScriptableObject.CreateInstance<Option>());
    build.options[0].weight = 1;

    BuildStats buildStats = new(build);

    Assert.AreEqual(5, buildStats.RemainingBaseLimit());
  }

  [Test]
  public void BuildStats_RemainingBaseLimit_CanBeNegative()
  {
    Build build = ScriptableObject.CreateInstance<Build>();

    // Not included in total
    build.@base = ScriptableObject.CreateInstance<Base>();
    build.@base.weight = 1000;
    build.@base.limit = 1;

    build.@core = ScriptableObject.CreateInstance<Core>();
    build.@core.weight = 1;

    build.leftArm = ScriptableObject.CreateInstance<Arm>();
    build.leftArm.weight = 1;

    build.rightArm = ScriptableObject.CreateInstance<Arm>();
    build.rightArm.weight = 1;

    build.weapons.Add(ScriptableObject.CreateInstance<Weapon>());
    build.weapons[0].weight = 1;

    build.options.Add(ScriptableObject.CreateInstance<Option>());
    build.options[0].weight = 1;

    BuildStats buildStats = new(build);

    Assert.AreEqual(-4, buildStats.RemainingBaseLimit());
  }
  #endregion

  #region RemainingCoreLimit
  [Test]
  public void BuildStats_RemainingCoreLimit_ZeroWhenEmpty()
  {
    Build build = ScriptableObject.CreateInstance<Build>();
    BuildStats buildStats = new(build);

    Assert.AreEqual(0, buildStats.RemainingCoreLimit());
  }

  [Test]
  public void BuildStats_RemainingCoreLimit_ProperlyAddsUpAFullBuild()
  {
    Build build = ScriptableObject.CreateInstance<Build>();

    // Not included in total
    build.@base = ScriptableObject.CreateInstance<Base>();
    build.@base.weight = 1000;

    // Not included in total
    build.@core = ScriptableObject.CreateInstance<Core>();
    build.@core.weight = 1000;
    build.@core.limit = 10;

    build.leftArm = ScriptableObject.CreateInstance<Arm>();
    build.leftArm.weight = 1;

    build.rightArm = ScriptableObject.CreateInstance<Arm>();
    build.rightArm.weight = 1;

    build.weapons.Add(ScriptableObject.CreateInstance<Weapon>());
    build.weapons[0].weight = 1;

    build.options.Add(ScriptableObject.CreateInstance<Option>());
    build.options[0].weight = 1;

    BuildStats buildStats = new(build);

    Assert.AreEqual(6, buildStats.RemainingCoreLimit());
  }

  [Test]
  public void BuildStats_RemainingCoreLimit_CanBeNegative()
  {
    Build build = ScriptableObject.CreateInstance<Build>();

    // Not included in total
    build.@base = ScriptableObject.CreateInstance<Base>();
    build.@base.weight = 1000;

    build.@core = ScriptableObject.CreateInstance<Core>();
    build.@core.weight = 1000;
    build.@core.limit = 1;

    build.leftArm = ScriptableObject.CreateInstance<Arm>();
    build.leftArm.weight = 1;

    build.rightArm = ScriptableObject.CreateInstance<Arm>();
    build.rightArm.weight = 1;

    build.weapons.Add(ScriptableObject.CreateInstance<Weapon>());
    build.weapons[0].weight = 1;

    build.options.Add(ScriptableObject.CreateInstance<Option>());
    build.options[0].weight = 1;

    BuildStats buildStats = new(build);

    Assert.AreEqual(-3, buildStats.RemainingCoreLimit());
  }
  #endregion

  #region RemainingLeftArmLimit
  [Test]
  public void BuildStats_RemainingLeftArmLimit_ZeroWhenEmpty()
  {
    Build build = ScriptableObject.CreateInstance<Build>();
    BuildStats buildStats = new(build);

    Assert.AreEqual(0, buildStats.RemainingLeftArmLimit());
  }

  [Test]
  public void BuildStats_RemainingLeftArmLimit_ProperlyAddsUpAFullBuild()
  {
    Build build = ScriptableObject.CreateInstance<Build>();

    // Not included in total
    build.@base = ScriptableObject.CreateInstance<Base>();
    build.@base.weight = 1000;

    // Not included in total
    build.@core = ScriptableObject.CreateInstance<Core>();
    build.@core.weight = 1000;

    // Not included in total
    build.leftArm = ScriptableObject.CreateInstance<Arm>();
    build.leftArm.weight = 1000;
    build.leftArm.limit = 5;

    // Not included in total
    build.rightArm = ScriptableObject.CreateInstance<Arm>();
    build.rightArm.weight = 1000;

    build.weapons.Add(ScriptableObject.CreateInstance<Weapon>());
    build.weapons[0].mountSide = Weapon.MountSide.Left;
    build.weapons[0].weight = 1;

    build.weapons.Add(ScriptableObject.CreateInstance<Weapon>());
    build.weapons[1].mountSide = Weapon.MountSide.Left;
    build.weapons[1].weight = 1;

    BuildStats buildStats = new(build);

    Assert.AreEqual(3, buildStats.RemainingLeftArmLimit());
  }

  [Test]
  public void BuildStats_RemainingLeftArmLimit_CanBeNegative()
  {
    Build build = ScriptableObject.CreateInstance<Build>();

    // Not included in total
    build.@base = ScriptableObject.CreateInstance<Base>();
    build.@base.weight = 1000;

    // Not included in total
    build.@core = ScriptableObject.CreateInstance<Core>();
    build.@core.weight = 1000;

    // Not included in total
    build.leftArm = ScriptableObject.CreateInstance<Arm>();
    build.leftArm.weight = 1000;
    build.leftArm.limit = 1;

    // Not included in total
    build.rightArm = ScriptableObject.CreateInstance<Arm>();
    build.rightArm.weight = 1000;

    build.weapons.Add(ScriptableObject.CreateInstance<Weapon>());
    build.weapons[0].mountSide = Weapon.MountSide.Left;
    build.weapons[0].weight = 1;

    build.weapons.Add(ScriptableObject.CreateInstance<Weapon>());
    build.weapons[1].mountSide = Weapon.MountSide.Left;
    build.weapons[1].weight = 1;

    BuildStats buildStats = new(build);

    Assert.AreEqual(-1, buildStats.RemainingLeftArmLimit());
  }
  #endregion

  #region RemainingRightArmLimit
  [Test]
  public void BuildStats_RemainingRightArmLimit_ZeroWhenEmpty()
  {
    Build build = ScriptableObject.CreateInstance<Build>();
    BuildStats buildStats = new(build);

    Assert.AreEqual(0, buildStats.RemainingRightArmLimit());
  }

  [Test]
  public void BuildStats_RemainingRightArmLimit_ProperlyAddsUpAFullBuild()
  {
    Build build = ScriptableObject.CreateInstance<Build>();

    // Not included in total
    build.@base = ScriptableObject.CreateInstance<Base>();
    build.@base.weight = 1000;

    // Not included in total
    build.@core = ScriptableObject.CreateInstance<Core>();
    build.@core.weight = 1000;

    // Not included in total
    build.leftArm = ScriptableObject.CreateInstance<Arm>();
    build.leftArm.weight = 1000;

    // Not included in total
    build.rightArm = ScriptableObject.CreateInstance<Arm>();
    build.rightArm.weight = 1000;
    build.rightArm.limit = 5;

    build.weapons.Add(ScriptableObject.CreateInstance<Weapon>());
    build.weapons[0].mountSide = Weapon.MountSide.Right;
    build.weapons[0].weight = 1;

    build.weapons.Add(ScriptableObject.CreateInstance<Weapon>());
    build.weapons[1].mountSide = Weapon.MountSide.Right;
    build.weapons[1].weight = 1;

    BuildStats buildStats = new(build);

    Assert.AreEqual(3, buildStats.RemainingRightArmLimit());
  }

  [Test]
  public void BuildStats_RemainingRightArmLimit_CanBeNegative()
  {
    Build build = ScriptableObject.CreateInstance<Build>();

    // Not included in total
    build.@base = ScriptableObject.CreateInstance<Base>();
    build.@base.weight = 1000;

    // Not included in total
    build.@core = ScriptableObject.CreateInstance<Core>();
    build.@core.weight = 1000;

    // Not included in total
    build.leftArm = ScriptableObject.CreateInstance<Arm>();
    build.leftArm.weight = 1000;

    // Not included in total
    build.rightArm = ScriptableObject.CreateInstance<Arm>();
    build.rightArm.weight = 1000;
    build.rightArm.limit = 1;

    build.weapons.Add(ScriptableObject.CreateInstance<Weapon>());
    build.weapons[0].mountSide = Weapon.MountSide.Right;
    build.weapons[0].weight = 1;

    build.weapons.Add(ScriptableObject.CreateInstance<Weapon>());
    build.weapons[1].mountSide = Weapon.MountSide.Right;
    build.weapons[1].weight = 1;

    BuildStats buildStats = new(build);

    Assert.AreEqual(-1, buildStats.RemainingRightArmLimit());
  }
  #endregion

  #region MissingPartCheck
  [Test]
  public void BuildStats_MissingPartCheck_AllPartsWhenEmpty()
  {
    Build build = ScriptableObject.CreateInstance<Build>();
    BuildStats buildStats = new(build);

    (BuildStats.Status BuildStatus, List<string> Errors) = buildStats.MissingPartCheck();

    Assert.AreEqual(BuildStats.Status.Error, BuildStatus);
    Assert.IsTrue(Errors.Contains("Missing base"));
    Assert.IsTrue(Errors.Contains("Missing core"));
    Assert.IsTrue(Errors.Contains("Missing left arm"));
    Assert.IsTrue(Errors.Contains("Missing right arm"));
    Assert.IsTrue(Errors.Contains("Missing targeting system"));
    Assert.IsTrue(Errors.Contains("Missing generator"));
    Assert.IsTrue(Errors.Contains("Missing radiator"));
    Assert.IsTrue(Errors.Contains("Missing booster"));
    Assert.IsTrue(Errors.Contains("Missing weapons"));
  }

  [Test]
  public void BuildStats_MissingPartCheck_OkWhenComplete()
  {
    Build build = ScriptableObject.CreateInstance<Build>();

    build.@base = ScriptableObject.CreateInstance<Base>();
    build.@core = ScriptableObject.CreateInstance<Core>();
    build.leftArm = ScriptableObject.CreateInstance<Arm>();
    build.rightArm = ScriptableObject.CreateInstance<Arm>();
    build.@targetingSystem = ScriptableObject.CreateInstance<TargetingSystem>();
    build.@generator = ScriptableObject.CreateInstance<Generator>();
    build.@radiator = ScriptableObject.CreateInstance<Radiator>();
    build.@booster = ScriptableObject.CreateInstance<Booster>();
    build.weapons.Add(ScriptableObject.CreateInstance<Weapon>());

    BuildStats buildStats = new(build);

    (BuildStats.Status BuildStatus, List<string> Errors) = buildStats.MissingPartCheck();

    Assert.AreEqual(BuildStats.Status.Ok, BuildStatus);
    Assert.AreEqual(0, Errors.Count);
  }

  [Test]
  public void BuildStats_MissingPartCheck_TankBaseDoesntRequireBooster()
  {
    Build build = ScriptableObject.CreateInstance<Build>();

    build.@base = ScriptableObject.CreateInstance<Base>();
    build.@base.baseType = Base.BaseType.Tank;

    build.@core = ScriptableObject.CreateInstance<Core>();
    build.leftArm = ScriptableObject.CreateInstance<Arm>();
    build.rightArm = ScriptableObject.CreateInstance<Arm>();
    build.@targetingSystem = ScriptableObject.CreateInstance<TargetingSystem>();
    build.@generator = ScriptableObject.CreateInstance<Generator>();
    build.@radiator = ScriptableObject.CreateInstance<Radiator>();
    build.weapons.Add(ScriptableObject.CreateInstance<Weapon>());

    BuildStats buildStats = new(build);

    (BuildStats.Status BuildStatus, List<string> Errors) = buildStats.MissingPartCheck();

    Assert.AreEqual(BuildStats.Status.Ok, BuildStatus);
    Assert.AreEqual(0, Errors.Count);
  }
  #endregion

  #region BudgetCheck
  [Test]
  public void BuildStats_BudgetCheck_OkWhenEmpty()
  {
    Build build = ScriptableObject.CreateInstance<Build>();
    BuildStats buildStats = new(build);

    (BuildStats.Status BuildStatus, List<string> Errors) = buildStats.BudgetCheck(1);

    Assert.AreEqual(BuildStats.Status.Ok, BuildStatus);
    Assert.AreEqual(0, Errors.Count);
  }

  [Test]
  public void BuildStats_BudgetCheck_OkWhenCompleteUnderBudget()
  {
    Build build = ScriptableObject.CreateInstance<Build>();

    build.@base = ScriptableObject.CreateInstance<Base>();
    build.@base.cost = 1;

    build.@core = ScriptableObject.CreateInstance<Core>();
    build.@core.cost = 1;

    build.leftArm = ScriptableObject.CreateInstance<Arm>();
    build.leftArm.cost = 1;

    build.rightArm = ScriptableObject.CreateInstance<Arm>();
    build.rightArm.cost = 1;

    build.@targetingSystem = ScriptableObject.CreateInstance<TargetingSystem>();
    build.@targetingSystem.cost = 1;

    build.@generator = ScriptableObject.CreateInstance<Generator>();
    build.@generator.cost = 1;

    build.@radiator = ScriptableObject.CreateInstance<Radiator>();
    build.@radiator.cost = 1;

    build.@booster = ScriptableObject.CreateInstance<Booster>();
    build.@booster.cost = 1;

    build.weapons.Add(ScriptableObject.CreateInstance<Weapon>());
    build.weapons[0].cost = 1;

    BuildStats buildStats = new(build);

    (BuildStats.Status BuildStatus, List<string> Errors) = buildStats.BudgetCheck(10);

    Assert.AreEqual(BuildStats.Status.Ok, BuildStatus);
    Assert.AreEqual(0, Errors.Count);
  }

  [Test]
  public void BuildStats_BudgetCheck_ErrorWhenCompleteOverBudget()
  {
    Build build = ScriptableObject.CreateInstance<Build>();

    build.@base = ScriptableObject.CreateInstance<Base>();
    build.@base.cost = 1;

    build.@core = ScriptableObject.CreateInstance<Core>();
    build.@core.cost = 1;

    build.leftArm = ScriptableObject.CreateInstance<Arm>();
    build.leftArm.cost = 1;

    build.rightArm = ScriptableObject.CreateInstance<Arm>();
    build.rightArm.cost = 1;

    build.@targetingSystem = ScriptableObject.CreateInstance<TargetingSystem>();
    build.@targetingSystem.cost = 1;

    build.@generator = ScriptableObject.CreateInstance<Generator>();
    build.@generator.cost = 1;

    build.@radiator = ScriptableObject.CreateInstance<Radiator>();
    build.@radiator.cost = 1;

    build.@booster = ScriptableObject.CreateInstance<Booster>();
    build.@booster.cost = 1;

    build.weapons.Add(ScriptableObject.CreateInstance<Weapon>());
    build.weapons[0].cost = 1;

    BuildStats buildStats = new(build);

    (BuildStats.Status BuildStatus, List<string> Errors) = buildStats.BudgetCheck(1);

    Assert.AreEqual(BuildStats.Status.Error, BuildStatus);
    Assert.IsTrue(Errors.Contains("Budget exceeded by 8 credits"));
  }
  #endregion

  #region HardpointCheck
  [Test]
  public void BuildStats_HardpointCheck_NoCoreErrorWhenMissing()
  {
    Build build = ScriptableObject.CreateInstance<Build>();
    BuildStats buildStats = new(build);

    (BuildStats.Status BuildStatus, List<string> Errors) = buildStats.HardpointCheck();

    Assert.AreEqual(BuildStats.Status.Error, BuildStatus);
    Assert.IsTrue(Errors.Contains("No core"));
  }

  [Test]
  public void BuildStats_HardpointCheck_OkWhenUnderLimit()
  {
    Build build = ScriptableObject.CreateInstance<Build>();

    build.@core = ScriptableObject.CreateInstance<Core>();
    build.@core.hardpoints = 10;

    build.options.Add(ScriptableObject.CreateInstance<Option>());
    build.options[0].hardpoints = 1;

    BuildStats buildStats = new(build);

    (BuildStats.Status BuildStatus, List<string> Errors) = buildStats.HardpointCheck();

    Assert.AreEqual(BuildStats.Status.Ok, BuildStatus);
    Assert.AreEqual(0, Errors.Count);
  }

  [Test]
  public void BuildStats_HardpointCheck_ErrorWhenOverLimit()
  {
    Build build = ScriptableObject.CreateInstance<Build>();

    build.@core = ScriptableObject.CreateInstance<Core>();
    build.@core.hardpoints = 1;

    build.options.Add(ScriptableObject.CreateInstance<Option>());
    build.options[0].hardpoints = 10;

    BuildStats buildStats = new(build);

    (BuildStats.Status BuildStatus, List<string> Errors) = buildStats.HardpointCheck();

    Assert.AreEqual(BuildStats.Status.Error, BuildStatus);
    Assert.IsTrue(Errors.Contains("Hardpoints exceeded by 9"));
  }
  #endregion

  #region BaseLimitCheck
  [Test]
  public void BuildStats_BaseLimitCheck_NoBaseErrorWhenMissing()
  {
    Build build = ScriptableObject.CreateInstance<Build>();
    BuildStats buildStats = new(build);

    (BuildStats.Status BuildStatus, List<string> Errors) = buildStats.BaseLimitCheck();

    Assert.AreEqual(BuildStats.Status.Error, BuildStatus);
    Assert.IsTrue(Errors.Contains("No base"));
  }

  [Test]
  public void BuildStats_BaseLimitCheck_OkWhenUnderLimit()
  {
    Build build = ScriptableObject.CreateInstance<Build>();

    // Not included in total
    build.@base = ScriptableObject.CreateInstance<Base>();
    build.@base.weight = 1000;
    build.@base.limit = 10;

    build.@core = ScriptableObject.CreateInstance<Core>();
    build.@core.weight = 1;

    build.leftArm = ScriptableObject.CreateInstance<Arm>();
    build.leftArm.weight = 1;

    build.rightArm = ScriptableObject.CreateInstance<Arm>();
    build.rightArm.weight = 1;

    build.weapons.Add(ScriptableObject.CreateInstance<Weapon>());
    build.weapons[0].weight = 1;

    build.options.Add(ScriptableObject.CreateInstance<Option>());
    build.options[0].weight = 1;

    BuildStats buildStats = new(build);

    (BuildStats.Status BuildStatus, List<string> Errors) = buildStats.BaseLimitCheck();

    Assert.AreEqual(BuildStats.Status.Ok, BuildStatus);
    Assert.AreEqual(0, Errors.Count);
  }

  [Test]
  public void BuildStats_BaseLimitCheck_ErrorWhenOverLimit()
  {
    Build build = ScriptableObject.CreateInstance<Build>();

    // Not included in total
    build.@base = ScriptableObject.CreateInstance<Base>();
    build.@base.weight = 1000;
    build.@base.limit = 1;

    build.@core = ScriptableObject.CreateInstance<Core>();
    build.@core.weight = 1;

    build.leftArm = ScriptableObject.CreateInstance<Arm>();
    build.leftArm.weight = 1;

    build.rightArm = ScriptableObject.CreateInstance<Arm>();
    build.rightArm.weight = 1;

    build.weapons.Add(ScriptableObject.CreateInstance<Weapon>());
    build.weapons[0].weight = 1;

    build.options.Add(ScriptableObject.CreateInstance<Option>());
    build.options[0].weight = 1;

    BuildStats buildStats = new(build);

    (BuildStats.Status BuildStatus, List<string> Errors) = buildStats.BaseLimitCheck();

    Assert.AreEqual(BuildStats.Status.Error, BuildStatus);
    Assert.IsTrue(Errors.Contains("Base limit exceeded by 4"));
  }
  #endregion

  #region CoreLimitCheck
  [Test]
  public void BuildStats_CoreLimitCheck_NoCoreErrorWhenMissing()
  {
    Build build = ScriptableObject.CreateInstance<Build>();
    BuildStats buildStats = new(build);

    (BuildStats.Status BuildStatus, List<string> Errors) = buildStats.CoreLimitCheck();

    Assert.AreEqual(BuildStats.Status.Error, BuildStatus);
    Assert.IsTrue(Errors.Contains("No core"));
  }

  [Test]
  public void BuildStats_CoreLimitCheck_OkWhenUnderLimit()
  {
    Build build = ScriptableObject.CreateInstance<Build>();

    // Not included in total
    build.@base = ScriptableObject.CreateInstance<Base>();
    build.@base.weight = 1000;

    // Not included in total
    build.@core = ScriptableObject.CreateInstance<Core>();
    build.@core.weight = 1000;
    build.@core.limit = 10;

    build.leftArm = ScriptableObject.CreateInstance<Arm>();
    build.leftArm.weight = 1;

    build.rightArm = ScriptableObject.CreateInstance<Arm>();
    build.rightArm.weight = 1;

    build.weapons.Add(ScriptableObject.CreateInstance<Weapon>());
    build.weapons[0].weight = 1;

    build.options.Add(ScriptableObject.CreateInstance<Option>());
    build.options[0].weight = 1;

    BuildStats buildStats = new(build);

    (BuildStats.Status BuildStatus, List<string> Errors) = buildStats.CoreLimitCheck();

    Assert.AreEqual(BuildStats.Status.Ok, BuildStatus);
    Assert.AreEqual(0, Errors.Count);
  }

  [Test]
  public void BuildStats_CoreLimitCheck_ErrorWhenOverLimit()
  {
    Build build = ScriptableObject.CreateInstance<Build>();

    // Not included in total
    build.@base = ScriptableObject.CreateInstance<Base>();
    build.@base.weight = 1000;

    // Not included in total
    build.@core = ScriptableObject.CreateInstance<Core>();
    build.@core.weight = 1000;
    build.@core.limit = 1;

    build.leftArm = ScriptableObject.CreateInstance<Arm>();
    build.leftArm.weight = 1;

    build.rightArm = ScriptableObject.CreateInstance<Arm>();
    build.rightArm.weight = 1;

    build.weapons.Add(ScriptableObject.CreateInstance<Weapon>());
    build.weapons[0].weight = 1;

    build.options.Add(ScriptableObject.CreateInstance<Option>());
    build.options[0].weight = 1;

    BuildStats buildStats = new(build);

    (BuildStats.Status BuildStatus, List<string> Errors) = buildStats.CoreLimitCheck();

    Assert.AreEqual(BuildStats.Status.Error, BuildStatus);
    Assert.IsTrue(Errors.Contains("Core limit exceeded by 3"));
  }
  #endregion

  #region LeftArmLimitCheck
  [Test]
  public void BuildStats_LeftArmLimitCheck_NoLeftArmErrorWhenMissing()
  {
    Build build = ScriptableObject.CreateInstance<Build>();
    BuildStats buildStats = new(build);

    (BuildStats.Status BuildStatus, List<string> Errors) = buildStats.LeftArmLimitCheck();

    Assert.AreEqual(BuildStats.Status.Error, BuildStatus);
    Assert.IsTrue(Errors.Contains("No left arm"));
  }

  [Test]
  public void BuildStats_LeftArmLimitCheck_OkWhenUnderLimit()
  {
    Build build = ScriptableObject.CreateInstance<Build>();

    // Not included in total
    build.@base = ScriptableObject.CreateInstance<Base>();
    build.@base.weight = 1000;

    // Not included in total
    build.@core = ScriptableObject.CreateInstance<Core>();
    build.@core.weight = 1000;

    // Not included in total
    build.leftArm = ScriptableObject.CreateInstance<Arm>();
    build.leftArm.weight = 1000;
    build.leftArm.limit = 10;

    // Not included in total
    build.rightArm = ScriptableObject.CreateInstance<Arm>();
    build.rightArm.weight = 1000;

    build.weapons.Add(ScriptableObject.CreateInstance<Weapon>());
    build.weapons[0].mountSide = Weapon.MountSide.Left;
    build.weapons[0].weight = 1;

    BuildStats buildStats = new(build);

    (BuildStats.Status BuildStatus, List<string> Errors) = buildStats.LeftArmLimitCheck();

    Assert.AreEqual(BuildStats.Status.Ok, BuildStatus);
    Assert.AreEqual(0, Errors.Count);
  }

  [Test]
  public void BuildStats_LeftArmLimitCheck_ErrorWhenOverLimit()
  {
    Build build = ScriptableObject.CreateInstance<Build>();

    // Not included in total
    build.@base = ScriptableObject.CreateInstance<Base>();
    build.@base.weight = 1000;

    // Not included in total
    build.@core = ScriptableObject.CreateInstance<Core>();
    build.@core.weight = 1000;

    // Not included in total
    build.leftArm = ScriptableObject.CreateInstance<Arm>();
    build.leftArm.weight = 1000;
    build.leftArm.limit = 1;

    // Not included in total
    build.rightArm = ScriptableObject.CreateInstance<Arm>();
    build.rightArm.weight = 1000;

    build.weapons.Add(ScriptableObject.CreateInstance<Weapon>());
    build.weapons[0].mountSide = Weapon.MountSide.Left;
    build.weapons[0].weight = 10;

    BuildStats buildStats = new(build);

    (BuildStats.Status BuildStatus, List<string> Errors) = buildStats.LeftArmLimitCheck();

    Assert.AreEqual(BuildStats.Status.Error, BuildStatus);
    Assert.IsTrue(Errors.Contains("Left arm limit exceeded by 9"));
  }
  #endregion

  #region RightArmLimitCheck
  [Test]
  public void BuildStats_RightArmLimitCheck_NoRightArmErrorWhenMissing()
  {
    Build build = ScriptableObject.CreateInstance<Build>();
    BuildStats buildStats = new(build);

    (BuildStats.Status BuildStatus, List<string> Errors) = buildStats.RightArmLimitCheck();

    Assert.AreEqual(BuildStats.Status.Error, BuildStatus);
    Assert.IsTrue(Errors.Contains("No right arm"));
  }

  [Test]
  public void BuildStats_RightArmLimitCheck_OkWhenUnderLimit()
  {
    Build build = ScriptableObject.CreateInstance<Build>();

    // Not included in total
    build.@base = ScriptableObject.CreateInstance<Base>();
    build.@base.weight = 1000;

    // Not included in total
    build.@core = ScriptableObject.CreateInstance<Core>();
    build.@core.weight = 1000;

    // Not included in total
    build.leftArm = ScriptableObject.CreateInstance<Arm>();
    build.leftArm.weight = 1000;

    // Not included in total
    build.rightArm = ScriptableObject.CreateInstance<Arm>();
    build.rightArm.weight = 1000;
    build.rightArm.limit = 10;

    build.weapons.Add(ScriptableObject.CreateInstance<Weapon>());
    build.weapons[0].mountSide = Weapon.MountSide.Right;
    build.weapons[0].weight = 1;

    BuildStats buildStats = new(build);

    (BuildStats.Status BuildStatus, List<string> Errors) = buildStats.RightArmLimitCheck();

    Assert.AreEqual(BuildStats.Status.Ok, BuildStatus);
    Assert.AreEqual(0, Errors.Count);
  }

  [Test]
  public void BuildStats_RightArmLimitCheck_ErrorWhenOverLimit()
  {
    Build build = ScriptableObject.CreateInstance<Build>();

    // Not included in total
    build.@base = ScriptableObject.CreateInstance<Base>();
    build.@base.weight = 1000;

    // Not included in total
    build.@core = ScriptableObject.CreateInstance<Core>();
    build.@core.weight = 1000;

    // Not included in total
    build.leftArm = ScriptableObject.CreateInstance<Arm>();
    build.leftArm.weight = 1000;

    // Not included in total
    build.rightArm = ScriptableObject.CreateInstance<Arm>();
    build.rightArm.weight = 1000;
    build.rightArm.limit = 1;

    build.weapons.Add(ScriptableObject.CreateInstance<Weapon>());
    build.weapons[0].mountSide = Weapon.MountSide.Right;
    build.weapons[0].weight = 10;

    BuildStats buildStats = new(build);

    (BuildStats.Status BuildStatus, List<string> Errors) = buildStats.RightArmLimitCheck();

    Assert.AreEqual(BuildStats.Status.Error, BuildStatus);
    Assert.IsTrue(Errors.Contains("Right arm limit exceeded by 9"));
  }
  #endregion
}
