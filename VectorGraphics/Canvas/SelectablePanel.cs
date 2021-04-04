using System.Windows.Forms;
using VectorGraphics.KeyHanding.Extensions;

/// <summary>
/// A selectable Panel control, modified from the solution found here:
/// https://stackoverflow.com/questions/3562235/panel-not-getting-focus
/// </summary>
public class SelectablePanel : Panel
{
    public SelectablePanel()
    {
        SetStyle(ControlStyles.Selectable, true);
        TabStop = true;
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
        Focus();
        base.OnMouseDown(e);
    }

    protected override bool IsInputKey(Keys keyData)
    {
        if (keyData.IsArrowKey())
        {
            return true;
        }
        return base.IsInputKey(keyData);
    }
}
