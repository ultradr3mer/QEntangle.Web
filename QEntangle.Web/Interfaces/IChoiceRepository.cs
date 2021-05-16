using QEntangle.Web.Data;
using QEntangle.Web.Database;
using QEntangle.Web.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QEntangle.Web.Interfaces
{
  public interface IChoiceRepository
  {
    #region Methods

    Task<IList<ChoiceData>> GetChoices(Guid userId);

    Task PostAsync(ChoiceEntity entity);

    Task<ChoiceEntity> Get(Guid choiceId, Guid userId);

    Task SaveChanges();

    Task Delete(ChoiceEntity entity);

    #endregion Methods
  }
}