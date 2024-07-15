﻿using GerenciadorLivro.Application.DTO.ViewModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorLivro.Application.Query.Users
{
    public class GetUsers:IRequest<List<UserViewModel>>
    {
    }
}
