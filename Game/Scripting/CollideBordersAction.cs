using Unit06.Game.Casting;
using Unit06.Game.Services;
using System.Collections.Generic;


namespace Unit06.Game.Scripting
{
    public class CollideBordersAction : Action
    {
        private AudioService _audioService;
        private PhysicsService _physicsService;
        
        public CollideBordersAction(PhysicsService physicsService, AudioService audioService)
        {
            this._physicsService = physicsService;
            this._audioService = audioService;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            List<Actor> brick_list = cast.GetActors(Constants.BRICK_GROUP);
            foreach (Brick brick in brick_list)
            {
                Body body = brick.GetBody();
                Point position = body.GetPosition();
                int x = position.GetX();
                int y = position.GetY();
            
            // Ball ball = (Ball)cast.GetFirstActor(Constants.BALL_GROUP);
            // Body body = ball.GetBody();
            // Point position = body.GetPosition();
            // int x = position.GetX();
            // int y = position.GetY();
            // Sound bounceSound = new Sound(Constants.BOUNCE_SOUND);
            // Sound overSound = new Sound(Constants.OVER_SOUND);
                if (x < Constants.FIELD_LEFT)
                {
                    brick.BounceX();
                    // _audioService.PlaySound(bounceSound);
                }
                else if (x >= Constants.FIELD_RIGHT - Constants.BRICK_WIDTH)
                {
                    brick.BounceX();
                    // _audioService.PlaySound(bounceSound);
                }

                if (y < Constants.FIELD_TOP)
                {
                    brick.BounceY();
                    // _audioService.PlaySound(bounceSound);
                }
                else if (y >= Constants.FIELD_BOTTOM - Constants.BRICK_WIDTH)
                {
                    Stats stats = (Stats)cast.GetFirstActor(Constants.STATS_GROUP);
                    stats.RemoveLife();

                    if (stats.GetLives() > 0)
                    {
                        callback.OnNext(Constants.TRY_AGAIN);
                    }
                    else
                    {
                        callback.OnNext(Constants.GAME_OVER);
                        // _audioService.PlaySound(overSound);
                    }

                // if (x < Constants.FIELD_LEFT)
                // {
                //     ball.BounceX();
                //     _audioService.PlaySound(bounceSound);
                // }
                // else if (x >= Constants.FIELD_RIGHT - Constants.BALL_WIDTH)
                // {
                //     ball.BounceX();
                //     _audioService.PlaySound(bounceSound);
                // }

                // if (y < Constants.FIELD_TOP)
                // {
                //     ball.BounceY();
                //     _audioService.PlaySound(bounceSound);
                // }
                // else if (y >= Constants.FIELD_BOTTOM - Constants.BALL_WIDTH)
                // {
                //     Stats stats = (Stats)cast.GetFirstActor(Constants.STATS_GROUP);
                //     stats.RemoveLife();

                //     if (stats.GetLives() > 0)
                //     {
                //         callback.OnNext(Constants.TRY_AGAIN);
                //     }
                //     else
                //     {
                //         callback.OnNext(Constants.GAME_OVER);
                //         _audioService.PlaySound(overSound);
                //     }
                }
            }
            List<Actor> rockets = cast.GetActors(Constants.RACKET_GROUP);
            
            Racket rocket1 = (Racket)rockets[0];
            Racket rocket2 = (Racket)rockets[1];
            Body body1 = rocket1.GetBody();
            Point position1 = body1.GetPosition();
            int y1 = position1.GetY();

            Body body2 = rocket2.GetBody();
            Point position2 = body2.GetPosition();
            int y2 = position2.GetY();

            if (y1 <= 0)
            {
                // callback.OnNext(Constants.GAME_OVER);
                callback.OnNext(Constants.PLAYER1_WINS);
            }
            if (y2 <= 0)
            {
                // callback.OnNext(Constants.GAME_OVER);
                callback.OnNext(Constants.PLAYER2_WINS);
            }
        }
    }
}