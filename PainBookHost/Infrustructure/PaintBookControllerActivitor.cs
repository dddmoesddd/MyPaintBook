using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace PainBookHost.Infrustructure
{
    public class PaintBookControllerActivitor : IControllerActivator
    {
        IServiceCollection _services;

        public PaintBookControllerActivitor( IServiceCollection services)
        {
            _services = services;
       
        }
        public PaintBookControllerActivitor()
        {
           
           
        }
        public object Create(ControllerContext context)
        {
            Type type = context.ActionDescriptor.ControllerTypeInfo.AsType();
           var g= _services.BuildServiceProvider().GetService(type);
            return g;
        }

        public void Release(ControllerContext context, object controller)
        {
         
        }
    }
}
