using strange.extensions.context.impl;

namespace AST.Game
{
    public class GameContextRoot : ContextView
    {
        void Awake()
        {
            context = new GameContext(this);
        }
    }
}
