using System;
using System.Collections.Generic;
using cse210_05.Game.Casting;
using cse210_05.Game.Services;


namespace cse210_05.Game.Scripting
{
    /// <summary>
    /// <para>An output action that draws all the actors.</para>
    /// <para>The responsibility of DrawActorsAction is to draw each of the actors.</para>
    /// </summary>
    public class DrawActorsAction : Action
    {
        private VideoService videoService;

        /// <summary>
        /// Constructs a new instance of ControlActorsAction using the given KeyboardService.
        /// </summary>
        public DrawActorsAction(VideoService videoService)
        {
            this.videoService = videoService;
        }

        /// <inheritdoc/>
        public override void Execute(Cast cast, Script script)
        {
            Cycle cycle1 = (Cycle)cast.GetFirstActor("cycle1");
            List<Actor> segments1 = cycle1.GetSegments();
            Cycle cycle2 = (Cycle)cast.GetFirstActor("cycle2");
            List<Actor> segments2 = cycle2.GetSegments();
            Actor score = cast.GetFirstActor("score");
            List<Actor> messages = cast.GetActors("messages");
            
            videoService.ClearBuffer();
            videoService.DrawActors(segments1);
            videoService.DrawActors(segments2);
            videoService.DrawActor(score);
            videoService.DrawActors(messages);
            videoService.FlushBuffer();
        }
    }
}