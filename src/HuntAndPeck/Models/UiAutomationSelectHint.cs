using System;
using System.Windows;
using System.Runtime.InteropServices;
using UIAutomationClient;

namespace HuntAndPeck.Models
{
    /// <summary>
    /// Represents a Windows UI Automation based select hint
    /// </summary>
    internal class UiAutomationSelectHint : Hint
    {
        private readonly IUIAutomationSelectionItemPattern _selectPattern;

        [DllImport("user32.dll")]
        static extern bool SetCursorPos(int X, int Y);

        public UiAutomationSelectHint(IntPtr owningWindow, IUIAutomationSelectionItemPattern selectPattern, Rect boundingRectangle)
            : base(owningWindow, boundingRectangle)
        {
            _selectPattern = selectPattern;
        }

        public override void Invoke()
        {
            // Get the center of the hint bounding rectangle
            double centerX = BoundingRectangle.Left + (BoundingRectangle.Width / 2);
            double centerY = BoundingRectangle.Top + (BoundingRectangle.Height / 2);

            // Move the mouse cursor to the center of the hint bounding rectangle
            SetCursorPos((int)centerX, (int)centerY);

            // Select the item
            _selectPattern.Select();
        }
    }
}
