using strange.extensions.context.impl;

namespace AST.GameOver
{
    public class GameOverContextRoot : ContextView
    {
        void Start()
        {
            context = new GameOverContext(this);
        }
    }
}
