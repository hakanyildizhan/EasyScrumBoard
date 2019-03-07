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

        #endregion

        #region Properties

        public string Test { get; set; } = "Test string";

        #endregion

        public WindowViewModel(Window window)
        {
            _window = window;
        }
    }
}
