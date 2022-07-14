using System;
using cse210_05.Game.Casting;
using cse210_05.Game.Services;


namespace cse210_05.Game.Scripting
{
    /// <summary>
    /// <para>An input action that controls the snake.</para>
    /// <para>
    /// The responsibility of ControlActorsAction is to get the direction and move the snake's head.
    /// </para>
    /// </summary>
    public class ControlActorsAction : Action
    {
        private KeyboardService keyboardService;
        private Point direction1 = new Point(0, -Constants.CELL_SIZE);
        private Point direction2 = new Point(0, -Constants.CELL_SIZE);

        /// <summary>
        /// Constructs a new instance of ControlActorsAction using the given KeyboardService.
        /// </summary>
        public ControlActorsAction(KeyboardService keyboardService)
        {
            this.keyboardService = keyboardService;
        }

        /// <inheritdoc/>
        public override void Execute(Cast cast, Script script)
        {
            // left Player 1
            if (keyboardService.IsKeyDown("a"))
            {
                direction1 = new Point(-Constants.CELL_SIZE, 0);
            }

            // right Player 1
            if (keyboardService.IsKeyDown("d"))
            {
                direction1 = new Point(Constants.CELL_SIZE, 0);
            }

            // up Player 1
            if (keyboardService.IsKeyDown("w"))
            {
                direction1 = new Point(0, -Constants.CELL_SIZE);
            }

            // down Player 1
            if (keyboardService.IsKeyDown("s"))
            {
                direction1 = new Point(0, Constants.CELL_SIZE);
            }


            // left Player 2
            if (keyboardService.IsKeyDown("a"))
            {
                direction2 = new Point(-Constants.CELL_SIZE, 0);
            }

            // right Player 2
            if (keyboardService.IsKeyDown("d"))
            {
                direction2 = new Point(Constants.CELL_SIZE, 0);
            }

            // up Player 2
            if (keyboardService.IsKeyDown("w"))
            {
                direction2 = new Point(0, -Constants.CELL_SIZE);
            }

            // down Player 2
            if (keyboardService.IsKeyDown("s"))
            {
                direction2 = new Point(0, Constants.CELL_SIZE);
            }

            Cycle cycle1 = (Cycle)cast.GetFirstActor("cycle1");
            cycle1.TurnHead(direction1);
            Cycle cycle2 = (Cycle)cast.GetFirstActor("cycle2");
            cycle2.TurnHead(direction2);

        }
    }
}