using Infrastructure.Contexts;
using Infrastructure.Dtos;
using Infrastructure.Entities;
using System.Diagnostics;

namespace Infrastructure.Services;

public class ClientContactService(DataContext dataContext)
{
	private readonly DataContext _dataContext = dataContext;

	public bool Create(ClientContactDto clientContactDto)
	{
		try
		{
			if (clientContactDto.Email != null!)
			{
				var newContact = new ClientContactEntity
				{
					Id = Guid.NewGuid().ToString(),
					Email = clientContactDto.Email,
					Message = clientContactDto.Message,
					Phone = clientContactDto.Phone,
					UserName = clientContactDto.UserName,
				};
				if (newContact != null)
				{
					_dataContext.ClientContacts.Add(newContact);
					_dataContext.SaveChanges();
					return true;
				}
			}
		}
		catch (Exception ex)
		{
			Debug.WriteLine($"ERROR :: ClientContactService.Create{ex.Message}");
		}
		return false;
	}
	public ClientContactDto GetOne(string email)
	{
		try
		{
			if (!string.IsNullOrEmpty(email))
			{
				var existingEntity = _dataContext.ClientContacts.FirstOrDefault(x => x.Email == email);
				if (existingEntity != null)
				{
					var existingClientContact = new ClientContactDto
					{
						Email = existingEntity.Email,
						Message = existingEntity.Message,
						Phone = existingEntity.Phone,
						UserName = existingEntity.UserName,
					};
					if (existingClientContact != null)
						return existingClientContact;
				}
			}
		}
		catch (Exception ex)
		{
			Debug.WriteLine($"ERROR :: ClientContactService.Create{ex.Message}");
		}
		return null!;
	}
	public IEnumerable<ClientContactDto> GetAll()
	{
		try
		{
			var existringClientEntities = _dataContext.ClientContacts.ToList();
			if (existringClientEntities != null)
			{
				var existingClientContacts = new List<ClientContactDto>();

				foreach (var entity in existringClientEntities)
				{
					var existingClientContact = new ClientContactDto
					{
						Email = entity.Email,
						Message = entity.Message,
						Phone = entity.Phone,
						UserName = entity.UserName,
					};
					if (existingClientContact != null)
					{
						existingClientContacts.Add(existingClientContact);
					}

					if (existingClientContacts.Count > 0)
					{
						return existingClientContacts;
					}

				}
			}

		}
		catch (Exception ex)
		{
			Debug.WriteLine($"ERROR :: ClientContactService.Create{ex.Message}");
		}
		return null!;
	}
	public bool Delete(string email)
	{
		try
		{
			var existingClientContact = _dataContext.ClientContacts.FirstOrDefault(x => x.Email == email);
			if (existingClientContact != null)
			{
				_dataContext.ClientContacts.Remove(existingClientContact);
				_dataContext.SaveChanges();
				return true;
			}
		}
		catch (Exception ex)
		{
			Debug.WriteLine($"ERROR :: ClientContactService.Create{ex.Message}");
		}
		return false;
	}
}