using System.Text.RegularExpressions;
using System.Web;

namespace Education.Areas.Admin.Utilz
{
    public class Util
    {
        /// <summary>
        /// conver array to string with linkWord between words
        /// </summary>
        /// <param name="arrays"></param>
        /// <param name="linkWord"></param>
        /// <returns></returns>
        public static string Conver2String(string []arrays, char linkWord)
        {
            string result = "";
            if (arrays != null & arrays.Length >0)
            {
                for (int i = 0; i < arrays.Length; i++)
                {
                    if (i != arrays.Length - 1)
                    {
                        result += arrays[i] + ",";
                    }
                    else
                    {
                        result += arrays[i];
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Tạo Alias cho một chuỗi để SEO Url
        /// Ví dụ: bài giảng => bai-giang
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string GetSEOAlias(string input, int maxLength = 0)
        {
            if (string.IsNullOrEmpty(input))
            {
                return "";
            }
            input = RemoveVietnameseChar(input);
            input = Regex.Replace(input, @"[^A-Za-z0-9]", "-");
            input = input.Trim('-');
            input = Regex.Replace(input, @"\-+", "-");
            if (maxLength > 80 || maxLength <= 0)
            {
                maxLength = 80;
            }
            if (maxLength > 0 && input.Length > maxLength)
            {
                input = input.Substring(0, maxLength);
            }
            return input.ToLower();
        }

        /// <summary>
        /// Chuyển từ tiếng Việt có dấu => không dấu
        /// Ví dụ: bài giảng => bai giang
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string RemoveVietnameseChar(string input)
        {
            string strResult;
            strResult = Regex.Replace(input, "[à|á|ạ|ả|ã|â|ầ|ấ|ậ|ẩ|ẫ|ă|ằ|ắ|ặ|ẳ|ẵ]", "a");
            strResult = Regex.Replace(strResult, "[è|é|ẹ|ẻ|ẽ|ê|ề|ế|ệ|ể|ễ]", "e");
            strResult = Regex.Replace(strResult, "[ì|í|ị|ỉ|ĩ]", "i");
            strResult = Regex.Replace(strResult, "[ò|ó|ọ|ỏ|õ|ô|ồ|ố|ộ|ổ|ỗ|ơ|ờ|ớ|ợ|ở|ỡ]", "o");
            strResult = Regex.Replace(strResult, "[ù|ú|ụ|ủ|ũ|ư|ừ|ứ|ự|ử|ữ]", "u");
            strResult = Regex.Replace(strResult, "[ỳ|ý|ỵ|ỷ|ỹ]", "y");
            strResult = Regex.Replace(strResult, "[đ]", "d");
            strResult = Regex.Replace(strResult, "[À|Á|Ạ|Ả|Ã|Â|Ầ|Ấ|Ậ|Ẩ|Ẫ|Ă|Ằ|Ắ|Ặ|Ẳ|Ẵ]", "A");
            strResult = Regex.Replace(strResult, "[È|É|Ẹ|Ẻ|Ẽ|Ê|Ề|Ế|Ệ|Ể|Ễ]", "E");
            strResult = Regex.Replace(strResult, "[Ì|Í|Ị|Ỉ|Ĩ]", "I");
            strResult = Regex.Replace(strResult, "[Ò|Ó|Ọ|Ỏ|Õ|Ô|Ồ|Ố|Ộ|Ổ|Ỗ|Ơ|Ờ|Ớ|Ợ|Ở|Ỡ]", "O");
            strResult = Regex.Replace(strResult, "[Ù|Ú|Ụ|Ủ|Ũ|Ư|Ừ|Ứ|Ự|Ử|Ữ]", "U");
            strResult = Regex.Replace(strResult, "[Ỳ|Ý|Ỵ|Ỷ|Ỹ]", "Y");
            strResult = Regex.Replace(strResult, "[Đ]", "D");

            return strResult;
        }
    }
}