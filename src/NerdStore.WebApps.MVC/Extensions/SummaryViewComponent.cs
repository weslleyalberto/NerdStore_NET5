﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using NerdStore.Core.Messages.CommonMessages.Notifications;
using System.Threading.Tasks;

namespace NerdStore.WebApps.MVC.Extensions
{
    public class SummaryViewComponent : ViewComponent
    {
        private readonly DomainNotificationHandler _notifications;
        public SummaryViewComponent(INotificationHandler<DomainNotification> notifications)
        {
            _notifications = notifications as DomainNotificationHandler;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var notifications = await Task.FromResult((_notifications.ObterNotificacoes()));
            notifications.ForEach(c => ViewData.ModelState.AddModelError(string.Empty, c.Value));
            return View();  
        }
    }
}
