using strange.extensions.context.impl;

namespace AST.Game
{
    public class GameContextRoot : ContextView
    {
        void Start()
        {
            context = new GameContext(this);
        }
    }
}
