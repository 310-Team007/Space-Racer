using Unit06.Game.Casting;
using System.Collections.Generic;

namespace Unit06.Game.Scripting
{
    public class MoveRacketAction : Action
    {
        public MoveRacketAction()
        {
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            List<Actor> rackets_list = cast.GetActors(Constants.RACKET_GROUP);
            foreach (Racket racket in rackets_list)
            {
                Body body = racket.GetBody();
                Point position = body.GetPosition();
                Point velocity = body.GetVelocity();
                int x = position.GetX();

                position = position.Add(velocity);
                if (x < 0)
                {
                    position = new Point(0, position.GetY());
                }
                else if (x > Constants.SCREEN_WIDTH - Constants.RACKET_WIDTH)
                {
                    position = new Point(Constants.SCREEN_WIDTH - Constants.RACKET_WIDTH,
                        position.GetY());
                }

                body.SetPosition(position);
            }

        }
    }
}