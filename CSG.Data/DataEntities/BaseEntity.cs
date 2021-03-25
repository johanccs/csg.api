using System;

namespace CSG.Data.DataEntities
{
    public class BaseEntity
    {
        #region Properties

        public string Id { get;}

        #endregion

        #region Constructor

        public BaseEntity(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentException("Invalid Entity Id");

            Id = id;
        }
        #endregion

        #region Methods
        public string GetId()
        {
            return Id;
        }

        #endregion
    }
}
