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
        /// This is the padding from the outer edge to the inner visible portion of the window to allow for that.
        /// </summary>
        private int _paddingSize = 10;

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
        /// Distance of the handle should begin from the visible portion of the window, so we need to compensate for the Actual Padding Size.
        /// </summary>
        public Thickness ResizeBorderThickness { get { return new Thickness(ResizeBorder + ActualPaddingSize); } }

        /// <summary>
        /// Actual padding from the outer edge to the inner visible portion of the window to allow for a drop shadow.
        /// When the window is maximized, the visible portion should touch the edges of the screen, and in this case no drop shadow (thus padding) will be needed.
        /// </summary>
        public int ActualPaddingSize
        {
            get
            {
                return _window.WindowState == WindowState.Maximized ? 0 : _paddingSize;
            }
            set
            {
                _paddingSize = value;
            }
        }

        /// <summary>
        /// ActualPaddingSize to be used as a binding attribute.
        /// </summary>
        public Thickness ActualPaddingSizeThickness { get { return new Thickness(ActualPaddingSize); } }

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

        /// <summary>
        /// TitleHeight to be used as a binding attribute.
        /// </summary>
        public GridLength TitleHeightGridLength { get { return new GridLength(TitleHeight); } }

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
            OnPropertyChanged(nameof(ActualPaddingSize));
            OnPropertyChanged(nameof(ActualPaddingSizeThickness));
            OnPropertyChanged(nameof(WindowRadius));
            OnPropertyChanged(nameof(WindowCornerRadius));
        }
    }
}
