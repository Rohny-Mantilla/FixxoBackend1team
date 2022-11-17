using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FixxoBackend.Models.Entities
{
	public class OrderEntity
	{
        public int Id { get; set; }

        public int TotalAmount { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        
    }
}



