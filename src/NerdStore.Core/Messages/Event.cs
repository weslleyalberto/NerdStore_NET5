using MediatR;
using System;
using System.ComponentModel.DataAnnotations;

namespace NerdStore.Core.Messages
{
    public class Event : Message , INotification
    {
        [Key]    
        public DateTime Timestamp { get; private set; }
        protected Event()
        {
            Timestamp = DateTime.Now;
        }
    }
}
