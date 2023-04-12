using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CinemaWPF.Logic.Interfaces;
using CinemaWPF.Models;

[Route("/api/brand")]
[ApiController]
public class ReverseController : ControllerBase
{
    IReverseLogic logic;
    public ReverseController(IReverseLogic logic)
    {
        this.logic = logic;
    }

    [HttpGet]
    public IEnumerable<Seat> ReadAll()
    {
        return this.logic.ReadAll();
    }

    [HttpGet("{id}")]
    public Seat Read(int id)
    {
        return this.logic.Read(id);
    }

    [HttpPost]
    public void Create([FromBody] Seat brand)
    {
        this.logic.Create(brand);
    }

    [HttpPut]
    public void Put([FromBody] Seat brand)
    {
        this.logic.Update(brand);
    }

    [HttpDelete("{id}")]
    public void Delete(int id)
    {
        this.logic.Delete(id);
    }
}
