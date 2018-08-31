using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Hosting;
using System.Web.Http;
using System.Xml.Linq;

namespace HoistFinance.Controllers
{
    using Contract.Models;
    using HoistFinance.Contract;
    using HoistFinance.Contract.ContextInterface;

    public class RequestsController : ApiController
    {
        private IRequestContext _context;
        
        public RequestsController()
        {
            _context =  new RequestsContext();
        }

        public RequestsController(IRequestContext context)
        {
            _context = context;
        }


        [HttpGet]
        [Route("api/jobs/saveFiles")]
        public HttpResponseMessage SaveFiles()
        {
            var requestsList = _context.Requests.ToList();
            if (requestsList.Count == 0)
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }

            foreach (var request in requestsList)
            {
                var schema = new XElement("request");
                schema.Add(new XElement("ix", request.Index.ToString()));

                schema.Add(GetNodes(request));
                SaveXmlFiles(schema, request);
            }
                
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpPost]
        [Route("api/data")]
        public HttpResponseMessage PostRequestModel(IEnumerable<RequestModel> requests)
        {
            if (!ModelState.IsValid)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }

            foreach (var request in requests)
            {
                _context.Add<RequestModel>(request);
            }

            _context.SaveChanges();

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        private void SaveXmlFiles(XElement schema, RequestModel request)
        {
            var xmlDoc = new XDocument(schema);
            int i = 0;
            string basePath = HostingEnvironment.MapPath(@"~/App_Data/xml/") + request.Date.ToShortDateString();
            var path = basePath;
            while (File.Exists(path + ".xml"))
            {
                path = string.Format(basePath + "-{0}", i++.ToString());
            }
            xmlDoc.Save(path + ".xml");
        }

        private XElement GetNodes(RequestModel request)
        {
            var visits = request.Visits;
            return visits == null || visits == 0 
                ? new XElement("content", new XElement("name", request.Name),
                                new XElement("dateRequested", request.Date))
                : new XElement("content", new XElement("name", request.Name),
                        new XElement("visits", request.Visits),
                        new XElement("dateRequested", request.Date.ToShortDateString()));
        }

        private bool RequestModelExists(int id)
        {
            return _context.Requests.Count(e => e.Index == id) > 0;
        }
    }
}