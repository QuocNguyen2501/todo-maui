

namespace Todo.CustomControls;

public partial class StandardEntry: Entry
{
    public static readonly BindableProperty CornerRadiusProperty =
        BindableProperty.Create(nameof(CornerRadius), typeof(int), typeof(StandardEntry), 0);

    public static readonly BindableProperty BorderThicknessProperty =
        BindableProperty.Create(nameof(BorderThickness), typeof(int), typeof(StandardEntry), 0);

    public static readonly BindableProperty PaddingProperty =
        BindableProperty.Create(nameof(Padding), typeof(Thickness), typeof(StandardEntry), new Thickness());

    public static readonly BindableProperty BorderColorProperty =
        BindableProperty.Create(nameof(BorderColor), typeof(Color), typeof(StandardEntry), Colors.Transparent);





    public int CornerRadius
    {
        get => (int)GetValue(CornerRadiusProperty);
        set => SetValue(CornerRadiusProperty, value);
    }

    public int BorderThickness
    {
        get => (int)GetValue(BorderThicknessProperty);
        set => SetValue(BorderThicknessProperty, value);
    }


    public Color BorderColor
    {
        get => (Color)GetValue(BorderColorProperty);
        set => SetValue(BorderColorProperty, value);
    }

    public Thickness Padding
    {
        get => (Thickness)GetValue(PaddingProperty);
        set => SetValue(PaddingProperty, value);
    }
   
}
