
namespace PMCDataModel
{
    public abstract class CollectionCreator<T> 
    {
        public abstract Collection<T> Create();
    }

    public class MatrixCreator<T> : CollectionCreator<T> 
    {
        public override Collection<T> Create()
        {
            return new Matrix<T>();
        }
    }

    public class ContainersCreator<T> : CollectionCreator<T> where T : Container
    {
        public override Collection<T> Create()
        {
            return new Containers<T>();
        }
    }

}
