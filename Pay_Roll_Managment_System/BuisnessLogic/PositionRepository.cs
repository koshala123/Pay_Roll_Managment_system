using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pay_Roll_Managment_System.Models;

namespace Pay_Roll_Managment_System.BuisnessLogic
{
    public class PositionRepository : IPositionRepository
    {
        private PayRollManagmentContext _PositionContext;
        public PositionRepository(PayRollManagmentContext PositionContext)
        {
            _PositionContext = PositionContext;
        }
        public bool CreatePosition(Position position)
        {
            _PositionContext.Positions.Add(position);
            return Save();
        }

        public bool DeletePosition(Position position)
        {
            _PositionContext.Positions.Remove(position);
            return Save();
        }

        public Position GetPosition(int GetPosition)
        {
            return _PositionContext.Positions.Where(a => a.PositionId == GetPosition).FirstOrDefault();
        }

        public ICollection<Position> GetPositions()
        {
            return _PositionContext.Positions.OrderBy(a => a.PositionId).ToList();
        }

        public bool PositionExsists(int PositionId)
        {
            return _PositionContext.Positions.Any(a => a.PositionId == PositionId);
        }

        public bool Save()
        {
            var save = _PositionContext.SaveChanges();
            return save >= 0 ? true:false;
        }

        public bool UpdatePosition(Position position)
        {
            _PositionContext.Positions.Update(position);
            return Save();
        }
    }
}
