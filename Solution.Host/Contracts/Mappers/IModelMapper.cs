namespace Solution.Host.Contracts.Mappers;

public interface IModelMapper<T>
{
    object Map(T input);
}
