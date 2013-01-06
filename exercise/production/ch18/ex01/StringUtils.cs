using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace production.ch18.ex01
{
    public class StringUtils
    {
        /// <summary>
        /// ラムダ式を使った、ToSnakeCaseメソッド
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string ToSnakeCase(string text)
        {
            if (text == null)
            {
                throw new NullReferenceException();
            }

            string snake = Regex.Replace(text, "[A-Z]", (Match match) => "_" + match.Value.ToLower());
            
            return Regex.Replace(snake, "^_", "");
        }


        /// <summary>
        /// ラムダ式なしの、ToSnakeCaseメソッド (Convertメソッドも合わせて使う)
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string ToSnakeCaseWithoutLambda(string text)
        {
            if (text == null)
            {
                throw new NullReferenceException();
            }

            string snake = Regex.Replace(text, "[A-Z]", new MatchEvaluator(Convert));
            return Regex.Replace(snake, "^_", "");
        }


        public static string Convert(Match match)
        {
            return "_" + match.Value.ToLower();
        }
    }
}
