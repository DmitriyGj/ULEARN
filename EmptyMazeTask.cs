namespace Mazes
{
	public static class EmptyMazeTask
	{
		public static void MoveOut(Robot robot, int width, int height)
		{
			while (!robot.Finished)
			{
				if (robot.Y != height - 2)
					robot.MoveTo(Direction.Down);
				else
					if (robot.X != width - 2)
						robot.MoveTo(Direction.Right);
			}
		}
	}
}
