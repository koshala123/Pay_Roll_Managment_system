using Pay_Roll_Managment_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pay_Roll_Managment_System.BuisnessLogic
{
    public interface IPositionRepository
    {
        ICollection<Position> GetPositions();
        Position GetPosition(int GetPosition);
        bool PositionExsists(int PositionId);
        bool CreatePosition(Position position);
        bool UpdatePosition(Position position);
        bool DeletePosition(Position position);
        bool Save();
    }
}
