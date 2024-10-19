using Parts;
using System.Collections.Generic;
using UnityEngine;

namespace Builds
{
  [CreateAssetMenu(fileName = "Build", menuName = "Builds/Build")]
  public class Build : ScriptableObject
  {
    public Base @base;
    public Core @core;
    public Arm leftArm;
    public Arm rightArm;
    public TargetingSystem @targetingSystem;
    public Generator @generator;
    public Radiator @radiator;
    public Booster @booster;
    public List<Weapon> weapons = new();
    public List<Option> options = new();
  }
}
