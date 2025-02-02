using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace Library
{
    internal class Connection
    {
        public static NpgsqlConnection conlibrary = new NpgsqlConnection("Server=localhost;Port=5432; UserId=postgres;Password=1234567; Database=library;");
    }
}
