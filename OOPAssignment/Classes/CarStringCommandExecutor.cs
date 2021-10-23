using OOPAssignment.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPAssignment.Classes
{

   public class CarStringCommandExecutor : CarCommandExecutorBase, IStringCommand
    {
        public CarStringCommandExecutor(ICarCommand carCommand) : base(carCommand)
        {
        }

        public  void ExecuteCommand(string commandObject)
        {
            if (string.IsNullOrEmpty(commandObject))
            {
                throw new Exception("Lütfen Komut Giriniz");
            }

            foreach (char ch in commandObject)
            { 
               if (ch == 'M')
                {
                    CarCommand.Move();
                }

               else if (ch == 'L')
                {
                    CarCommand.TurnLeft();
                }

                else if (ch == 'R')
                {
                    CarCommand.TurnRight();
                }
               
                else
                {
                    throw new Exception("Yanlış Komut Girdiniz");
                }
            }
        }
    }
}
