using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using DryIoc;
using DryIoc.WebApi;
using ContactsAPI.Services;

namespace ContactsAPI
{
    public class DryIocConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var c = new Container().WithWebApi(config);

            c.Register<IContactsRepository, ContactsRepository>(Reuse.Singleton);
        }
    }
}