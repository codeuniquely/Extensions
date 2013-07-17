namespace System
{
    using System.Text;

    /// <summary>
    /// Extension wrapper class for <see cref="System.String"/> to provide a varity of useful manipulation methods.
    /// </summary>
    public static class StringExt
    {
        /// <summary>
        /// Provide a integer convrsion extension to a string 
        /// </summary>
        /// <param name="s">this string</param>
        /// <returns>int value represented in the string or 0</returns>
        public static int ToInt(this string s)
        {
            int o = 0;

            if (int.TryParse(s, out o) == false)
            {
                o = 0;
            }

            return o;
        }

        /// <summary>
        /// Provide a bool conversion extension to a string 
        /// </summary>
        /// <param name="s">this string</param>
        /// <returns>int value represented in the string or 0</returns>
        public static bool ToBool(this string s)
        {
            if (s == null)
            {
                return false;
            }

            string toCheck = s.Trim();

            if (toCheck == "1")
            {
                return true;
            }
            else if (toCheck == "0")
            {
                return false;
            }
            else
            {
                bool response;
                return bool.TryParse(toCheck, out response) ? response : false;
            }
        }

        /// <summary>
        /// Gets a UTF8 Byte array representaion of the string
        /// </summary>
        /// <param name="s">this string</param>
        /// <returns>a Byte array encoded to UTF8</returns>
        public static byte[] ToUTF8Bytes(this string s)
        {
            return Encoding.UTF8.GetBytes(s);
        }

        /// <summary>
        /// Checks to see if the string has NO contents - shorter form and more Symantic
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsEmpty(this string s)
        {
            return string.IsNullOrWhiteSpace(s);
        }

        /// <summary>
        /// Checks to see if the string has contents - shorter form and more Symantic
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsNotEmpty(this string s)
        {
            return !string.IsNullOrWhiteSpace(s);
        }

        /// <summary>
        /// Comparison to see if the two strings are identical (deals with null)
        /// </summary>
        /// <param name="s">this string</param>
        /// <param name="test">The string to be compared to</param>
        /// <returns><c>True</c> if the two strings are identical otherwise <c>False</c></returns>
        public static bool Compare(this string s, string test)
        {
            if ((s == null) || (test == null))
            {
                return false;
            }

            return s.Equals(test);
        }

        /// <summary>
        /// Extends a string with a value, adding comma if required
        /// </summary>
        /// <param name="s">this string</param>
        /// <param name="tail">The string extension to be applied</param>
        /// <returns>returns an extended <see cref="System.String"/> with the values separated by commas</returns>
        public static string Extend(this string s, string tail)
        {
            return (s.Length > 0) ? string.Concat(s, ",", tail) : tail;
        }

        /// <summary>
        /// Limits the specified s.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <param name="length">The length.</param>
        /// <returns></returns>
        public static string LimitTo(this string s, int length)
        {
            return (s.Length > length) ? s.Substring(0, length) : s;
        }

        /// <summary>
        /// Get the Left most 'size' items from a string
        /// </summary>
        /// <param name="s">this string</param>
        /// <param name="size">The size of the string to return</param>
        /// <returns>The left most [size] characters from the string</returns>
        public static string Left(this string s, int size)
        {
            if (s == null) return string.Empty;

            string response = s;

            if (!string.IsNullOrEmpty(s))
            {
                int len = s.Length;

                if (size < len)
                {
                    response = s.Substring(0, size);
                }
            }

            return response;
        }

        /// <summary>
        /// Prefix a string with another string
        /// </summary>
        /// <param name="s">this string</param>
        /// <param name="add">The prefix to add</param>
        /// <returns>A <see cref="System.String"/> which is prefixed by the required text</returns>
        public static string Prefix(this string s, string add)
        {
            if (s == null) return add;

            return string.Concat(add, s);
        }

        /// <summary>
        /// Remove the left most 'size' items from a string
        /// </summary>
        /// <param name="s">this string</param>
        /// <param name="size">The number of characters to trim to</param>
        /// <returns>A string with the left most [size] characters removed or string.Empty</returns>
        public static string TrimLeft(this string s, int size)
        {
            string response = s;

            if (!string.IsNullOrEmpty(s))
            {
                int len = s.Length;

                if (size < len)
                {
                    response = s.Substring(size);
                }
                else
                {
                    response = string.Empty;
                }
            }

            return response;
        }

        /// <summary>
        /// Replace the contents of the start of a string if they match
        /// </summary>
        /// <param name="s">this string</param>
        /// <param name="find">string to find at the start</param>
        /// <param name="replace">string to use in place of the start</param>
        /// <returns>A string with the replaced start if it matched or the original string</returns>
        public static string ReplaceAtStart(this string s, string find, string replace)
        {
            if (!string.IsNullOrWhiteSpace(s) && s.StartsWith(find))
            {
                s = string.Concat(replace, s.TrimLeft(find.Length));
            }

            return s;
        }

        /// <summary>
        /// Replace the contents of the start of a string, character for character
        /// </summary>
        /// <param name="s">this string</param>
        /// <param name="replace">string to use in place of the start</param>
        /// <returns>A string with the start replaced with the characters supplied</returns>
        public static string ReplaceStartWith(this string s, string replace)
        {
            if (!string.IsNullOrWhiteSpace(s))
            {
                s = string.Concat(replace, s.TrimLeft(replace.Length));
            }

            return s;
        }

        /// <summary>
        /// Get the Right most 'size' items from a string
        /// </summary>
        /// <param name="s">this string</param>
        /// <param name="size">The size.</param>
        /// <returns>The right most [size] characters from the string</returns>
        public static string Right(this string s, int size)
        {
            string response = s;

            if (!string.IsNullOrEmpty(s))
            {
                int len = s.Length;

                if (size < len)
                {
                    response = s.Substring(len - size);
                }
            }

            return response;
        }

        /// <summary>
        /// Suffix a string with another string
        /// </summary>
        /// <param name="s">this string</param>
        /// <param name="add">The atring to be added as a suffix</param>
        /// <returns>A string combined string</returns>
        public static string Suffix(this string s, string add)
        {
            if (s == null) return add;
            return string.Concat(s, add);
        }

        /// <summary>
        /// Remove the right most 'size' items from a string
        /// </summary>
        /// <param name="s">this string</param>
        /// <param name="size">The size.</param>
        /// <returns>A string with the [szie] right most charcters removed or string.Empty</returns>
        public static string TrimRight(this string s, int size)
        {
            string response = s;

            if (!string.IsNullOrEmpty(s))
            {
                int len = s.Length;

                if (size < len)
                {
                    response = s.Substring(0, len - size);
                }
                else
                {
                    response = string.Empty;
                }
            }

            return response;
        }

        /// <summary>
        /// Replace the contents of the end of a string if they match
        /// </summary>
        /// <param name="s">this string</param>
        /// <param name="find">string to find at the end</param>
        /// <param name="replace">string to use in place of the end</param>
        /// <returns>A string with the end replaced with the characters supplied</returns>
        public static string ReplaceAtEnd(this string s, string find, string replace)
        {
            if (!string.IsNullOrWhiteSpace(s) && s.EndsWith(find))
            {
                s = string.Concat(s.TrimRight(find.Length), replace);
            }

            return s;
        }

        /// <summary>
        /// Replaces the contents of the end of a string (character for charcater)
        /// </summary>
        /// <param name="s">this string</param>
        /// <param name="replace">string to use in place of the end</param>
        /// <returns>A string with the end replaced with the characters supplied</returns>
        public static string ReplaceEndWith(this string s, string replace)
        {
            if (!string.IsNullOrWhiteSpace(s))
            {
                s = string.Concat(s.TrimRight(replace.Length), replace);
            }

            return s;
        }

        /// <summary>
        /// Get the Right most 'size' items from a string
        /// </summary>
        /// <param name="s">this string</param>
        /// <param name="start">The start.</param>
        /// <param name="end">The end.</param>
        /// <returns>the string located between the start and end strings supplied or the original string</returns>
        public static string Between(this string s, string start, string end)
        {
            string response = s;

            if (!string.IsNullOrEmpty(s))
            {
                int len = s.Length;

                int pos1 = s.IndexOf(start);
                int pos2 = s.LastIndexOf(end);

                if (pos1 != -1 && pos2 != -1 && (pos2 >= pos1))
                {
                    response = s.Substring(pos1 + start.Length, pos2 - pos1 - start.Length);
                }
            }

            return response;
        }

        public static string Splice(this string s, int pos1, int pos2, string contents)
        {
            string response = s;

            if (!string.IsNullOrEmpty(s))
            {
                int len = s.Length;

                if (pos1 > -1 && pos1 <= len && pos2 >= -1 && pos2 <= len && (pos2 > pos1))
                {
                    response = string.Concat(s.Substring(0, pos1), contents, s.Substring(pos2));
                }
            }

            return response;
        }

        /// <summary>
        /// Get the string 'Before' this sequence
        /// </summary>
        /// <param name="s">this string</param>
        /// <param name="find">The find.</param>
        /// <returns>The <see cref="System.String"/> that exists before the string passed in or the original string</returns>
        public static string Before(this string s, string find)
        {
            string response = s;

            if (!string.IsNullOrEmpty(s))
            {
                int len = s.Length;

                int pos1 = s.IndexOf(find);

                if (pos1 != -1)
                {
                    response = s.Substring(0, pos1);
                }
            }

            return response;
        }

        /// <summary>
        /// Get the string 'After' this sequence
        /// </summary>
        /// <param name="s">this string</param>
        /// <param name="find">The find.</param>
        /// <returns>the contents of the string that exist after the found string</returns>
        public static string After(this string s, string find)
        {
            string response = s;

            if (!string.IsNullOrEmpty(s))
            {
                int len = s.Length;

                int pos1 = s.IndexOf(find);

                if (pos1 != -1)
                {
                    response = s.Substring(pos1 + find.Length);
                }
            }

            return response;
        }

        /// <summary>
        /// Remove everything after the matching string
        /// </summary>
        /// <param name="s">this string</param>
        /// <param name="find">the string to be found</param>
        /// <returns>A <see cref="System.String"/> containing the text before the string found or the original string</returns>
        /// <returns></returns>
        public static string TrimAfter(this string s, string find)
        {
            if (s == null) return string.Empty;

            if (!string.IsNullOrWhiteSpace(s) && s.Contains(find))
            {
                int pos = s.IndexOf(find);
                s = s.Substring(0, pos + find.Length);
            }

            return s;
        }

        /// <summary>
        /// Remove everything before the matching string
        /// </summary>
        /// <param name="s">this string</param>
        /// <param name="find">The string to find</param>
        /// <returns>A <see cref="System.String"/> containing the text after the string found or the original string</returns>
        public static string TrimBefore(this string s, string find)
        {
            if (s == null) return string.Empty;

            if (!string.IsNullOrWhiteSpace(s) && s.Contains(find))
            {
                int pos = s.IndexOf(find);
                s = s.TrimLeft(pos);
            }

            return s;
        }

        /// <summary>
        /// Removed double spaces in the string leaving only a single space
        /// </summary>
        /// <param name="s">this string</param>
        /// <returns>A <see cref="System.String"/> containing the text after the spaces have been compressed</returns>
        public static string CompressSpaces(this string s)
        {
            if (s == null) return string.Empty;

            while (s.IndexOf("  ") != -1)
            {
                s = s.Replace("  ", " ");
            }

            return s;
        }

        /// <summary>
        /// Removes all whitespace charcters in a string 
        /// </summary>
        /// <param name="s">this string</param>
        /// <returns>The string without the whitespace</returns>
        public static string RemoveWhitespace(this string s)
        {
            if (s == null) return string.Empty;

            StringBuilder ret = new StringBuilder();

            char[] chars = s.ToCharArray();
            int len = chars.Length;

            for (var i = 0 ; i < len ; i++)
            {
                var ch = chars[i];

                // Append everytghing except whitespace
                if (!Char.IsWhiteSpace(ch))
                {
                    ret.Append(ch);
                }
            }

            return ret.ToString();
        }

        public static string PadLiterals(this string s)
        {
            StringBuilder ret = new StringBuilder();

            char[] chars = s.ToCharArray();
            int len = chars.Length;

            for (var i = 0 ; i < len ; i++)
            {
                var ch = chars[i];
                if (Char.IsLetterOrDigit(ch))
                {
                    ret.Append(ch);
                }
                else
                {
                    ret.AppendFormat("'{0}'", ch);
                }
            }

            return ret.ToString();
        }

        /// <summary>
        /// Count the number of times the string appears in the orginal string 
        /// </summary>
        /// <param name="s">this string</param>
        /// <param name="test">what to look for</param>
        /// <returns>The count of the number of times that the test string appears in the original</returns>
        public static int Count(this string s, string test)
        {
            int times = 0;

            if ( test.IsNotEmpty() )
            {
                int pos = s.IndexOf(test);
                while (pos != -1)
                {
                    ++times;
                    pos = ((pos + 1) >= s.Length) ? -1 : s.IndexOf(test, pos + 1);
                }
            }

            return times;
        }
    }
}