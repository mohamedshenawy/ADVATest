using AutoMapper;
using Domain.DTO;
using Domain.Entities;
using DomainService.UnitOfWork;
using System.Linq.Expressions;

namespace ApplicationService.ServiceImplementation
{
    public class DepartmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public DepartmentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public int Create(DepartmentDTO entity)
        {
            var model = _mapper.Map<Department>(entity);
            _unitOfWork.DepartmentRepo.Create(model);
            var result = _unitOfWork.Commit();

            return model.Id;
        }

        public int Update(DepartmentDTO entity)
        {
            var model = _mapper.Map<Department>(entity);
            
            _unitOfWork.DepartmentRepo.Update(model);
            var result = _unitOfWork.Commit();
            
            return result;
        }

        public  int Delete(int Id)
        {
            var model = _unitOfWork.DepartmentRepo.GetWhere(e => e.Id == Id).SingleOrDefault();
            
            _unitOfWork.DepartmentRepo.Delete(model);
            var result = _unitOfWork.Commit();
            
            return result;
        }

        public IEnumerable<DepartmentDTO> GetAll()
        {
            var data = _unitOfWork.DepartmentRepo.GetAll(x => x.DepartmentManager);
            var mappedData = _mapper.Map<IEnumerable<DepartmentDTO>>(data);
            
            return mappedData;
        }

        public IEnumerable<DepartmentDTO> GetWhere(Expression<Func<Department, bool>> where)
        {
            var data = _unitOfWork.DepartmentRepo.GetWhere(where);
            var mappedData = _mapper.Map<IEnumerable<DepartmentDTO>>(data);
           
            return mappedData;
        }

        public int GetWhereCount(Expression<Func<Department, bool>> where)
        {
            var count = _unitOfWork.DepartmentRepo.GetWhere(where).Count();
            return count;
        }

        public DepartmentDTO GetById(int id)
        {
            var data = _unitOfWork.DepartmentRepo.GetWhere(e => e.Id == id, x => x.DepartmentManager).SingleOrDefault();
            var mappedData = _mapper.Map<DepartmentDTO>(data);
            
            return mappedData;
        }

    }
}