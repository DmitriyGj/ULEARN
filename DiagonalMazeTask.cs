namespace Mazes
{
	public static class DiagonalMazeTask
	{
		public static void MoveOut(Robot robot, int width, int height)
		{
			while (!robot.Finished)
			{
				if (width > height)
					MoveByWidth(robot, width, height);
				else  
					MoveByHeight(robot, width, height);
			}
		}
		
		static void MoveByWidth(Robot robot, int width, int height)
		{
			int countOfSteps = width / (height - 1);
			for (int i = 0; i != countOfSteps; i++)
				robot.MoveTo(Direction.Right);
			if (!robot.Finished)
				robot.MoveTo(Direction.Down);
		}
		
		static void MoveByHeight(Robot robot, int width, int height)
		{
			int countOfSteps = height / (width - 1);
			for (int i = 0; i != countOfSteps; i++)
				robot.MoveTo(Direction.Down);
			if (!robot.Finished)
				robot.MoveTo(Direction.Right);
		}
	}
}
