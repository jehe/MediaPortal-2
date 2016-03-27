using MediaPortal.UI.SkinEngine.Controls.Visuals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX;

namespace MediaPortal.UiComponents.RisingSkin.Controls
{
  public class SubItemsContentPresenter : ScrollContentPresenter
  {
    public override void BringIntoView(UIElement element, RectangleF elementBounds)
    {
      if (AutoCentering != ScrollAutoCenteringEnum.None)
      {
        //disable auto centering if using mouse, prevents items from scrolling
        FrameworkElement frameworkElement = element as FrameworkElement;
        if (frameworkElement != null && frameworkElement.IsMouseOver)
          return;
      }
      base.BringIntoView(element, elementBounds);
    }
  }
}
