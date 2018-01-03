using System;
using System.Text;

namespace SchrijvenOpAfbeelding.ExtensionMethods
{
    public static class ExtensionMethods
    {
        public static StringBuilder NewLine(this StringBuilder sb)
        {
            return sb.Append(Environment.NewLine);
        }

        public static StringBuilder NewLine(this StringBuilder sb, int numberOfLines)
        {
            for (int i = 0; i < numberOfLines; i++)
            {
                sb.Append(Environment.NewLine);
            }

            return sb;
        }

        public static StringBuilder HorizontalSplit(this StringBuilder sb, int width = 30)
        {
            for (int i = 0; i < width; i++)
            {
                sb.Append("-");
            }

            return sb.NewLine();
        }
    }
}
