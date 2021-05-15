using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using QEntangle.Web.Data;
using QEntangle.Web.Database;
using QEntangle.Web.Database.Identity;
using QEntangle.Web.Exceptions;
using QEntangle.Web.Interfaces;
using QEntangle.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QEntangle.Web.Repositorys
{
  public class ChoiceRepository : IChoiceRepository
  {
    private readonly DatabaseContext databaseContext;

    public ChoiceRepository(DatabaseContext databaseContext)
    {
      this.databaseContext = databaseContext;
    }

    public async Task<IList<ChoiceData>> GetChoices(Guid userId)
    {
      List<ChoiceEntity> data = await (from c in this.databaseContext.Choice
                                       where c.UserId == userId
                                       select c).ToListAsync();

      var result = data.Select(CreateGetDataFromEntity).ToList();

      return result;
    }

    private static ChoiceData CreateGetDataFromEntity(ChoiceEntity entity)
    {
      return new ChoiceData()
      {
        Id = entity.Id,
        Name = entity.Name,
        Options = entity.Options.Split(","),
        DefinitiveOption = entity.DefinitiveOption
      };
    }

    public async Task PostChoiceAsync(PostChoiceData choice, Guid userId)
    {
      var optionsArray = choice.Options.Split(",").Select(o => o.Trim()).ToArray();
      if (optionsArray.Length < 2)
      {
        throw new UserException("At least 2 options are required.");
      }
      string optionsString = string.Join(",", optionsArray);

      var entity = new ChoiceEntity()
      {
        Name = choice.Name,
        Options = optionsString,
        UserId = userId,
      };

      await databaseContext.AddAsync(entity);
      await databaseContext.SaveChangesAsync();
    }
  }
}
