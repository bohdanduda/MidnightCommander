using System;

namespace FileManager
{
    public class PopUp
    {
        public ConsoleColor bgrColor = ConsoleColor.DarkRed;
        public int width = 10;
        public int height = 10;
        public int offsetLeft = 10;
        public int offsetTop = 10;
        
        public void DrawFrame()
        {
            Console.BackgroundColor = bgrColor;
            int left = offsetLeft;
            int top = offsetTop;
            Console.SetCursorPosition(left, top);
            top++;
            DrawBorderLine('┌', '─', '┐');
            for (int i = 2; i < this.width; i++)
            {
                Console.SetCursorPosition(left, top);
                top++;
                DrawBorderLine('│', ' ', '│');
            }
            Console.SetCursorPosition(left, top);
            top++;
            DrawBorderLine('└', '─', '┘');
        }

        // vypsání řádku okraje
        public void DrawBorderLine(char left, char middle, char right)
        {
            Console.Write(left);
            for (int i = 0; i < this.width; i++)
            {
                Console.Write(middle);
            }
            Console.Write(right);
        }

    }
}
