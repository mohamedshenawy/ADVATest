using AutoMapper;
using Domain.DTO;
using Domain.Entities;
using DomainService.Context;
using DomainService.UnitOfWork;

namespace ApplicationService.ServiceImplementation
{
    public class EmployeeService
    {
        private readonly IUnitOfWork<Context> _unitOfWork;
        private readonly IMapper _mapper;
        public EmployeeService(IUnitOfWork<Context> unitOfWork , IMapper mapper)
        {
            this._mapper = mapper;
            this._unitOfWork= unitOfWork;
        }

        public int Create(EmployeeDTO entity)
        {
            try
            {
                var model = _mapper.Map<Employee>(entity);
                _unitOfWork.EmployeeRepo.Create(model);
                var result = _unitOfWork.Commit();
                return model.Id;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int Update(EmployeeDTO entity)
        {
            try
            {
                var model = _mapper.Map<Employee>(entity);
                _unitOfWork.EmployeeRepo.Update(model);
                var result = _unitOfWork.Commit();
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public int Delete(int Id)
        {
            try
            {
                var model = _unitOfWork.EmployeeRepo.GetWhere(e => e.Id == Id, x => x.Manager, x => x.Department).SingleOrDefault();
                _unitOfWork.EmployeeRepo.Delete(model);
                var result = _unitOfWork.Commit();
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public IEnumerable<EmployeeDTO> GetAll()
        {
            try
            {
                var data = _unitOfWork.EmployeeRepo.GetAll(x=>x.Manager, x => x.Department);
                var mappedData = _mapper.Map<IEnumerable<EmployeeDTO>>(data);
                return mappedData;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public EmployeeDTO GetById(int id)
        {
            try
            {
                var data = _unitOfWork.EmployeeRepo.GetWhere(e => e.Id == id , x => x.Manager, x => x.Department).SingleOrDefault();
                var mappedData = _mapper.Map<EmployeeDTO>(data);
                return mappedData;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}