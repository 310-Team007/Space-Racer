using System.Collections.Generic;
using Unit06.Game.Casting;
using Unit06.Game.Services;


namespace Unit06.Game.Scripting
{
    public class CollideBrickAction : Action
    {
        private AudioService _audioService;
        private PhysicsService _physicsService;
        
        public CollideBrickAction(PhysicsService physicsService, AudioService audioService)
        {
            this._physicsService = physicsService;
            this._audioService = audioService;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            List<Actor> rockets = cast.GetActors(Constants.RACKET_GROUP);
            List<Actor> rocks_list = cast.GetActors(Constants.BRICK_GROUP);
            Stats stats = (Stats)cast.GetFirstActor(Constants.STATS_GROUP);

            Racket rocket1 = (Racket)rockets[0];
            Racket rocket2 = (Racket)rockets[1];
            
            foreach (Actor actor in rocks_list)
            {
                Brick rock = (Brick)actor;
                Body rockBody = rock.GetBody();
                Body rocket1Body = rocket1.GetBody();
                Body rocket2Body = rocket2.GetBody();

                if (_physicsService.HasCollided(rockBody, rocket1Body))
                {
                    rocket1Body.SetPosition(new Point(Constants.RACKET1_STARTX, Constants.SCREEN_HEIGHT - Constants.RACKET_HEIGHT));
                    // rocket1.BounceY();
                    // Sound sound = new Sound(Constants.BOUNCE_SOUND);
                    // _audioService.PlaySound(sound);
                    // int points = brick.GetPoints();
                    // stats.AddPoints(points);
                    // cast.RemoveActor(Constants.BRICK_GROUP, brick);
                }

                if (_physicsService.HasCollided(rockBody, rocket2Body))
                {
                    rocket2Body.SetPosition(new Point(Constants.RACKET2_STARTX, Constants.SCREEN_HEIGHT - Constants.RACKET_HEIGHT));
                    // ball.BounceY();
                    // Sound sound = new Sound(Constants.BOUNCE_SOUND);
                    // _audioService.PlaySound(sound);
                    // int points = brick.GetPoints();
                    // stats.AddPoints(points);
                    // cast.RemoveActor(Constants.BRICK_GROUP, brick);
                }
            }
        }
    }
}