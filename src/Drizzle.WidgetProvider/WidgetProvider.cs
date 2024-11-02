using Microsoft.Windows.Widgets.Providers;
using System;

namespace Drizzle.WidgetProvider
{
    public class WidgetProvider : IWidgetProvider
    {
        public void Activate(WidgetContext widgetContext)
        {
            // Handle widget activation
        }

        public void Deactivate(WidgetContext widgetContext)
        {
            // Handle widget deactivation
        }

        public void OnActionInvoked(WidgetActionInvokedArgs actionInvokedArgs)
        {
            // Handle widget action invoked
        }

        public void OnWidgetContextChanged(WidgetContextChangedArgs contextChangedArgs)
        {
            // Handle widget context changed
        }
    }
}
