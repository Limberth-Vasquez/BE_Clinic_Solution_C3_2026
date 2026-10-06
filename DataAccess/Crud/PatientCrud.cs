using DataAccess.Dao;
using DataAccess.Mappers;
using DTO;

namespace DataAccess.Crud
{
    public class PatientCrud : CrudFactory
    {
        private readonly PatientMapper _mapper;

        public PatientCrud()
        {
            _mapper = new PatientMapper();
            _sqldao = SqlDao.GetInstance();
        }
        public override void Create(BaseClass dto)
        {
            throw new NotImplementedException();
        }

        public override void Delete(BaseClass dto)
        {
            throw new NotImplementedException();
        }

        public override List<T> RetrieveAll<T>()
        {
            var operation = _mapper.GetRetrieveAllStatement();
            var results = _sqldao.ExecuteStoredProcedureWithQuery(operation);

            // paso 3 convertir los resultados en una lista de objeto T
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
