using Unit06.Game.Casting;
using System.Collections.Generic;//Included to allow for lists
namespace Unit06.Game.Scripting
{
    public class MoveMeteorAction : Action
    {
        public MoveMeteorAction()
        {
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            List<Actor> brick_list = new List<Actor>(cast.GetActors(Constants.BRICK_GROUP));

        foreach (Brick brick in brick_list)
        { 
            Body body = brick.GetBody();
            Point position = body.GetPosition();
            Point velocity = body.GetVelocity();
            position = position.Add(velocity);
            body.SetPosition(position);
        }
        }
    }
}