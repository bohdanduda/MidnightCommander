using System;

namespace HotKeyActions
{
    public abstract class PopUp
    {
        public ConsoleColor bgrColor = ConsoleColor.DarkRed;
        public int width;
        public int height;
        public int offsetLeft;
        public int offsetTop;

        public void DrawFrame()
        {
            Console.BackgroundColor = bgrColor;
            int left = this.offsetLeft;
            int top = this.offsetTop;
            Console.SetCursorPosition(left, top);
            top++;
            DrawBorderLine('┌', '─', '┐');
            for (int i = 2; i < this.height; i++)
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
