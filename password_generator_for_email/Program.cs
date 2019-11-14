using System;
using System.Linq;
using System.Web;

namespace password_generator_for_email
{
    class Program
    {
        static void Main(string[] args)
        {
            string mailDetail;
            Console.Write("メールの件名：");
            string mailTitle = Console.ReadLine();
            if (mailTitle == null) mailTitle = null;

            Console.Write("ファイル名：");
            string fileName = Console.ReadLine();
            if (fileName == null) fileName = null;

            Console.Write("パスワードの長さ：");
            var passwordLength = Console.ReadLine();
            while((passwordLength == "") || (passwordLength == null))
            {
                passwordLength = "8";
            }
            var length = int.Parse(passwordLength);

            Console.WriteLine("文字パターン No.1 : 0123456789");
            Console.WriteLine("文字パターン No.2 : 0123456789abcdefghijklmnopqrstuvwxyz");
            Console.WriteLine("文字パターン No.3 : 0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ");
            Console.WriteLine(@"文字パターン No.4 : 0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ12#$%&'()+,._=@[]^_`{}~");
            Console.Write("文字パターン番号：");
            var charType = Console.ReadLine();
            while ((charType == "") || (charType == null))
            {
                charType = "1";
            }
            var type = int.Parse(charType);

            var password = passwordJenerat(length, type);

            Console.WriteLine("設定内容");
            Console.WriteLine("件名 : {0}", mailTitle);
            Console.WriteLine("ファイル名 : {0}", fileName);
            Console.WriteLine("パスワードの長さ : {0}", length);
            Console.WriteLine("文字パターン : {0}", type);

            mailDetail = $@"===============================================
        添付ファイルパスワードのお知らせ
===============================================

先程送りましたメールの添付ファイルのパスワードをお知らせします。

 [件名] {mailTitle}
 [ファイル名] {fileName}
 [パスワード] {password}";

            Console.WriteLine("\n↓↓↓↓↓  通知メール  ↓↓↓↓↓\n");
            Console.WriteLine(mailDetail);

            Console.WriteLine("\n\n\n --> メール内容をクリップボードにコピーしました。");
            Console.WriteLine("\nこのウィンドウを閉じるには任意のキーを押してください . . .");
            TextCopy.Clipboard.SetText(mailDetail);
            Console.ReadKey();
        }

        static string passwordJenerat(int passwordLength = 8, int charType = 1)
        {
            string password = null;
            string passwordchar = null;
            int Length = passwordLength;

            var PWD_CHR_1 = "0123456789";
            var PWD_CHR_2 = "0123456789abcdefghijklmnopqrstuvwxyz";
            var PWD_CHR_3 = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var PWD_CHR_4 = @"0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ12#$%&'()+,._=@[]^_`{}~";
            var random = new Random();

            passwordchar = charType switch
            {
                1 => PWD_CHR_1,
                2 => PWD_CHR_2,
                3 => PWD_CHR_3,
                4 => PWD_CHR_4,
                _ => PWD_CHR_1,
            };
            password = string.Join("", Enumerable.Range(0, Length).Select(_ => passwordchar[random.Next(passwordchar.Length)]));

            return password;
        }
    }
}
