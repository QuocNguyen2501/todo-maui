using Microsoft.Maui.Handlers;
using Todo.CustomControls;
using UIKit;
using Microsoft.Maui.Platform;
using CoreGraphics;

namespace Todo.Platforms;

public static class EntryMapper
{
    public static void Map(IElementHandler handler, IElement view)
    {
        if (view is StandardEntry)
        { 
            var casted = (EntryHandler)handler;
            var viewData = (StandardEntry)view;

            UpdateBackground(casted.PlatformView, viewData);

            var paddingViewLeft = new UIView(new CGRect(0, 0, 10, 0));
            casted.PlatformView.LeftView = paddingViewLeft;
            casted.PlatformView.LeftViewMode = UITextFieldViewMode.Always;

            var paddingViewRight = new UIView(new CGRect(0, 0, 10, 0));
            casted.PlatformView.RightView = paddingViewRight;
            casted.PlatformView.RightViewMode = UITextFieldViewMode.Always;

        }
    }

    public static void UpdateBackground(UITextField control, StandardEntry entry)
    {
        if (control is null) return;

        control.Layer.CornerRadius = entry.CornerRadius;
        control.Layer.BorderWidth = entry.BorderThickness;
        control.Layer.BorderColor = entry.BorderColor.ToCGColor();
        control.BorderStyle = UITextBorderStyle.Line;
    }
}
