using System;

public abstract class GameUIState
{
    private GameView _view;

    public GameUIState(GameView view)
    {
        if(view == null)
            throw new ArgumentNullException(nameof(view));

        _view = view;
    }

    public void Open() => _view.Show();

    public void Close() => _view.Hide();
}
