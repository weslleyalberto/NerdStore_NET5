using MediatR;
using Microsoft.AspNetCore.Mvc;
using NerdStore.Core.Comunication.Mediator;
using NerdStore.Core.Messages.CommonMessages.Notifications;
using System;

namespace NerdStore.WebApps.MVC.Controllers
{
    public abstract class ControllerBase : Controller
    {
        private readonly DomainNotificationHandler _notifications;
        private readonly IMediatrHandler _mediatorHandler;
        protected Guid ClienteId = Guid.Parse("4b10fc0f-bb1d-4381-a80d-930060a5a277");

        protected ControllerBase(INotificationHandler<DomainNotification> notifications,
            IMediatrHandler mediatorHandler)
        {
            _notifications = notifications  as DomainNotificationHandler;
            _mediatorHandler = mediatorHandler;
        }
        protected bool OperacaoValida()
        {
            return !_notifications.TemNotificacao();
        }
        protected void NotificarErro(string codigo, string message)
        {
            _mediatorHandler.PublicarNotificacao(new DomainNotification(codigo, message));
        }
    }
}
