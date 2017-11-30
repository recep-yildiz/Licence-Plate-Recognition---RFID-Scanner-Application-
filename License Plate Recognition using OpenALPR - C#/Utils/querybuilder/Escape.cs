using System.CodeDom;
using System.CodeDom.Compiler;
using System.IO;

namespace KOU_RFID_Plaka.Utils.QueryBuilder
{
    class Escape
    {
        public static string EscapeString(string input)
        {
            using (var writer = new StringWriter())
            {
                using (var provider = CodeDomProvider.CreateProvider("CSharp"))
                {
                    provider.GenerateCodeFromExpression(new CodePrimitiveExpression(input), writer, null);
                    return writer.ToString();
                }
            }
        }
    }
}
