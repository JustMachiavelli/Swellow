using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swellow.API.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Swellow.API.Controllers
{
    public class VideoController : ControllerBase
    {
        private readonly IDbManager _dbManager;
        private readonly IMapper _mapper;

        public VideoController(IDbManager dbManager, IMapper mapper)
        {
            _dbManager = dbManager ?? throw new ArgumentNullException(nameof(dbManager));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }


    }
}
