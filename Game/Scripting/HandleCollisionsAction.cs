using System;
using System.Collections.Generic;
using System.Data;
using cse210_05.Game.Casting;
using cse210_05.Game.Services;


namespace cse210_05.Game.Scripting
{
    /// <summary>
    /// <para>An update action that handles interactions between the actors.</para>
    /// <para>
    /// The responsibility of HandleCollisionsAction is to handle the situation when the snake 
    /// collides with the food, or the snake collides with its segments, or the game is over.
    /// </para>
    /// </summary>
    public class HandleCollisionsAction : Action
    {
        private bool isGameOver = false;

        /// <summary>
        /// Constructs a new instance of HandleCollisionsAction.
        /// </summary>
        public HandleCollisionsAction()
        {
        }

        /// <inheritdoc/>
        public override void Execute(Cast cast, Script script)
        {
            if (isGameOver == false)
            {
                HandleSegmentCollisions(cast);
                HandleGameOver(cast);
            }
        }

        /// <summary>
        /// Sets the game over flag if the snake collides with one of its segments.
        /// </summary>
        /// <param name="cast">The cast of actors.</param>
        private void HandleSegmentCollisions(Cast cast)
        {
            Cycle cycle1 = (Cycle)cast.GetFirstActor("cycle1");
            Cycle cycle2 = (Cycle)cast.GetFirstActor("cycle2");
            Actor head1 = cycle1.GetHead();
            Actor head2 = cycle2.GetHead();
            List<Actor> body1 = cycle1.GetBody();
            List<Actor> body2 = cycle2.GetBody();

            foreach (Actor segment in body1)
            {
                if (segment.GetPosition().Equals(head2.GetPosition()))
                {
                    isGameOver = true;
                }
            }

            foreach (Actor segment in body2)
            {
                if (segment.GetPosition().Equals(head1.GetPosition()))
                {
                    isGameOver = true;
                }
            }
        }

        private void HandleGameOver(Cast cast)
        {
            if (isGameOver == true)
            {
                Cycle cycle = (Cycle)cast.GetFirstActor("cycle");
                List<Actor> segments = cycle.GetSegments();

                // create a "game over" message
                int x = Constants.MAX_X / 2;
                int y = Constants.MAX_Y / 2;
                Point position = new Point(x, y);

                Actor message = new Actor();
                message.SetText("Game Over!");
                message.SetPosition(position);
                cast.AddActor("messages", message);

                // make everything white
                foreach (Actor segment in segments)
                {
                    segment.SetColor(Constants.WHITE);
                }
            }
        }

    }
}