using Unit06.Game.Casting;
using Unit06.Game.Services;
using System.Collections.Generic;


namespace Unit06.Game.Scripting
{
    public class CollideRacketAction : Action
    {
        private AudioService _audioService;
        private PhysicsService _physicsService;
        
        public CollideRacketAction(PhysicsService physicsService, AudioService audioService)
        {
            this._physicsService = physicsService;
            this._audioService = audioService;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            Ball ball = (Ball)cast.GetFirstActor(Constants.BALL_GROUP);
            List<Actor> rackets_list = cast.GetActors(Constants.RACKET_GROUP);
            Racket racket1 = (Racket)rackets_list[0];
            Racket racket2 = (Racket)rackets_list[1];
            Body ballBody = ball.GetBody();
            Body racketBody1 = racket1.GetBody();
            Body racketBody2 = racket2.GetBody();

            if (_physicsService.HasCollided(racketBody1, ballBody) || _physicsService.HasCollided(racketBody2, ballBody ))
            {
                ball.BounceY();
                Sound sound = new Sound(Constants.BOUNCE_SOUND);
                _audioService.PlaySound(sound);
            }
        }
    }
}