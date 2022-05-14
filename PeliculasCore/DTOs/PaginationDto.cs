using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeliculasCore.DTOs
{
    public class PaginationDto
    {
        private readonly int maxRowsPerPage = 100;
        public int Page { get; set; } = 1;

        private int rowsPerPage = 10;

        public int RowsPerPage
        {
            get => rowsPerPage;
            set
            {
                rowsPerPage = value > maxRowsPerPage ? maxRowsPerPage : value;
            }
        }

    }
}
