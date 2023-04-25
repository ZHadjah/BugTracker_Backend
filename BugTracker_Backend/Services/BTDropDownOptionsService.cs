using BugTracker_Backend.Services.Interfaces;
using BugTracker_Backend.Models.Enums;
using NuGet.Packaging;
using BugTracker_Backend.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections;

namespace BugTracker_Backend.Services;

public class BTDropDownOptionsService : IBTDropDownOptionsService
{
    public string GetAllTicketStatusesAsync()
    {
        Dictionary<BTTicketStatus,string> ticketStatuses = Enum.GetValues(typeof(BTTicketStatus))
                                                     .Cast<BTTicketStatus>()
                                                     .ToDictionary(e => e, e => Enum.GetName(typeof(BTTicketStatus), e));

        JsonSerializerSettings settings = new JsonSerializerSettings();
        settings.ContractResolver = new DictionaryAsArrayResolver();

        // serialize
        string json = JsonConvert.SerializeObject(ticketStatuses, Formatting.Indented, settings);

        return json;
    }

    public string GetAllTicketTypesAsync()
    {
        Dictionary<BTTicketType, string> ticketTypes = Enum.GetValues(typeof(BTTicketType))
                                                       .Cast<BTTicketType>()
                                                       .ToDictionary(e => e, e => Enum.GetName(typeof(BTTicketType), e));

        JsonSerializerSettings settings = new JsonSerializerSettings();
        settings.ContractResolver = new DictionaryAsArrayResolver();

        // serialize
        string json = JsonConvert.SerializeObject(ticketTypes, Formatting.Indented, settings);

        return json;
    }

    public string GetAllTicketPrioritiesAsync()
    {
        Dictionary<BTTicketPriority, string> ticketPriorities = Enum.GetValues(typeof(BTTicketPriority))
                                                       .Cast<BTTicketPriority>()
                                                       .ToDictionary(e => e, e => Enum.GetName(typeof(BTTicketPriority), e));

        JsonSerializerSettings settings = new JsonSerializerSettings();
        settings.ContractResolver = new DictionaryAsArrayResolver();

        // serialize
        string json = JsonConvert.SerializeObject(ticketPriorities, Formatting.Indented, settings);

        return json;
    }
}

class DictionaryAsArrayResolver : DefaultContractResolver
{
    protected override JsonContract CreateContract(Type objectType)
    {
        if (objectType.GetInterfaces().Any(i => i == typeof(IDictionary) ||
            (i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IDictionary<,>))))
        {
            return base.CreateArrayContract(objectType);
        }

        return base.CreateContract(objectType);
    }
}

