using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EasyScrumBoard.ViewModel
{
    /// <summary>
    /// View model for custom flat window.
    /// </summary>
    public class WindowViewModel : BaseViewModel
    {
        #region Private Members

        /// <summary>
        /// Window that this view model controls.
        /// </summary>
        private Window _window;

        /// <summary>
        /// Actual window will be slightly larger than the visible window; the space in between will have a drop shadow. 
        /// This is the margin around the window to allow for that.
        /// </summary>
        private int _marginSize = 10;

        /// <summary>
        /// Radius for the edges of the main window.
        /// </summary>
        private int _windowRadius = 10;

        #endregion

        #region Properties

        /// <summary>
        /// The distance from the edge that the resize handle will appear
        /// </summary>
        public int ResizeBorder { get; set; } = 6;

        /// <summary>
        /// ResizeBorder to be used as a binding attribute.
        /// Distance of the handle should begin from the visible portion of the window, so we need to compensate for the Actual Margin Size.
        /// </summary>
        public Thickness ResizeBorderThickness { get { return new Thickness(ResizeBorder + ActualMarginSize); } }

        /// <summary>
        /// Actual margin around the window to allow for a drop shadow.
        /// When the window is maximized, the visible portion should touch the edges of the screen, and in this case no drop shadow (thus margin) will be needed.
        /// </summary>
        public int ActualMarginSize
        {
            get
            {
                return _window.WindowState == WindowState.Maximized ? 0 : _marginSize;
            }
            set
            {
                _marginSize = value;
            }
        }

        /// <summary>
        /// ActualMarginSize to be used as a binding attribute.
        /// </summary>
        public Thickness ActualMarginSizeThickness { get { return new Thickness(ActualMarginSize); } }

        /// <summary>
        /// Actual radius for the edges of the main window.
        /// When the window is maximized, the visible portion should touch the edges of the screen, and in this case the edges will not be rounded.
        /// </summary>
        public int WindowRadius
        {
            get
            {
                return _window.WindowState == WindowState.Maximized ? 0 : _windowRadius;
            }
            set
            {
                _windowRadius = value;
            }
        }

        /// <summary>
        /// WindowRadius to be used as a binding attribute.
        /// </summary>
        public CornerRadius WindowCornerRadius { get { return new CornerRadius(WindowRadius); } }

        /// <summary>
        /// Height of the title bar.
        /// </summary>
        public int TitleHeight { get; set; } = 42;

        #endregion

        public WindowViewModel(Window window)
        {
            _window = window;

            // Listen for resize
            _window.StateChanged += OnWindowStateChanged;
        }

        /// <summary>
        /// Fired when the window state changes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnWindowStateChanged(object sender, EventArgs e)
        {
            OnPropertyChanged(nameof(ResizeBorderThickness));
            OnPropertyChanged(nameof(ActualMarginSize));
            OnPropertyChanged(nameof(ActualMarginSizeThickness));
            OnPropertyChanged(nameof(WindowRadius));
            OnPropertyChanged(nameof(WindowCornerRadius));
        }
    }
}
