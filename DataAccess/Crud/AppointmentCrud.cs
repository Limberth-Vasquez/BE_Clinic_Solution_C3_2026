using DataAccess.Dao;
using DataAccess.Mappers;
using DTO;

namespace DataAccess.Crud
{
    public class AppointmentCrud : CrudFactory
    {

        AppointmentMapper _mapper;

        public AppointmentCrud() 
        {
            _mapper = new AppointmentMapper();
            _sqldao = SqlDao.GetInstance();
        }
        public override void Create(BaseClass dto)
        {
            var operacion = _mapper.GetCreateStatement(dto);
            _sqldao.ExecuteStoredProcedure(operacion);
        }

        public override void Delete(BaseClass dto)
        {
            throw new NotImplementedException();
        }

        public override List<T> RetrieveAll<T>()
        {
            throw new NotImplementedException();
        }

        public override T RetrieveById<T>(int pId)
        {
            throw new NotImplementedException();
        }

        public override void Update(BaseClass dto)
        {
            throw new NotImplementedException();
        }
    }
}
