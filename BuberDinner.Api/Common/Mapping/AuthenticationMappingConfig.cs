﻿using BuberDinner.Application.Authentication.Commands.Register;
using BuberDinner.Application.Authentication.Common;
using BuberDinner.Application.Authentication.Query.Login;
using BuberDinner.Contracts.Authentication;
using Mapster;

namespace BuberDinner.Api.Common.Mapping
{
    public class AuthenticationMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<RegisterRequest, RegisterCommand>();

            config.NewConfig<LoginRequest, LoginQuery>();

            config.NewConfig<AuthenticationResult, AuthenticationResponse>()
                .Map(dest => dest.Id, src => src.User.Id.Value)
                .Map(des => des, src => src.User);
        }
    }
}
