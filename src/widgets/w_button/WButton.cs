using Godot;
using System;

public class WButton : Button
{
    private Action _OnClick;
    public Action OnClick {
        get { return _OnClick; }
        set { SetOnClick(value); }
    }

    private void SetOnClick(Action action)
    {
        _OnClick = action;
        Connect("pressed", this, nameof(OnClickHandler));
    }

    private void OnClickHandler()
    {
        if (_OnClick != null)
        {
            _OnClick();
        }
    }
}
