using System;
using System.Windows.Forms;
using VectorGraphics.KeyHanding.Extensions;

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
