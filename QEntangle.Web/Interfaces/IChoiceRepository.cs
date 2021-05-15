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

    public Task<IList<ChoiceData>> GetChoices(Guid userId);

    public Task PostChoiceAsync(ChoiceEntity entity);

    public Task<ChoiceEntity> GetChoice(Guid choiceId, Guid userId);

    public Task SaveChanges();

    #endregion Methods
  }
}