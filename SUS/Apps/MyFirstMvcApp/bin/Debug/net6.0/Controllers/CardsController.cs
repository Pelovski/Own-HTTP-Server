﻿namespace MyFirstMvcApp.Controllers
{
    using System;
    using System.ComponentModel;
    using SUS.HTTP;
    using SUS.MvcFramework;
    public class CardsController : Controller
    {
        public HttpResponse Add(HttpRequest request)
        {
            return this.View();
        }

        public HttpResponse All(HttpRequest request)
        {
            return this.View();
        }

        public HttpResponse Collection(HttpRequest request)
        {
            return this.View();
        }
    }
}
