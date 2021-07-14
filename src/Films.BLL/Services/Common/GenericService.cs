using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using Films.Repository.Common;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Films.BLL.Services.Common
{
    public class GenericService<TDbElement, TDtoElement, TKey>
       : IGenericService<TDtoElement, TKey>

       where TDbElement : class, new()
       where TDtoElement : class, new()

    {
        #region Fields
        IGenericRepository<TDbElement, TKey> m_repository;
        protected IMapper m_mapper;
        #endregion

        public GenericService(IGenericRepository<TDbElement, TKey> repository)
        {
            m_repository = repository;
            m_mapper = GetMapper();
        }

        #region Methods

        // flash mapper, tiny mapper 
        protected virtual AutoMapper.IMapper GetMapper()
        {
            var mapperConfig = new MapperConfiguration
            (
                ce =>
                {
                    ce.CreateMap<TDbElement, TDtoElement>().ReverseMap();
                    ce.AddExpressionMapping();
                }
            );
            return new Mapper(mapperConfig);
        }


        public IQueryable<TDtoElement> GetAll()
        {
            var collection = m_repository
                .GetAll()
                .Select(item => m_mapper.Map<TDtoElement>(item));

            return collection;
        }
        public async Task<TDtoElement> GetAsync(TKey key)
        {
            var item = await m_repository.GetAsync(key);
            var target = m_mapper.Map<TDtoElement>(item);
            return target;
        }

        public async Task<TDtoElement> AddAsync(TDtoElement item)
        {
            var target = m_mapper.Map<TDbElement>(item);
            await m_repository.AddAsync(target);
            await m_repository.SaveAsync();
            return m_mapper.Map<TDtoElement>(target);
        }
        public async Task<TDtoElement> UpdateAsync(TDtoElement item)
        {
            var target = m_mapper.Map<TDbElement>(item);
            m_repository.Update(target);
            await m_repository.SaveAsync();
            return m_mapper.Map<TDtoElement>(target);
        }

        public async Task DeleteAsync(TKey id)
        {
            await m_repository.DeleteAsync(id);
            await m_repository.SaveAsync();
        }

        public IQueryable<TDtoElement> Where(Expression<Func<TDtoElement, bool>> predicate)
        {
            var targetPredicate = m_mapper.Map<Expression<Func<TDbElement, bool>>>(predicate);

            var result = m_repository
                .Where(targetPredicate)
                .Select(item => m_mapper.Map<TDtoElement>(item));

            return result;
        }

        #endregion
    }
}
