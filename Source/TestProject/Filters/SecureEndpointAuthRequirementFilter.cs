﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestProject.Filters {
    internal class SecureEndpointAuthRequirementFilter : IOperationFilter {
        public void Apply(OpenApiOperation operation, OperationFilterContext context) {
            if(!context.ApiDescription
                .ActionDescriptor
                .EndpointMetadata
                .OfType<AuthorizeAttribute>()
                .Any()) {
                return;
            }

            operation.Security = new List<OpenApiSecurityRequirement>
            {
            new OpenApiSecurityRequirement
            {
                [new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "basic"
                    }
                }] = new List<string>()
            }
        };
        }
    }
}
