using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PW.Domain.Models
{
    public class Message
    {
        public long Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public bool IsEmailed { get; private set; }
        public bool Status { get; private set; }

        protected Message()
        {

        }
        public Message(string name, string email, string title, string description)
        {
            Name = name;
            Email = email;
            Title = title;
            Description = description;
            CreatedDate = DateTime.Now;
            IsEmailed = false;
            Status = true;
        }
        public void Emailed()
        {
            IsEmailed = true;
        }
        public void Remove()
        {
            Status = false;
        }
    }
}
