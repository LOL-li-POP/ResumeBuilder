using PdfSharp.Drawing;

namespace ResumeBuilder.Utilities
{
    public static class PdfMultiLineUtility
    {
        public static double DrawMultilineText(XGraphics gfx, string text, XFont font, XBrush brush, XPoint startPoint, double lineHeight)
        {
            string[] lines = text.Split('\n');

            double currentY = startPoint.Y;

            foreach (string line in lines)
            {
                gfx.DrawString(line, font, brush, new XPoint(startPoint.X, currentY));

                currentY += lineHeight;
            }

            return currentY;
        }
    }
}
