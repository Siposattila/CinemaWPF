using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CinemaWPF.Logic.Interfaces;
using CinemaWPF.Models;
using Microsoft.AspNetCore.SignalR;
using CinemaWPF.Endpoint.Services;

[Route("/api/reserve")]
[ApiController]
public class ReserveController : ControllerBase
{
    IReserveLogic logic;
    IHubContext<SignalRHub> hub;

    public ReserveController(IReserveLogic logic, IHubContext<SignalRHub> hub)
    {
        this.logic = logic;
        this.hub = hub;
    }

    [HttpGet]
    public IEnumerable<Reserve> ReadAll()
    {
        return this.logic.ReadAll();
    }

    [HttpGet("{id}")]
    public Reserve Read(int id)
    {
        return this.logic.Read(id);
    }

    [HttpPost]
    public void Create([FromBody] Reserve reserve)
    {
        this.logic.Create(reserve);
        this.hub.Clients.All.SendAsync("ReserveCreated", reserve);
    }

    [HttpPut]
    public void Put([FromBody] Reserve reserve)
    {
        this.logic.Update(reserve);
        this.hub.Clients.All.SendAsync("ReserveUpdated", reserve);
    }

    [HttpDelete("{id}")]
    public void Delete(int id)
    {
        this.logic.Delete(id);
        this.hub.Clients.All.SendAsync("ReserveDeleted", this.logic.Read(id));
    }
}
