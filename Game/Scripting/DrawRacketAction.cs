using Unit06.Game.Casting;
using Unit06.Game.Services;
using System.Collections.Generic;


namespace Unit06.Game.Scripting
{
    public class DrawRacketAction : Action
    {
        private VideoService _videoService;

        public DrawRacketAction(VideoService videoService)
        {
            this._videoService = videoService;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            List<Actor> rackets_list = cast.GetActors(Constants.RACKET_GROUP);
            foreach (Racket racket in rackets_list)
            {
                Body body = racket.GetBody();

                if (racket.IsDebug())
                {
                    Rectangle rectangle = body.GetRectangle();
                    Point size = rectangle.GetSize();
                    Point pos = rectangle.GetPosition();
                    _videoService.DrawRectangle(size, pos, Constants.PURPLE, false);
                }

                Animation animation = racket.GetAnimation();
                Image image = animation.NextImage();
                Point position = body.GetPosition();
                _videoService.DrawImage(image, position);
            }



        }
    }
}