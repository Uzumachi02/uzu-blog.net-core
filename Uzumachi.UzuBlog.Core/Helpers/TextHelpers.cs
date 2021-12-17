using System.Text;
using System.Text.RegularExpressions;

namespace Uzumachi.UzuBlog.Core.Helpers;

public static class TextHelpers {

  private static readonly Dictionary<char, string> _convertedLetters = new() {
    {'а', "a"},
    {'б', "b"},
    {'в', "v"},
    {'г', "g"},
    {'д', "d"},
    {'е', "e"},
    {'ё', "yo"},
    {'ж', "zh"},
    {'з', "z"},
    {'и', "i"},
    {'й', "j"},
    {'к', "k"},
    {'л', "l"},
    {'м', "m"},
    {'н', "n"},
    {'о', "o"},
    {'п', "p"},
    {'р', "r"},
    {'с', "s"},
    {'т', "t"},
    {'у', "u"},
    {'ф', "f"},
    {'х', "h"},
    {'ц', "c"},
    {'ч', "ch"},
    {'ш', "sh"},
    {'щ', "sch"},
    {'ъ', "j"},
    {'ы', "i"},
    {'ь', "j"},
    {'э', "e"},
    {'ю', "yu"},
    {'я', "ya"},
    {'А', "A"},
    {'Б', "B"},
    {'В', "V"},
    {'Г', "G"},
    {'Д', "D"},
    {'Е', "E"},
    {'Ё', "Yo"},
    {'Ж', "Zh"},
    {'З', "Z"},
    {'И', "I"},
    {'Й', "J"},
    {'К', "K"},
    {'Л', "L"},
    {'М', "M"},
    {'Н', "N"},
    {'О', "O"},
    {'П', "P"},
    {'Р', "R"},
    {'С', "S"},
    {'Т', "T"},
    {'У', "U"},
    {'Ф', "F"},
    {'Х', "H"},
    {'Ц', "C"},
    {'Ч', "Ch"},
    {'Ш', "Sh"},
    {'Щ', "Sch"},
    {'Ъ', "J"},
    {'Ы', "I"},
    {'Ь', "J"},
    {'Э', "E"},
    {'Ю', "Yu"},
    {'Я', "Ya"}
  };

  public static string ConvertToLatin(string source) {
    var result = new StringBuilder();

    foreach( var letter in source ) {
      if( _convertedLetters.ContainsKey(letter) ) {
        result.Append(_convertedLetters[letter]);
      } else if( Regex.IsMatch(letter.ToString(), @"[\w\s]", RegexOptions.IgnoreCase) ) {
        result.Append(letter);
      }
    }

    return result.ToString();
  }

  public static string TranslitForAlias(string source) {
    var result = ConvertToLatin(source.Trim().ToLower());

    return result.Replace(' ', '-');
  }
}
