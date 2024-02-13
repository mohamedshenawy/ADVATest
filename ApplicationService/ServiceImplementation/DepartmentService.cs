using AutoMapper;
using Domain.DTO;
using Domain.Entities;
using DomainService.Context;
using DomainService.UnitOfWork;

namespace ApplicationService.ServiceImplementation
{
    public class DepartmentService
    {
        private readonly IUnitOfWork<Context> _unitOfWork;
        private readonly IMapper _mapper;
        public DepartmentService(IUnitOfWork<Context> unitOfWork, IMapper mapper)
        {
            this._mapper = mapper;
            this._unitOfWork = unitOfWork;
        }

        public int Create(DepartmentDTO entity)
        {
            try
            {
                var model = _mapper.Map<Department>(entity);
                _unitOfWork.DepartmentRepo.Create(model);
                var result = _unitOfWork.Commit();
                return model.Id;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int Update(DepartmentDTO entity)
        {
            try
            {
                var model = _mapper.Map<Department>(entity);
                _unitOfWork.DepartmentRepo.Update(model);
                var result = _unitOfWork.Commit();
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public  int Delete(int Id)
        {
            try
            {
                var model = _unitOfWork.DepartmentRepo.GetWhere(e => e.Id == Id).SingleOrDefault();
                _unitOfWork.DepartmentRepo.Delete(model);
                var result = _unitOfWork.Commit();
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public IEnumerable<DepartmentDTO> GetAll()
        {
            try
            {
                var data = _unitOfWork.DepartmentRepo.GetAll(x => x.DepartmentManager);
                var mappedData = _mapper.Map<IEnumerable<DepartmentDTO>>(data);
                return mappedData;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public DepartmentDTO GetById(int id)
        {
            try
            {
                var data = _unitOfWork.DepartmentRepo.GetWhere(e => e.Id == id, x => x.DepartmentManager).SingleOrDefault();
                var mappedData = _mapper.Map<DepartmentDTO>(data);
                return mappedData;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}