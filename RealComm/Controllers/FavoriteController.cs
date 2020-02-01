using RealComm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace RealComm.Controllers
{
    public class FavoriteAdd
    {
        public String Code { get; set; }
        public String Name { get; set; }
    }
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class FavoriteController : ApiController
    {
        

        public IEnumerable<Favorite> GetAllFavorites()
        {
            RealComm.Models.Model1 m = new Model1();
            return m.Favorite;
        }
        public IHttpActionResult PostProduct([FromBody] FavoriteAdd Data)
        {
            RealComm.Models.Model1 m = new Model1();
            Favorite f = new Favorite();
            f.Name = Data.Name;
            f.Code = Data.Code;
            try
            {
                Favorite item = m.Favorite.Add(f);
                m.SaveChanges();
                return Content(HttpStatusCode.OK, item); 
            }
            catch(Exception ex)
            {

                return Content(HttpStatusCode.InternalServerError, ex);
            }
            
        }
        public void PutProduct(int id, string Name,String Code)
        {
            Favorite f = new Favorite();
            f.Name = Name;
            
            RealComm.Models.Model1 m = new Model1();
            var favorite = m.Favorite
                    .Where(s => s.Id == id)
                    .FirstOrDefault();
            favorite.Name = Name;
            favorite.Code = Code;
            m.SaveChanges();
        }
        public IHttpActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Not a valid Favorite");
            RealComm.Models.Model1 m = new Model1();
            Favorite f = new Favorite();
            f.Id = id;

            //m.Favorite.Remove(f);
            
                
                var favorite = m.Favorite
                    .Where(s => s.Id == id)
                    .FirstOrDefault();
            if (favorite == null)
                return Content(HttpStatusCode.NotFound,String.Format("Favorite With Code {0} Not Found",id)) ;
                m.Entry(favorite).State = System.Data.Entity.EntityState.Deleted;
                m.SaveChanges();


            return Content(HttpStatusCode.OK, String.Format("Favorite With Code {0} Deleted", id));
        }
        public IHttpActionResult GetFavorite(int id)
        {

            return NotFound();

        }
    }
}
