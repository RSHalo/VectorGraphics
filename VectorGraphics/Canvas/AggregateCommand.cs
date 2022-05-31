using System.Collections.Generic;

namespace VectorGraphics.Canvas
{
    /// <summary>
    /// A command to encapsulate multiple commands that should be executed together.
    /// </summary>
    internal class AggregateCommand : ICanvasCommand
    {
        private readonly IEnumerable<ICanvasCommand> _commands;

        public AggregateCommand(IEnumerable<ICanvasCommand> commands)
        {
            _commands = commands;
        }

        public void Execute()
        {
            foreach (ICanvasCommand command in _commands)
            {
                command.Execute();
            }
        }

        public void Undo()
        {
            foreach (ICanvasCommand command in _commands)
            {
                command.Undo();
            }
        }
    }
}
