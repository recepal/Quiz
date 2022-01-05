using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Dal
{
    public class MainRepo : IMainRepo
    {
        private readonly AppContext _context;

        public MainRepo()
        {
            _context = new AppContext();
        }

        public bool CreateDb()
        {
            bool result;
            try
            {
                _context.Database.Migrate();
                result = true;
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }
    }
}
