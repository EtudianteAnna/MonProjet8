using Microsoft.AspNetCore.Mvc;
using Ocelot.Raft;

namespace PasserelleApi.Controllers
{
    public class RaftController : Controller

    { 
    private readonly IRaftCommandProcessor_raftCommandProcessor;
            
       public RaftController() 
    {
            _raftCommandProcessor = raftCommandProcessor;
            // Déclarations de membres de l'interface
    }




        [HttpPost]
        public IActionResult AppendEntries()
        {
            return Ok();
        }
    }
}

