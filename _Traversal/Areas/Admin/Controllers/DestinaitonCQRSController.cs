using _Traversal.CQRS.Commands.Destination;
using _Traversal.CQRS.Handlers;
using _Traversal.CQRS.Handlers.Destination;
using _Traversal.CQRS.Queries.Destination;
using Microsoft.AspNetCore.Mvc;


namespace _Traversal.Areas.Admin.Controllers
{
    public class DestinaitonCQRSController : BaseController
    {
        private readonly GetAllDestinationQueryHandler _getAllDestinationQuertHandler;
        private readonly GetDestinationByIdQueryHandler _getDestinationByIdQueryHandler;
        private readonly CreateCommandHandler _createCommandHandler;
        private readonly DeleteCommandHandler _deleteCommandHandler;
        private readonly UpdateCommandHandler _updateCommandHandler;

        public DestinaitonCQRSController(GetAllDestinationQueryHandler getAllDestinationQuertHandler, GetDestinationByIdQueryHandler getDestinationByIdQueryHandler, CreateCommandHandler createCommandHandler, DeleteCommandHandler deleteCommandHandler, UpdateCommandHandler updateCommandHandler)
        {
            _getDestinationByIdQueryHandler = getDestinationByIdQueryHandler;
            _getAllDestinationQuertHandler = getAllDestinationQuertHandler;
            _createCommandHandler = createCommandHandler;
            _deleteCommandHandler = deleteCommandHandler;
            _updateCommandHandler = updateCommandHandler;
        }

        public IActionResult Index()
        {
            var values = _getAllDestinationQuertHandler.Handle();
            return View(values);
        }

        [HttpGet]
        public IActionResult GetDestination(int id)
        {
            var value = _getDestinationByIdQueryHandler.Handle(new GetDestinationByIdQuery { id = id });
            return View(value);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        public IActionResult DeleteDestination(int id)
        {
            _deleteCommandHandler.Handler(new DeleteDestinationCommand(id));

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Add(CreateDestinationCommand command)
        {
            _createCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }

        [HttpGet]
        
      
        [HttpPost]
        public IActionResult Update(UpdateDestinationCommand model)
        {
            _updateCommandHandler.Handle(model);
            return RedirectToAction("Index");
        }

       
        
    }
}
