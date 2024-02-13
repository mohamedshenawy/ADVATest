using AutoMapper;
using Domain.DTO;
using Domain.Entities;
using DomainService.UnitOfWork;
using System.Linq.Expressions;

namespace ApplicationService.ServiceImplementation
{
    public class EmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public EmployeeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public int Create(EmployeeDTO entity)
        {
            var model = _mapper.Map<Employee>(entity);
            _unitOfWork.EmployeeRepo.Create(model);
            var result = _unitOfWork.Commit();
            return model.Id;
        }

        public int Update(EmployeeDTO entity)
        {
            var model = _mapper.Map<Employee>(entity);
            _unitOfWork.EmployeeRepo.Update(model);
            var result = _unitOfWork.Commit();
            return result;
        }
        public int Delete(int Id)
        {
            var model = _unitOfWork.EmployeeRepo.GetWhere(e => e.Id == Id).SingleOrDefault();
            _unitOfWork.EmployeeRepo.Delete(model);
            var result = _unitOfWork.Commit();
            return result;
        }
        public IEnumerable<EmployeeDTO> GetAll()
        {
            var data = _unitOfWork.EmployeeRepo.GetAll(x => x.Manager, x => x.Department);
            var mappedData = _mapper.Map<IEnumerable<EmployeeDTO>>(data);
            return mappedData;
        }
        public IEnumerable<EmployeeDTO> GetManagers()
        {
            var data = _unitOfWork.EmployeeRepo.GetWhere(e => e.IsManager == true, x => x.Department);
            var mappedData = _mapper.Map<IEnumerable<EmployeeDTO>>(data);
            return mappedData;
        }
        public EmployeeDTO GetById(int id)
        {
            var data = _unitOfWork.EmployeeRepo.GetWhere(e => e.Id == id, x => x.Manager, x => x.Department).SingleOrDefault();
            var mappedData = _mapper.Map<EmployeeDTO>(data);
            return mappedData;
        }
        public int GetWhereCount(Expression<Func<Employee, bool>> where)
        {
            var count = _unitOfWork.EmployeeRepo.GetWhere(where).Count();
            return count;
        }

    }
}