using NUnit.Framework;

public class UtilsTest
{
  #region Pluralize
  [Test]
  public void Utils_Pluralize_SimplyReturnsTheWordWhenCountIsOne()
  {
    Assert.AreEqual("word", Utils.Pluralize("word", 1));
  }

  [Test]
  public void Utils_Pluralize_UsesCustomPluralWhenGivenAndNotOne()
  {
    Assert.AreEqual("oxen", Utils.Pluralize("ox", 0, "oxen"));
    Assert.AreEqual("oxen", Utils.Pluralize("ox", 2, "oxen"));
  }

  [Test]
  public void Utils_Pluralize_UsesStandardPluralWhenNotGivenCustom()
  {
    Assert.AreEqual("words", Utils.Pluralize("word", 0));
    Assert.AreEqual("words", Utils.Pluralize("word", 2));
  }
  #endregion
}
