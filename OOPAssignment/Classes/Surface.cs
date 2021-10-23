using OOPAssignment.Interfaces;
using OOPAssignment.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPAssignment.Classes
{
   public class Surface: ISurface, ICollidableSurface, Interfaces.IObserver<CarInfo>
    {
		public long Width { get; set; }
		public long Height { get; set; }

		private readonly List<CarInfo> ObservableCars=new List<CarInfo>();
		public Surface(long width, long height) 
		{
			Width = width;
			Height = height;

		}
		public bool IsCoordinatesInBounds(Coordinates coordinates) {
			//araçların verilen komutlara göre koordinatları harita sınırı dahilinde mi kontrolü
			bool inBounds;
			if ((coordinates.X >= 0 && coordinates.X <= Width) && (coordinates.Y >= 0 && coordinates.Y <= Height))
			{
				inBounds = true;
			}
			else
				inBounds = false;

			return inBounds;
		}

		public bool IsCoordinatesEmpty(Coordinates coordinates) {
			//aynı koordinatlarda başka araç olup olmadığını kontrol ediyoruz
			if (ObservableCars != null)
			{
				foreach (var obscars in ObservableCars)
				{
					if (obscars.Coordinates.X == coordinates.X && obscars.Coordinates.Y == coordinates.Y)
						return false;
				}
			}
			return true;
		}
		public void Update(CarInfo provider) {
				if (IsCoordinatesInBounds(provider.Coordinates) == false)
				{
					throw new Exception("Araç Sınır Dışında");
				}
				else
				{
					var car = ObservableCars.FirstOrDefault(x => x.CarId == provider.CarId);
					var carList = GetObservables();

					if (carList.Contains(provider))
					{
						car = provider;
					}

					else if(IsCoordinatesEmpty(provider.Coordinates))
					{
						ObservableCars.Add(provider);
					}

					else 
					{
						if (car.Coordinates.X == provider.Coordinates.X && car.Coordinates.Y == provider.Coordinates.Y)

						{ throw new Exception("Aynı Konumda birden fazla araç var"); }
                    else
                    {
						ObservableCars.Add(provider);
                    }
							
					}
				}


		}


		public List<CarInfo> GetObservables() {
			List<CarInfo> carList = new List<CarInfo>();
			if (ObservableCars != null)
			{
				foreach (var car in ObservableCars)
					carList.Add(car);
			}
			return carList;
		}

	}
}
