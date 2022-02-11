namespace Uzumachi.UzuBlog.Domain.Extensions;

public static class BoolExtensions {

  public static string TrueFalse(this bool value, string trueValue, string falseValue = "") {
    return value ? trueValue : falseValue;
  }
}
