using strange.extensions.context.impl;

namespace AST.GameOver
{
    public class GameOverContextRoot : ContextView
    {
        void Awake()
        {
            context = new GameOverContext(this);
        }
    }
}
