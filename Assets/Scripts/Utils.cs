public class Utils
{
  static public string Pluralize(string word, int count, string customPlural = null)
  {
    if (count == 1)
    {
      return word;
    }

    if (customPlural != null)
    {
      return customPlural;
    }

    return word + "s";
  }
}
