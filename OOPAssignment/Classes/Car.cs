using OOPAssignment.Enums;
using OOPAssignment.Interfaces;
using OOPAssignment.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPAssignment.Classes
{
    public class Car: ICarCommand, Interfaces.IObservable<CarInfo>
    {
		public Guid Id { get; }
		public Coordinates Coordinates;
		public Direction Direction;
		public ISurface Surface;

		private Interfaces.IObserver<CarInfo> Observer { get; set; }
		public Car(Coordinates coordinates, Direction direction, ISurface surface)
        {
			Coordinates = coordinates;
			Direction = direction;
			Surface = surface;
			//Id = Guid.NewGuid(); //generates unique values
		}
		public void TurnRight()
		{
			switch (Direction)
			{
				case Direction.N:
					Direction = Direction.E;
					break;

				case Direction.E:
					Direction = Direction.S;
					break;

				case Direction.S:
					Direction = Direction.W;
					break;

				case Direction.W:
					Direction = Direction.N;
					break;
			}
		}
		public void TurnLeft() {
			switch (Direction)
			{
				case Direction.N:
					Direction = Direction.W;
					break;

				case Direction.W:
					Direction = Direction.S;
					break;

				case Direction.S:
					Direction = Direction.E;
					break;

				case Direction.E:
					Direction = Direction.N;
					break;			
			}
		}
		public void Move() {
			switch (Direction)
			{
				case Direction.N:
					Coordinates.Y = Coordinates.Y + 1;
					break;
				case Direction.E:
					Coordinates.X = Coordinates.X + 1;
					break;
				case Direction.S:
					Coordinates.Y = Coordinates.Y - 1;
					break;
				case Direction.W:
					Coordinates.X = Coordinates.X - 1;
					break;

			}
			Notify();
		}
		public void Attach(Interfaces.IObserver<CarInfo> observer) {
			Observer = observer;
			Notify(); //notify includes Update method
		}
		public void Notify() {
			Observer.Update(new CarInfo(Id, Coordinates));
		}

	}
}
