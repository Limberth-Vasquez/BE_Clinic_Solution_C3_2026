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

        public List<T> RetrieveAllByPatientId<T>(int patientId)
        {
            var operacion = _mapper.RetrieveAllByPatientId(patientId);
            //paso 1 pedir la operacion al mapper

            var results = _sqldao.ExecuteStoredProcedureWithQuery(operacion);
            //paso 2 ejecutar la operacion en la base de datos y obtener los resultados

            //paso 3 convertir los resultados en una lista de objeto T
            var resultList = new List<T>();
            if (results.Count > 0)
            {
                var dtoList = _mapper.BuildObjects(results); // aca le devuelve la lista de BaseClass
                foreach (var item in dtoList)
                {
                    resultList.Add((T)Convert.ChangeType(item, typeof(T)));
                }
            }

            return resultList;
        }
    }
}
