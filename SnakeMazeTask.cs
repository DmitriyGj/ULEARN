namespace Mazes
{
	public static class SnakeMazeTask
	{
		public static void MoveOut(Robot robot, int width, int height)
		{
            while (!robot.Finished)
            {
				MoveToRight(robot,width,height);
				MoveToLeft(robot, width, height);
            }
		}
		
		static void MoveToRight(Robot robomover, int mazewidth,int mazeheight)
        {
			for (int i = 1; i != mazewidth-2; i++)
				robomover.MoveTo(Direction.Right);
			if (robomover.Y != mazeheight-2)
				for (int i = 0; i != 2; i++)
					robomover.MoveTo(Direction.Down);
        }
		
		static void MoveToLeft(Robot robomover, int mazewidth, int mazeheight)
        {
			for (int i = 1; i != mazewidth-2;i++)
				robomover.MoveTo(Direction.Left);
			if (robomover.Y != mazeheight - 2)
				for (int i = 0; i != 2; i++)
					robomover.MoveTo(Direction.Down);
        }
	}
}
