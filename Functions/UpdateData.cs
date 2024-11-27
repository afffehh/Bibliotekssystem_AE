using System;
using System.Threading.Tasks;
using Bibliotekssystem.Models;

    public class UpdateData
    {
        private readonly AppDbContext _context;

        public UpdateData(AppDbContext context)
        {
            _context = context;
        }
    }

        