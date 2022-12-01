using Unit06.Game.Casting;
using Unit06.Game.Services;
using System.Collections.Generic;


namespace Unit06.Game.Scripting
{
    public class ControlRacketAction : Action
    {
        private KeyboardService _keyboardService;

        public ControlRacketAction(KeyboardService keyboardService)
        {
            this._keyboardService = keyboardService;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            List<Actor> rackets_list = cast.GetActors(Constants.RACKET_GROUP);
            Racket racket1 = (Racket)rackets_list[0];
            Racket racket2 = (Racket)rackets_list[1];
            if (_keyboardService.IsKeyDown(Constants.LEFT))
            {
                racket1.SwingLeft();
            }
            else if (_keyboardService.IsKeyDown(Constants.RIGHT))
            {
                racket1.SwingRight();
            }
            else if (_keyboardService.IsKeyDown(Constants.UP))
            {
                racket1.SwingUp();
            }
            else if (_keyboardService.IsKeyDown(Constants.DOWN))
            {
                racket1.SwingDown();
            }
            else
            {
                racket1.StopMoving();
            }

            // move second racket
            if (_keyboardService.IsKeyDown("a"))
            {
                racket2.SwingLeft();
            }
            else if (_keyboardService.IsKeyDown("d"))
            {
                racket2.SwingRight();
            }
            else if (_keyboardService.IsKeyDown("w"))
            {
                racket2.SwingUp();
            }
            else if (_keyboardService.IsKeyDown("s"))
            {
                racket2.SwingDown();
            }
            else
            {
                racket2.StopMoving();
            }
        }
    }
}