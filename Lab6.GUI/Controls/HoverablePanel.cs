
using System.ComponentModel;

namespace Lab6.GUI.Controls;

internal class HoverablePanel : Panel
{
	protected override void OnMouseEnter(EventArgs e)
	{
		base.OnMouseEnter(e);
		Expand();
	}
	protected override void OnMouseLeave(EventArgs e)
	{
		Collapse();
		base.OnMouseLeave(e);
	}

	void Expand()
	{
		this.Size = this.MaximumSize;
	}
	void Collapse()
	{
		this.Size = this.MinimumSize;
	}
}
