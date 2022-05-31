using System.Collections.Generic;

namespace VectorGraphics.Canvas
{
    /// <summary>
    /// A command to encapsulate multiple commands that should be executed together.
    /// </summary>
    internal class AggregateCommand : ICanvasCommand
    {
        private readonly List<ICanvasCommand> _commands = new List<ICanvasCommand>();

        public AggregateCommand()
        {

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

        public void Add(ICanvasCommand command)
        {
            _commands.Add(command);
        }
    }
}
