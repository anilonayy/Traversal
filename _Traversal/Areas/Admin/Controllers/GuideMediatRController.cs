using _Traversal.CQRS.Commands.Destination;
using _Traversal.CQRS.Commands.Guide;
using _Traversal.CQRS.Queries.Guide;
using _Traversal.CQRS.Results.Guide;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace _Traversal.Areas.Admin.Controllers
{
    public class GuideMediatRController : BaseController
    {
        private readonly IMediator _mediator;

        public GuideMediatRController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _mediator.Send(new GetAllGuideQuery());

            return View(values);
        }

        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateGuideCommand command)
        {
            await _mediator.Send(command);
            return RedirectToAction("Index");
        }

        
        public async Task<IActionResult> Update(int id)
        {
            var data = await _mediator.Send(new GetGuideByIdQuery(id));
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateGuideCommand model)
        {
            _mediator.Send(model);
            return RedirectToAction("Index");
        }


        public IActionResult Delete(int id)
        {
            _mediator.Send(new DeleteGuideCommand(id));
            return RedirectToAction("Index");
        }
       
    }
}
