using System;

public abstract class GameUIState
{
    private IGameUI _view;

    public GameUIState(IGameUI view)
    {
        if(view == null)
            throw new ArgumentNullException(nameof(view));

        _view = view;
    }

    public virtual void Open() => _view.Show();

    public virtual void Close() => _view.Hide();
}
