using PdfSharp.Drawing;
using System.Collections.Generic;
using System.Text;

namespace ResumeBuilder.Utilities
{
    public class PdfWrapTextUtility
    {
        // Rysuje tekst zawijany w obrębie określonego prostokąta
        public static void DrawWrappedText(XGraphics gfx, string text, XFont font, XBrush brush, XRect rect, XStringFormat format)
        {
            // Oblicz wysokość linii
            double lineHeight = font.GetHeight();
            double currentY = rect.Y;

            // Podziel tekst na linie
            string[] lines = SplitTextIntoLines(gfx, text, font, rect.Width);

            foreach (string line in lines)
            {
                // Rysuj każdą linię
                gfx.DrawString(line, font, brush, new XRect(rect.X, currentY, rect.Width, lineHeight), format);
                currentY += lineHeight;

                // Jeśli tekst nie mieści się w prostokącie, zatrzymaj rysowanie
                if (currentY > rect.Y + rect.Height)
                {
                    break;
                }
            }
        }

        // Dzieli tekst na linie, aby pasował do maksymalnej szerokości
        private static string[] SplitTextIntoLines(XGraphics gfx, string text, XFont font, double maxWidth)
        {
            List<string> lines = new List<string>();
            string[] words = text.Split(' ');
            StringBuilder lineBuilder = new StringBuilder();

            foreach (string word in words)
            {
                // Sprawdzamy, czy aktualna linia po dodaniu nowego słowa nie przekroczy szerokości
                string testLine = lineBuilder.Length > 0 ? lineBuilder.ToString() + " " + word : word;
                double lineWidth = gfx.MeasureString(testLine, font).Width;

                if (lineWidth > maxWidth)
                {
                    // Dodajemy bieżącą linię do listy, jeśli przekracza szerokość
                    lines.Add(lineBuilder.ToString());
                    lineBuilder.Clear();
                    lineBuilder.Append(word);
                }
                else
                {
                    // Dodajemy słowo do linii
                    if (lineBuilder.Length > 0)
                    {
                        lineBuilder.Append(" ");
                    }
                    lineBuilder.Append(word);
                }
            }

            // Dodajemy ostatnią linię
            if (lineBuilder.Length > 0)
            {
                lines.Add(lineBuilder.ToString());
            }

            return lines.ToArray();
        }
        public static double CalculateTextHeight(XGraphics gfx, string text, XFont font, double maxWidth)
        {
            string[] lines = SplitTextIntoLines(gfx, text, font, maxWidth);
            double lineHeight = font.GetHeight();
            return lines.Length * lineHeight;
        }

    }
}
