namespace CashFlow.Domain.Entities.Common;

public class BaseEntity
    {
        public BaseEntity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set;}
    }
